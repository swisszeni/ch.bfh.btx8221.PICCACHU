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
        private string _databaseName = "Userdata.db3";
        private string _databaseKeyName = "UserdataDBKey";

        public LocalUserDataServiceSQLite()
        {
            CreateOrConnectDatabase();
        }

        private void CreateOrConnectDatabase()
        {
            _database = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalUserdataDatabaseFilePath(_databaseName));
            CreateTablesIfNotExist();
        }

        private void CreateTablesIfNotExist()
        {
            _database.CreateTableAsync<UserMasterData>().Wait();
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

        Task ILocalUserDataService.ResetLocalUserDataAsync()
        {
            throw new NotImplementedException();
        }

        Task<List<UserMasterData>> ILocalUserDataService.GetMasterDataAsync()
        {
            throw new NotImplementedException();
        }

        Task<int> ILocalUserDataService.SaveMasterDataAsync(UserMasterData masterData)
        {
            throw new NotImplementedException();
        }

        Task<int> ILocalUserDataService.DeleteAllMasterDataAsync()
        {
            throw new NotImplementedException();
        }

        Task<int> ILocalUserDataService.DeleteMasterDataAsync(UserMasterData masterData)
        {
            throw new NotImplementedException();
        }

        Task<List<JournalEntry>> ILocalUserDataService.GetJournalEntriesAsync()
        {
            throw new NotImplementedException();
        }

        Task<int> ILocalUserDataService.SaveJournalEntryAsync(JournalEntry test)
        {
            throw new NotImplementedException();
        }

        Task<int> ILocalUserDataService.DeleteJournalEntryAsync(JournalEntry entry)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
