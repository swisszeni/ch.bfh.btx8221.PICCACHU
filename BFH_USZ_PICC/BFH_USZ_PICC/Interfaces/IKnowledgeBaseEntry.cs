using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Interfaces
{
    public interface IKnowledgeBaseEntry
    {
        string LocalizedGroup { get; }
        MultilingualString Group { get; }
        string LocalizedTitle { get; }
        MultilingualString Title { get; }
    }
}
