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
        public string symptom { get; set; }
        public string reason { get; set; }
        public string action { get; set; }


        public DisorderEntry(string symptom, string reason, string action)
        {
            this.symptom = symptom;
            this.reason = reason;
            this.action = action;
        }
    }
}
