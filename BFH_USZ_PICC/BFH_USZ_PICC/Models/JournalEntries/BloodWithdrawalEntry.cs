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
        NoInformation,
        Speedy,
        Hesitant,
        None
    }
    /// <summary>
    /// Extends the JournalEntry class with two parameters (IsNaCiFlashDone, Flow) to handle special events for the blood withrawal procedure
    /// </summary>
    public class BloodWithdrawalEntry : JournalEntry
    {       
        public bool IsNaCiFlushDone { get; set; }
        public BloodFlow Flow { get; set; }

        public BloodWithdrawalEntry()
        {
            CreationDateTime = DateTimeOffset.Now;
            ProcedureDateTime = DateTimeOffset.Now;
            Institution = HealthInstitution.NoInformation;
            Person = HealthPerson.NoInformation;
            IsNaCiFlushDone = false;
            Flow = BloodFlow.NoInformation;

            Entry = AllPossibleJournalEntries.BloodWithdrawalEntry;

        }

        public BloodWithdrawalEntry(DateTimeOffset creationalDateTime, DateTimeOffset procedureDateTime, HealthInstitution institution, HealthPerson person, bool isNaCiFlushDone, BloodFlow flow )
        {
            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = institution;
            Person = person;
            IsNaCiFlushDone = isNaCiFlushDone;
            Flow = flow;

            Entry = AllPossibleJournalEntries.BloodWithdrawalEntry;

        }

    }
}
