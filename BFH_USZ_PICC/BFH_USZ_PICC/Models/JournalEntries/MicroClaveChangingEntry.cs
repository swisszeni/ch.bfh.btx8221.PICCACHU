using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    /// <summary>
    /// Extends the JournalEntry class with one parameters (MicroClaveChangementReason) to handle special events for the MicroClave changing procedure.
    /// </summary>
    class MicroClaveChangingEntry : JournalEntry
    {
        public enum MicroClaveChangementReason
        {
            Routine,
            Pollution
        }
        
        public override DateTime CreationDateTime { get; }
        public override DateTime ProcedureDateTime { get; set; }
        public override HealthInstitution Institution { get; set; }
        public override HealthPerson Person { get; set; }

        public MicroClaveChangementReason Reason { get; set; }        

        public MicroClaveChangingEntry(DateTime CreationalDateTime, DateTime ProcedureDateTime, HealthInstitution Instiution, HealthPerson Person, MicroClaveChangementReason Reason)
        {
            this.CreationDateTime = CreationalDateTime;
            this.ProcedureDateTime = ProcedureDateTime;
            this.Institution = Institution;
            this.Person = Person;
            this.Reason = Reason;
           
        }

    }
}
