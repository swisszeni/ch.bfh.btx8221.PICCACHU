using Realms;
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
            ID = Guid.NewGuid().ToString();

            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = institution;
            Person = person;
            IsNaCiFlushDone = isNaCiFlushDone;
            Flow = flow;

            Entry = AllPossibleJournalEntries.BloodWithdrawalEntry;

        }

        public BloodWithdrawalEntry(BloodWithdrawalEntryRO realmObject)
        {
            ID = realmObject.ID;
            CreationDateTime = realmObject.CreationDateTime;
            ProcedureDateTime = realmObject.ProcedureDateTime;
            Institution = (HealthInstitution)realmObject.Institution;
            Person = (HealthPerson)realmObject.Person;
            IsNaCiFlushDone = realmObject.IsNaCiFlushDone;
            Flow = (BloodFlow)realmObject.Flow;

            Entry = (AllPossibleJournalEntries)realmObject.Entry;
        }

    }

    public class BloodWithdrawalEntryRO : RealmObject
    {
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public string Icon { get; } = "placeholder.png";
        /// <summary>
        /// Time when the JournalEntry has been created
        /// </summary>
        public DateTimeOffset CreationDateTime { get; set; }
        /// <summary>
        /// Time when the JournalEntry procedure takes place
        /// </summary>
        public DateTimeOffset ProcedureDateTime { get; set; }
        public int Entry { get; set; }
        public int Institution { get; set; }
        public int Person { get; set; }
        public bool IsNaCiFlushDone { get; set; }
        public int Flow { get; set; }


        public void LoadDataFromModelObject(BloodWithdrawalEntry modelObject)
        {
            ID = modelObject.ID;
            CreationDateTime = modelObject.CreationDateTime;
            ProcedureDateTime = modelObject.ProcedureDateTime;
            Institution = (int)modelObject.Institution;
            Person = (int)modelObject.Person;
            IsNaCiFlushDone = modelObject.IsNaCiFlushDone;
            Flow = (int)modelObject.Flow;

            Entry = (int)modelObject.Entry;
        }
    }
}
