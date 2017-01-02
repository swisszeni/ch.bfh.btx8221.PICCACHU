using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public enum StatLockChangementReason
    {
        NoInformation,
        Routine,
        SticksUnsatisfactorily,
        Pollution,
        DamagedWing
    }
    /// <summary>
    /// Extends the JournalEntry class with one parameter (StatLockChangementReason) to handle special events for the StatLock changing procedure.
    /// </summary>
    public class StatlockChangingEntry : JournalEntry
    {     

        public StatLockChangementReason Reason { get; set; }

        public StatlockChangingEntry()
        {
            CreationDateTime = DateTimeOffset.Now;
            ProcedureDateTime = DateTimeOffset.Now;
            Institution = HealthInstitution.NoInformation;
            Person = HealthPerson.NoInformation;
            Reason = StatLockChangementReason.NoInformation;

            Entry = AllPossibleJournalEntries.StatlockEntry;
        }

        public StatlockChangingEntry(DateTimeOffset creationalDateTime, DateTimeOffset procedureDateTime, HealthInstitution institution, HealthPerson person, StatLockChangementReason reason)
        {
            ID = Guid.NewGuid().ToString();

            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = institution;
            Person = person;
            Reason = reason;

            Entry = AllPossibleJournalEntries.StatlockEntry;
        }

        public StatlockChangingEntry(StatlockChangingEntryRO realmObject)
        {
            ID = realmObject.ID;
            CreationDateTime = realmObject.CreationDateTime;
            ProcedureDateTime = realmObject.ProcedureDateTime;
            Institution = (HealthInstitution)realmObject.Institution;
            Person = (HealthPerson)realmObject.Person;
            Reason = (StatLockChangementReason) realmObject.Reason;
            Entry = (AllPossibleJournalEntries)realmObject.Entry;

        }

    }

    public class StatlockChangingEntryRO : RealmObject
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
        public int Reason { get; set; }

        public void LoadDataFromModelObject(StatlockChangingEntry modelObject)
        {
            ID = modelObject.ID;
            CreationDateTime = modelObject.CreationDateTime;
            ProcedureDateTime = modelObject.ProcedureDateTime;
            Institution = (int)modelObject.Institution;
            Person = (int)modelObject.Person;
            Reason = (int)modelObject.Reason;

            Entry = (int)modelObject.Entry;
        }
    }
}
