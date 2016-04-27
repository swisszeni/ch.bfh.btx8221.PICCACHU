using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public class KnowledgeEntryTypeGroup : List<KnowledgeEntry>
    {
            public string Title { get; set; }
            public string ShortName { get; set; } //will be used for jump lists
            public string Subtitle { get; set; }
            public KnowledgeEntryTypeGroup(string title, string shortName)
            {
                Title = title;
                ShortName = shortName;
            }
      
    }
}
