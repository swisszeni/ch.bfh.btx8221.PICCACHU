using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Interfaces
{
    public interface ILocalUserDataService
    {
        Task ResetLocalUserDataAsync();

        // MasterData
        Task<List<UserMasterData>> GetMasterDataAsync();
        Task<int> SaveMasterDataAsync(UserMasterData masterData);
        Task<int> DeleteAllMasterDataAsync();
        Task<int> DeleteMasterDataAsync(UserMasterData masterData);

        // JournalEntry
        Task<List<JournalEntry>> GetJournalEntriesAsync();
        Task<int> SaveJournalEntryAsync(JournalEntry test);
        Task<int> DeleteJournalEntryAsync(JournalEntry entry);
    }
}
