using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFH_USZ_PICC.Models;
using SQLite;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Services
{
    public class LocalUserDataServiceSQLite : ILocalUserDataService
    {
        private SQLiteAsyncConnection _database;

        public LocalUserDataServiceSQLite()
        {
            _database = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalUserdataDatabaseFilePath("Userdata.db3"));
            CreateTablesIfNotExist();
        }

        private void CreateTablesIfNotExist()
        {
            _database.CreateTableAsync<UserMasterData>().Wait();
        }

        #region MasterData

        public async Task<int> SaveMasterDataAsync(UserMasterData masterData)
        {
            masterData.ID = 1;
            if(await _database.Table<UserMasterData>().CountAsync() > 0)
            {
                return await _database.UpdateAsync(masterData);
            } else
            {
                return await _database.InsertAsync(masterData);
            }
        }

        public Task<int> DeleteAllMasterDataAsync()
        {
            return _database.ExecuteAsync($"delete from [{typeof(UserMasterData).Name}]");
        }

        public Task<int> DeleteMasterDataAsync(UserMasterData masterData)
        {
            masterData.ID = 1;
            return _database.DeleteAsync(masterData);
        }

        public Task<List<UserMasterData>> GetMasterDataAsync()
        {
            return _database.Table<UserMasterData>().ToListAsync();
        }

        #endregion
    }
}
