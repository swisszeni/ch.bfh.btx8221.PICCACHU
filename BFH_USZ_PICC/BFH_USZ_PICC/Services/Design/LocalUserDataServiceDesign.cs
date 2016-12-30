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
        #endregion

        #region JournalEntry
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
