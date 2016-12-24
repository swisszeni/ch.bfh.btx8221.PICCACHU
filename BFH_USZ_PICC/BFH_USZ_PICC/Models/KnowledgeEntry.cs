using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public class KnowledgeEntry : IKnowledgeBaseEntry
    {
        public string Title { get; }
        public List<IKnowledgeEntryElement> KnowledgeElements { get; }
        public List<GlossaryEntry> GlossaryEntries { get; }

        public KnowledgeEntry(string aTitle, List<IKnowledgeEntryElement> theseKnowledgeElements, List<GlossaryEntry> theseGlossaryEntries)
        {
            Title = aTitle;
            KnowledgeElements = theseKnowledgeElements;
            GlossaryEntries = theseGlossaryEntries;
        }
    }
}
