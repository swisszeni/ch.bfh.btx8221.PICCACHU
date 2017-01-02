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
            var drugResult = _database.All<AdministeredDrugEntryRO>();           
            foreach (var entry in drugResult)
            { resultList.Add(new AdministeredDrugEntry((entry))); }

            var statlockResult = _database.All<StatlockChangingEntryRO>();
            foreach (var entry in statlockResult)
            { resultList.Add(new StatlockChangingEntry((entry))); }

            var bandageResult = _database.All<BandageChangingEntryRO>();
            foreach (var entry in bandageResult)
            { resultList.Add(new BandageChangingEntry((entry))); }

            var bloodflowResult = _database.All<BloodWithdrawalEntryRO>();
            foreach (var entry in bloodflowResult)
            { resultList.Add(new BloodWithdrawalEntry((entry))); }

            var flushResult = _database.All<CatheterFlushEntryRO>();
            foreach (var entry in flushResult)
            { resultList.Add(new CatheterFlushEntry((entry))); }

            var infusionResult = _database.All<InfusionEntryRO>();
            foreach (var entry in infusionResult)
            { resultList.Add(new InfusionEntry((entry))); }

            var claveResult = _database.All<MicroClaveChangingEntryRO>();
            foreach (var entry in claveResult)
            { resultList.Add(new MicroClaveChangingEntry((entry))); }


            return Task.FromResult(resultList);
        }

        public Task<int> SaveJournalEntryAsync(JournalEntry entry)
        {
            _database.Write(() =>
            {
                var newEntryType = entry.Entry;

                switch (newEntryType)
                {
                    case (AllPossibleJournalEntries.AdministeredDrugEntry):
                        var drugEntryRO = new AdministeredDrugEntryRO();
                        drugEntryRO.LoadDataFromModelObject((AdministeredDrugEntry)entry);
                        _database.Add(drugEntryRO);                       
                        return;
                    case (AllPossibleJournalEntries.StatlockEntry):
                        var statlockEntryRO = new StatlockChangingEntryRO();
                        statlockEntryRO.LoadDataFromModelObject((StatlockChangingEntry)entry);
                        _database.Add(statlockEntryRO);
                        return;
                    case (AllPossibleJournalEntries.BandagesChangingEntry):
                        var bandageEntryRO = new BandageChangingEntryRO();
                        bandageEntryRO.LoadDataFromModelObject((BandageChangingEntry)entry);
                        _database.Add(bandageEntryRO);
                        return;
                    case (AllPossibleJournalEntries.BloodWithdrawalEntry):
                        var bloodEntryRO = new BloodWithdrawalEntryRO();
                        bloodEntryRO.LoadDataFromModelObject((BloodWithdrawalEntry)entry);
                        _database.Add(bloodEntryRO);
                        return;
                    case (AllPossibleJournalEntries.CatheterFlushEntry):
                        var flushEntryRO = new CatheterFlushEntryRO();
                        flushEntryRO.LoadDataFromModelObject((CatheterFlushEntry)entry);
                        _database.Add(flushEntryRO);
                        return;
                    case (AllPossibleJournalEntries.InfusionEntry):
                        var infusionEntryRO = new InfusionEntryRO();
                        infusionEntryRO.LoadDataFromModelObject((InfusionEntry)entry);
                        _database.Add(infusionEntryRO);
                        return;
                    case (AllPossibleJournalEntries.MicroClaveEntry):
                        var claveEntryRO = new MicroClaveChangingEntryRO();
                        claveEntryRO.LoadDataFromModelObject((MicroClaveChangingEntry)entry);
                        _database.Add(claveEntryRO);
                        return;
                    default:
                        return;
                }
            });

            return Task.FromResult(1);
        }

        public Task<int> DeleteJournalEntryAsync(JournalEntry entry)
        {
            var newEntryType = entry.Entry;
            switch (newEntryType)
            {
                case (AllPossibleJournalEntries.AdministeredDrugEntry):
                    var existingDrugEntryRO = _database.Find<AdministeredDrugEntryRO>(entry.ID);
                    if (existingDrugEntryRO != null)
                    {
                        _database.Write(() =>
                        {
                            _database.Remove(existingDrugEntryRO);
                        });
                    }
                    return Task.FromResult(0);
                case (AllPossibleJournalEntries.StatlockEntry):
                    var existingStatlockEntryRO = _database.Find<StatlockChangingEntryRO>(entry.ID);
                    if (existingStatlockEntryRO != null)
                    {
                        _database.Write(() =>
                        {
                            _database.Remove(existingStatlockEntryRO);
                        });
                    }
                    return Task.FromResult(0);
                case (AllPossibleJournalEntries.BandagesChangingEntry):
                    var existingBandageEntryRO = _database.Find<BandageChangingEntryRO>(entry.ID);
                    if (existingBandageEntryRO != null)
                    {
                        _database.Write(() =>
                        {
                            _database.Remove(existingBandageEntryRO);
                        });
                    }
                    return Task.FromResult(0);
                case (AllPossibleJournalEntries.BloodWithdrawalEntry):
                    var existingBloodEntryRO = _database.Find<BloodWithdrawalEntryRO>(entry.ID);
                    if (existingBloodEntryRO != null)
                    {
                        _database.Write(() =>
                        {
                            _database.Remove(existingBloodEntryRO);
                        });
                    }
                    return Task.FromResult(0);
                case (AllPossibleJournalEntries.CatheterFlushEntry):
                    var existingFlushEntryRO = _database.Find<CatheterFlushEntryRO>(entry.ID);
                    if (existingFlushEntryRO != null)
                    {
                        _database.Write(() =>
                        {
                            _database.Remove(existingFlushEntryRO);
                        });
                    }
                    return Task.FromResult(0);
                case (AllPossibleJournalEntries.InfusionEntry):
                    var existingInfusionEntryRO = _database.Find<InfusionEntryRO>(entry.ID);
                    if (existingInfusionEntryRO != null)
                    {
                        _database.Write(() =>
                        {
                            _database.Remove(existingInfusionEntryRO);
                        });
                    }
                    return Task.FromResult(0);
                case (AllPossibleJournalEntries.MicroClaveEntry):
                    var existingClaveEntryRO = _database.Find<MicroClaveChangingEntryRO>(entry.ID);
                    if (existingClaveEntryRO != null)
                    {
                        _database.Write(() =>
                        {
                            _database.Remove(existingClaveEntryRO);
                        });
                    }
                    return Task.FromResult(0);
                default:
                    return Task.FromResult(0);
            }
            #endregion
        }
    }
}
