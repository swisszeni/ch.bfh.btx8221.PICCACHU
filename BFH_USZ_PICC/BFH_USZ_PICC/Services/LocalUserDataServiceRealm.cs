using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFH_USZ_PICC.Models;
using Realms;
using Xamarin.Forms;
using Microsoft.Practices.ServiceLocation;

namespace BFH_USZ_PICC.Services
{
    public class LocalUserDataServiceRealm : ILocalUserDataService
    {
        private Realm _database;
        private static readonly string _databaseName = "Userdata.realm";
        private static readonly string _databaseKeyName = "ch.bfh.i4m1.picc.UserdataDBKey";

        public LocalUserDataServiceRealm()
        {
            CreateOrConnectDatabase();
        }

        private void CreateOrConnectDatabase()
        {
            // Setting up the Configuration of our realm instance
            var config = new RealmConfiguration(DependencyService.Get<IFileHelper>().GetLocalUserdataDatabaseFilePath(_databaseName));
            config.SchemaVersion = 1;
            // If we have a database, get the current key. Otherwise generate a new one
            if (DependencyService.Get<IFileHelper>().LocalUserdataDatabaseFileExists(_databaseName))
            {
                // Get the existing key
                ISecureStorage keyStore = DependencyService.Get<ISecureStorage>();
                config.EncryptionKey = keyStore.Retrieve(_databaseKeyName);
            }
            else
            {
                // Create a new key
                config.EncryptionKey = CreateAndStoreDatabaseKey();

            }

            _database = Realm.GetInstance(config);
        }

        private byte[] CreateAndStoreDatabaseKey()
        {
            // Generate new key. Normally instantiating a new Random inside a method is a horrible idea. 
            // But since we don't need any random numbers elsewhere in the App, this is sufficient
            Random rnd = new Random();
            byte[] key = new byte[64];
            rnd.NextBytes(key);

            // Store the key in the secure storage of the OS
            ISecureStorage keyStore = DependencyService.Get<ISecureStorage>();
            if (keyStore.Contains(_databaseKeyName))
            {
                keyStore.Delete(_databaseKeyName);
            }

            keyStore.Store(_databaseKeyName, key);

            return key;
        }

        public Task ResetLocalUserDataAsync()
        {
            // Delete the existing Database
            DependencyService.Get<IFileHelper>().DeleteLocalUserdataDatabaseFile(_databaseName);

            // Create a new Database
            CreateOrConnectDatabase();

            return Task.FromResult(true);
        }

        #region MasterData

        public Task<int> SaveMasterDataAsync(UserMasterData masterData)
        {
            masterData.ID = 1;
            var existingRO = _database.Find<UserMasterDataRO>(1);
            if (existingRO == null)
            {
                _database.Write(() =>
                {
                    var masterDataRO = new UserMasterDataRO();
                    _database.Add(masterDataRO);
                    masterDataRO.LoadDataFromModelObject(masterData);
                });
            }
            else
            {
                _database.Write(() =>
                {
                    existingRO.LoadDataFromModelObject(masterData);
                });
            }

            return Task.FromResult(1);
        }

        public Task<int> DeleteAllMasterDataAsync()
        {
            _database.Write(() =>
            {
                _database.RemoveAll<UserMasterDataRO>();
            });

            return Task.FromResult(0);
        }

        public Task<int> DeleteMasterDataAsync(UserMasterData masterData)
        {
            var existingRO = _database.Find<UserMasterDataRO>(masterData.ID);
            if (existingRO != null)
            {
                _database.Write(() =>
                {
                    _database.Remove(existingRO);
                });
            }
            return Task.FromResult(0);
        }

        public Task<List<UserMasterData>> GetMasterDataAsync()
        {
            List<UserMasterData> resultList = new List<UserMasterData>();
            var realmResult = _database.All<UserMasterDataRO>();
            foreach (var masterData in realmResult)
            {
                resultList.Add(new UserMasterData(masterData));
            }

            return Task.FromResult(resultList);
        }
        #endregion

        #region JournalEntry

        public Task<List<JournalEntry>> GetJournalEntriesAsync()
        {
            List<JournalEntry> resultList = new List<JournalEntry>();

            // Collets all journal entries together
            resultList.AddRange(_database.All<AdministeredDrugEntryRO>().ToList().Select((x) => new AdministeredDrugEntry(x)));
            resultList.AddRange(_database.All<StatlockChangingEntryRO>().ToList().Select((x) => new StatlockChangingEntry(x)));
            resultList.AddRange(_database.All<BandageChangingEntryRO>().ToList().Select((x) => new BandageChangingEntry(x)));
            resultList.AddRange(_database.All<BloodWithdrawalEntryRO>().ToList().Select((x) => new BloodWithdrawalEntry(x)));
            resultList.AddRange(_database.All<CatheterFlushEntryRO>().ToList().Select((x) => new CatheterFlushEntry(x)));
            resultList.AddRange(_database.All<InfusionEntryRO>().ToList().Select((x) => new InfusionEntry(x)));
            resultList.AddRange(_database.All<MicroClaveChangingEntryRO>().ToList().Select((x) => new MicroClaveChangingEntry(x)));


            return Task.FromResult(resultList);
        }

        public Task<List<T>> GetJournalEntriesAsync<T>() where T : JournalEntry
        {
            var entryTypeExample = (AdministeredDrugEntry)Activator.CreateInstance(typeof(T));
            return Task.FromResult(_database.All(entryTypeExample.RealmObjectType.Name).Select((x) => (T)Activator.CreateInstance(typeof(T), new object[] { x })).ToList());
        }

        public Task<T> GetJournalEntryAsync<T>(string ID) where T : JournalEntry
        {
            var entryTypeExample = (JournalEntry)Activator.CreateInstance(typeof(T));
            var entry = _database.Find(entryTypeExample.RealmObjectType.Name, ID);
            if(entry != null)
            {
                return Task.FromResult((T)Activator.CreateInstance(typeof(T), new object[] { entry }));
            }
            
            return Task.FromResult<T>(null);
        }

        public Task<int> SaveJournalEntryAsync<T>(T entry) where T : JournalEntry
        {
            if (String.IsNullOrEmpty(entry.ID))
            {
                // create the ID
                entry.ID = Guid.NewGuid().ToString();

                // create new entry
                _database.Write(() =>
                {
                    var rObject = (ILoadableJournalEntryRealmObject)Activator.CreateInstance(entry.RealmObjectType);
                    rObject.LoadDataFromModelObject((JournalEntry)(object)entry);

                    _database.Add((RealmObject)rObject);
                });
            } else
            {
                // update existing entry
                var existingRO = (ILoadableJournalEntryRealmObject)_database.Find(entry.RealmObjectType.Name, entry.ID);
                if (existingRO != null)
                {
                    _database.Write(() =>
                    {
                        existingRO.LoadDataFromModelObject((JournalEntry)(object)entry);
                    });
                }
            }
            
            return Task.FromResult(1);
        }

        public Task<int> DeleteJournalEntryAsync<T>(T entry) where T : JournalEntry
        {
            var existingEntryRO = _database.Find(entry.RealmObjectType.Name, entry.ID);
            if(existingEntryRO != null)
            {
                _database.Write(() =>
                {
                    _database.Remove(existingEntryRO);
                });
            }

            return Task.FromResult(0);
        }

        #endregion
      
        #region PICC

        public Task<List<PICC>> GetFormerPICCsAsync()
        {
            List<PICC> formerPICCs = new List<PICC>();

            // Collets the all former PICCs
            var formerPICCsRO = _database.All<PICCRO>();
            foreach (var picc in formerPICCsRO)
            {
                if (picc.RemovalDate != null)
                {
                    formerPICCs.Add(new PICC(picc));
                }
            }
            return Task.FromResult(formerPICCs);
        }

        public Task<PICC> GetCurrentPICCAsync()
        {
            PICC currentPICC = new PICC();
            // Collets the current PICC
            var currentPICCRO = _database.All<PICCRO>().FirstOrDefault((x) => x.RemovalDate == null);

            if (currentPICCRO != null)
            {
                return Task.FromResult(new PICC(currentPICCRO));
            }
            else { return Task.FromResult((PICC)null); }

        }

        public Task<int> SaveCurrentPICCAsync(PICC currentPICC)
        {
            //Check if a new PICC is set as current or if the current picc is only modified
            var currentPICCRO = _database.All<PICCRO>().FirstOrDefault((x) => x.RemovalDate == null);
            if (currentPICCRO == null || currentPICCRO.ID != currentPICC.ID)
            {
                _database.Write(() =>
                {   
                    //If the user has not removed the previous PICC, a removal date will be set to it (otherwise we would have two current PICCs)
                    if (currentPICCRO != null)
                    {
                        currentPICCRO.RemovalDate = DateTimeOffset.Now.Date.ToLocalTime();
                    }
                    var newCurrentPICCRO = new PICCRO();           
                    newCurrentPICCRO.LoadDataFromModelObject(currentPICC);

                    //Provide primary key to the new PICC and the new PICCModel objects
                    newCurrentPICCRO.ID = Guid.NewGuid().ToString();
                    newCurrentPICCRO.PICCModelRO.ID = Guid.NewGuid().ToString();

                    _database.Add(newCurrentPICCRO);
                });
            }
            else
            {
                _database.Write(() =>
                {
                    currentPICCRO.LoadDataFromModelObject(currentPICC);
                });
            }

            return Task.FromResult(1);
        }

        public Task<int> DeltePICCAsync(PICC picc)
        {
            var existingRO = _database.Find<PICCRO>(picc.ID);
            if (existingRO != null)
            {
                _database.Write(() =>
                {
                    _database.Remove(existingRO);
                });
            }
            return Task.FromResult(0);
        }

        #endregion
    }
}
