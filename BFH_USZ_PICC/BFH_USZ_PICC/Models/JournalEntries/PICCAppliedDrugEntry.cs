using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    /// <summary>
    /// Extends the JournalEntry class with two parameters (Drug, Reason) to handle special events for applied drugs.
    /// </summary>
    class PICCAppliedDrugEntry : JournalEntry
    {
        public override DateTime CreationDateTime { get; }
        public override DateTime ProcedureDateTime { get; set; }
        public override HealthInstitution Institution { get; set; }
        public override HealthPerson Person { get; set; }

        public string Drug { get; set; }
        public string Reason { get; set; }
        
        public PICCAppliedDrugEntry(DateTime CreationalDateTime, DateTime ProcedureDateTime, HealthInstitution Instiution, HealthPerson Person, string Drug, string Reason)
        {
            this.CreationDateTime = CreationalDateTime;
            this.ProcedureDateTime = ProcedureDateTime;
            this.Institution = Institution;
            this.Person = Person;
            this.Drug = Drug;
            this.Reason = Reason;

        }

    }
}
