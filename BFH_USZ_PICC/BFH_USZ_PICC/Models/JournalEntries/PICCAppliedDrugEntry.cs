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
        public string Drug { get; set; }
        public string Reason { get; set; }
        
        public PICCAppliedDrugEntry(DateTime creationalDateTime, DateTime procedureDateTime, HealthInstitution instiution, HealthPerson person, string drug, string reason)
        {
            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = instiution;
            Person = person;
            Drug = drug;
            Reason = reason;

        }

    }
}
