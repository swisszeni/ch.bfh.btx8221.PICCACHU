using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    /// <summary>
    /// Extends the JournalEntry class with one parameters (StatLockChangementReason) to handle special events for the StatLock changing procedure.
    /// </summary>
    class StatlockChangingEntry : JournalEntry
    {
        public enum StatLockChangementReason
        {
            Routine,
            Pollution,
            SticksNotGoodEnough,
            DamagedWing
        }
        
        public override DateTime CreationDateTime { get; }
        public override DateTime ProcedureDateTime { get; set; }
        public override HealthInstitution Institution { get; set; }
        public override HealthPerson Person { get; set; }

        public StatLockChangementReason Reason { get; set; }        

        public StatlockChangingEntry(DateTime CreationalDateTime, DateTime ProcedureDateTime, HealthInstitution Instiution, HealthPerson Person, StatLockChangementReason Reason)
        {
            this.CreationDateTime = CreationalDateTime;
            this.ProcedureDateTime = ProcedureDateTime;
            this.Institution = Institution;
            this.Person = Person;
            this.Reason = Reason;
           
        }

    }
}
