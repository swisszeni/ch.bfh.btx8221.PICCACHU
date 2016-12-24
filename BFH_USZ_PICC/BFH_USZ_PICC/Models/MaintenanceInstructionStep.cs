using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
   
    public class MaintenanceInstructionStep
    {
        public string ImageUrl { get; set; }
        public string Explanation { get; set; }

        
        public MaintenanceInstructionStep(string imageUrl, string explanation)
        {
            ImageUrl = imageUrl;
            Explanation = explanation;
        }
    }
}
