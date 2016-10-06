using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    //This class contains a disorder entry with the symtom, reason and action
    public class DisorderEntry
    {
        public string Keyword { get; set; }
        public string Symptom { get; set; }
        public string Reason { get; set; }
        public string Action { get; set; }


        public DisorderEntry(string keywordForSymptom, string symptom, string reason, string action)
        {
            this.Keyword = keywordForSymptom;
            this.Symptom = symptom;
            this.Reason = reason;
            this.Action = action;
        }
    }
}
