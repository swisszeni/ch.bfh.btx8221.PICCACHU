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
            if (await _database.Table<UserMasterData>().CountAsync() > 0)
            {
                return await _database.UpdateAsync(masterData);
            }
            else
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

        #region JournalEntries
        public async Task<List<JournalEntry>> GetJournalEntriesAsync()
        {
            //List<JournalEntry> resultList = new List<JournalEntry>();

            //// Collect all journalEntries together
            //var drugTable = _database.Table<AdministeredDrugEntry>().ToListAsync();
            //foreach (var entry in drugTable.Result)
            //{
            //    resultList.Add(entry);
            //}

            //var statlockTable = _database.Table<StatlockChangingEntry>().ToListAsync();
            //foreach (var entry in statlockTable.Result)
            //{
            //    resultList.Add((entry));
            //}

            //return resultList;
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetJournalEntriesAsync<T>() where T : JournalEntry
        {
            throw new NotImplementedException();
        }

        public Task<T> GetJournalEntryAsync<T>(string ID) where T : JournalEntry
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveJournalEntryAsync<T>(T entry) where T : JournalEntry
        {
            //var newEntryType = entry.Entry;

            //switch (newEntryType)
            //{
            //    case (AllPossibleJournalEntries.AdministeredDrugEntry):
            //        var drugEntry = (AdministeredDrugEntry)entry;
            //        return await _database.InsertAsync(drugEntry);
            //    case (AllPossibleJournalEntries.StatlockEntry):
            //        var statlockEntry = (StatlockChangingEntry)entry;
            //        return await _database.InsertAsync(statlockEntry);
            //    default:
            //        return 1;
            //}
            throw new NotImplementedException();
        }

        public Task<int> DeleteJournalEntryAsync<T>(T entry) where T : JournalEntry
        {
            //return _database.DeleteAsync(entry);
            throw new NotImplementedException();
        }

        #endregion

        #region PICCs
        public Task<List<PICC>> GetFormerPICCsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PICC> GetCurrentPICCAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveCurrentPICCAsync(PICC currentPICC)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeltePICCAsync(PICC formerPICC)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
