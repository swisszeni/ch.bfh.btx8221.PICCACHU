using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    /// <summary>
    /// 
    /// </summary>
    public enum BloodFlow
    {
        Speedy,
        Hesitant,
        None
    }
    /// <summary>
    /// Extends the JournalEntry class with two parameters (IsNaCiFlashDone, Flow) to handle special events for the blood withrawal procedure
    /// </summary>
    class BloodWithdrawalEntry : JournalEntry
    {       
        public bool IsNaCiFlashDone { get; set; }
        public BloodFlow Flow { get; set; }        

        public BloodWithdrawalEntry(DateTime creationalDateTime, DateTime procedureDateTime, HealthInstitution institution, HealthPerson person, bool isNaCiFlashDone, BloodFlow flow )
        {
            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = institution;
            Person = person;
            IsNaCiFlashDone = isNaCiFlashDone;
            Flow = Flow;

        }

    }
}
