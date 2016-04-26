using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public class KnowledgeEntry
    {
        public string title { get; }
        public List<IKnowledgeEntryElement> knowledgeElements { get; }
        public List<GlossaryEntry> glossaryEntries { get; }

        public KnowledgeEntry(string aTitle, List<IKnowledgeEntryElement> theseKnowledgeElements, List<GlossaryEntry> theseGlossaryEntries)
        {
            title = aTitle;
            knowledgeElements = theseKnowledgeElements;
            glossaryEntries = theseGlossaryEntries;
        }
    }
}
