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
            _database = Realm.GetInstance(DependencyService.Get<IFileHelper>().GetLocalUserdataDatabaseFilePath("Userdata.realm"));
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
