using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public class KnowledgeEntryTextElement : IKnowledgeEntryElement
    {
        string text;

        public KnowledgeEntryTextElement(string aText)
        {
            text = aText;
        }

        object IKnowledgeEntryElement.element
        {
            get
            {
                return text;
            }
        }

        string IKnowledgeEntryElement.type
        {
            get
            {
                return "text";
            }
        }
    }
}
