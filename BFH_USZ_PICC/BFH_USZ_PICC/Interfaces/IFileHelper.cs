using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Interfaces
{
    public interface IFileHelper
    {
        string GetLocalUserdataDatabaseFilePath(string filename);
        bool LocalUserdataDatabaseFileExists(string filename);
        string GetLocalAppdataDatabaseFilePath(string filename);
    }
}
