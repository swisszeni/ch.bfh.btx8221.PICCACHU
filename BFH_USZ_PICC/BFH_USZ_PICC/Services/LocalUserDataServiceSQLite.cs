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

            // JournalEntries
            _database.CreateTableAsync<AdministeredDrugEntry>().Wait();
            _database.CreateTableAsync<StatlockChangingEntry>().Wait();
            _database.CreateTableAsync<BandageChangingEntry>().Wait();
            _database.CreateTableAsync<BloodWithdrawalEntry>().Wait();
            _database.CreateTableAsync<CatheterFlushEntry>().Wait();
            _database.CreateTableAsync<InfusionEntry>().Wait();
            _database.CreateTableAsync<MicroClaveChangingEntry>().Wait();

            // PICC
            _database.CreateTableAsync<PICC>().Wait();
            _database.CreateTableAsync<PICCModel>().Wait();
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
            List<JournalEntry> resultList = new List<JournalEntry>();

            // Collect all journalEntries together
            resultList.AddRange(await _database.Table<AdministeredDrugEntry>().ToListAsync());
            resultList.AddRange(await _database.Table<StatlockChangingEntry>().ToListAsync());
            resultList.AddRange(await _database.Table<BandageChangingEntry>().ToListAsync());
            resultList.AddRange(await _database.Table<BloodWithdrawalEntry>().ToListAsync());
            resultList.AddRange(await _database.Table<CatheterFlushEntry>().ToListAsync());
            resultList.AddRange(await _database.Table<InfusionEntry>().ToListAsync());
            resultList.AddRange(await _database.Table<MicroClaveChangingEntry>().ToListAsync());

            return resultList;
        }

        public Task<List<T>> GetJournalEntriesAsync<T>() where T : JournalEntry, new()
        {
            return _database.Table<T>().ToListAsync();
        }

        public Task<T> GetJournalEntryAsync<T>(string ID) where T : JournalEntry, new()
        {
            return _database.Table<T>().Where((x) => x.ID == ID).FirstOrDefaultAsync();
        }

        public Task<int> SaveJournalEntryAsync<T>(T entry) where T : JournalEntry, new()
        {
            Task<int> res;
            if (String.IsNullOrEmpty(entry.ID))
            {
                // create the ID
                entry.ID = Guid.NewGuid().ToString();
                res = _database.InsertAsync(entry);
            }
            else
            {
                res = _database.UpdateAsync(entry);
            }

            return res;
        }

        public Task<int> DeleteJournalEntryAsync<T>(T entry) where T : JournalEntry, new()
        {
            return _database.DeleteAsync(entry);
        }

        #endregion

        #region PICCs

        public async Task<List<PICC>> GetFormerPICCsAsync()
        {
            var formerPiccs = await _database.Table<PICC>().Where((x) => x.RemovalDate != null).ToListAsync();
            foreach (var formerPicc in formerPiccs)
            {
                formerPicc.PICCModel = await _database.Table<PICCModel>().Where((x) => x.ID == formerPicc.PICCModelID).FirstOrDefaultAsync();
            }

            return formerPiccs;
        }

        public async Task<PICC> GetCurrentPICCAsync()
        {
            var currentPicc = await _database.Table<PICC>().Where((x) => x.RemovalDate == null).FirstOrDefaultAsync();
            if (currentPicc != null)
            {
                currentPicc.PICCModel = await _database.Table<PICCModel>().Where((x) => x.ID == currentPicc.PICCModelID).FirstOrDefaultAsync();
            }

            return currentPicc;
        }

        public async Task<PICC> GetPICCAsync(string ID)
        {
            var foundPicc = await _database.Table<PICC>().Where((x) => x.ID == ID).FirstOrDefaultAsync();
            if (foundPicc != null)
            {
                foundPicc.PICCModel = await _database.Table<PICCModel>().Where((x) => x.ID == foundPicc.PICCModelID).FirstOrDefaultAsync();
            }

            return foundPicc;
        }

        public async Task<int> SaveCurrentPICCAsync(PICC savingPicc)
        {
            // Check if a new PICC is set as current or if the current picc is only modified
            var currentPicc = await _database.Table<PICC>().Where((x) => x.RemovalDate == null).FirstOrDefaultAsync();
            if (currentPicc == null || currentPicc.ID != savingPicc.ID)
            {
                // If the user has not removed the previous PICC, a removal date will be set to it (otherwise we would have two current PICCs)
                if (currentPicc != null)
                {
                    currentPicc.RemovalDate = DateTimeOffset.Now.Date.ToLocalTime();
                    await _database.UpdateAsync(currentPicc);
                }

                // Adding the PICCModel and the PICC
                var piccModelGuid = Guid.NewGuid().ToString();
                savingPicc.PICCModel.ID = piccModelGuid;
                savingPicc.PICCModelID = piccModelGuid;
                savingPicc.ID = Guid.NewGuid().ToString();
                await _database.InsertAsync(savingPicc.PICCModel);
                await _database.InsertAsync(savingPicc);
            }
            else
            {
                await _database.UpdateAsync(savingPicc.PICCModel);
                await _database.UpdateAsync(savingPicc);
            }

            return 1;
        }

        public Task<int> DeltePICCAsync(PICC picc)
        {
            if (picc.PICCModel != null)
            {
                _database.DeleteAsync(picc.PICCModel);
            }
            return _database.DeleteAsync(picc);

        }
        #endregion
    }
}
