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
    }
}
