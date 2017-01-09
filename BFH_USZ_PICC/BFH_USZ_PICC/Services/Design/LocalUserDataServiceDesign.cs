using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFH_USZ_PICC.Models;

namespace BFH_USZ_PICC.Services.Design
{
    public class LocalUserDataServiceDesign : ILocalUserDataService
    {
        public Task ResetLocalUserDataAsync()
        {
            throw new NotImplementedException();
        }

        #region MasterData

        public Task<int> SaveMasterDataAsync(UserMasterData masterData)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAllMasterDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteMasterDataAsync(UserMasterData masterData)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserMasterData>> GetMasterDataAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region JournalEntry

        public Task<List<JournalEntry>> GetJournalEntriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetJournalEntriesAsync<T>() where T : JournalEntry
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveJournalEntryAsync<T>(T entry) where T : JournalEntry
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteJournalEntryAsync<T>(T entry) where T : JournalEntry
        {
            throw new NotImplementedException();
        }

        public Task<T> GetJournalEntryAsync<T>(string ID) where T : JournalEntry
        {
            throw new NotImplementedException();
        }
        #endregion

        #region JournalEntry
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
