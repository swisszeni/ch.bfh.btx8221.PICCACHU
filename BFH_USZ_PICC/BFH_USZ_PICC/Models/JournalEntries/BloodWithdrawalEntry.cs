using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    /// <summary>
    /// Extends the JournalEntry class with two parameters (IsNaCiFlashDone, Flow) to handle special events for the blood withrawal procedure
    /// </summary>
    class BloodWithdrawalEntry : JournalEntry
    {
        public enum BloodFlow
        {
            Speedy,
            Hesitatnt,
            None
        }
        public override DateTime CreationDateTime { get; }
        public override DateTime ProcedureDateTime { get; set; }
        public override HealthInstitution Institution { get; set; }
        public override HealthPerson Person { get; set; }

        public bool IsNaCiFlashDone { get; set; }
        public BloodFlow Flow { get; set; }        

        public BloodWithdrawalEntry(DateTime CreationalDateTime, DateTime ProcedureDateTime, HealthInstitution Instiution, HealthPerson Person, bool IsNaCiFlashDone, BloodFlow Flow )
        {
            this.CreationDateTime = CreationalDateTime;
            this.ProcedureDateTime = ProcedureDateTime;
            this.Institution = Institution;
            this.Person = Person;
            this.IsNaCiFlashDone = IsNaCiFlashDone;
            this.Flow = Flow;

        }

    }
}
