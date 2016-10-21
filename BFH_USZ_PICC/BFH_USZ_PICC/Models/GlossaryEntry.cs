using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    //This class contains a glossary entry with the word that needs to be explained and the statement
    public class GlossaryEntry
    {
        public string Word { get; set; }
        public string Explanation { get; set; }

        
        public GlossaryEntry(string word, string explanation)
        {
            Word = word;
            Explanation = explanation;
        }
    }
}
