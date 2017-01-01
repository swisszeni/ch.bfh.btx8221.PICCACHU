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

            //TEST Part for AdministeredDrug
            var realmResult = _database.All<AdministeredDrugEntryRO>();
            foreach (var entry in realmResult)
            { resultList.Add(new AdministeredDrugEntry((entry))); }



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
                        _database.Add(drugEntryRO);
                        drugEntryRO.LoadDataFromModelObject((AdministeredDrugEntry)entry);
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
                    var existingEntryRO = _database.Find<AdministeredDrugEntryRO>(entry.ID);
                    if (existingEntryRO != null)
                    {
                        _database.Write(() =>
                        {
                            _database.Remove(existingEntryRO);
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
