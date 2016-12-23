using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFH_USZ_PICC.Models;
using Realms;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Services
{
    public class LocalUserDataServiceRealm : ILocalUserDataService
    {
        private Realm _database;

        public LocalUserDataServiceRealm()
        {
            string databaseName = "Userdata.realm";

            // Setting up the Configuration of our realm instance
            var config = new RealmConfiguration(DependencyService.Get<IFileHelper>().GetLocalUserdataDatabaseFilePath(databaseName));
            config.SchemaVersion = 1;
            // If we have a database, get the current key. Otherwise generate a new one
            if(DependencyService.Get<IFileHelper>().LocalUserdataDatabaseFileExists(databaseName))
            {
                // Get the existing key
            } else
            {
                // Generate new key. Normally instantiating a new Random inside a method is a horrible idea. 
                // But since we don't need any random numbers elsewhere in the App, this is sufficient
                Random rnd = new Random();
                byte[] key = new byte[64];
                rnd.NextBytes(key);

                // Convert the key to a Base64 encoded string to store it
                string keyString = Convert.ToBase64String(key);
                // Store the key in the secure storage of the OS
                // http://shribits.blogspot.ch/2015/10/using-xamarinforms-store-value-in.html
                XLabs.
                CrossSecureStorage.Current.SetValue("UserdataKey", keyString);

                config.EncryptionKey = key;
            }

            _database = Realm.GetInstance(config);
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
            } else
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
            if(existingRO != null)
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
    }
}
