using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public enum MicroClaveChangementReason
    {
        NoInformation,
        Pollution,
        Routine        
    }

    /// <summary>
    /// Extends the JournalEntry class with one parameters (MicroClaveChangementReason) to handle special events for the MicroClave changing procedure.
    /// </summary>
    public class MicroClaveChangingEntry : JournalEntry
    {
        public MicroClaveChangementReason Reason { get; set; }

        public MicroClaveChangingEntry()
        {
            CreationDateTime = DateTimeOffset.Now;
            ProcedureDateTime = DateTimeOffset.Now;
            Institution = HealthInstitution.NoInformation;
            Person = HealthPerson.NoInformation;
            Reason = MicroClaveChangementReason.NoInformation;

            Entry = AllPossibleJournalEntries.MicroClaveEntry;
        }

        public MicroClaveChangingEntry(DateTimeOffset creationalDateTime, DateTimeOffset procedureDateTime, HealthInstitution institution, HealthPerson person, MicroClaveChangementReason reason)
        {
            ID = Guid.NewGuid().ToString();

            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = institution;
            Person = person;
            Reason = reason;

            Entry = AllPossibleJournalEntries.MicroClaveEntry;
        }

        public MicroClaveChangingEntry(MicroClaveChangingEntryRO realmObject)
        {
            ID = realmObject.ID;
            CreationDateTime = realmObject.CreationDateTime;
            ProcedureDateTime = realmObject.ProcedureDateTime;
            Institution = (HealthInstitution)realmObject.Institution;
            Person = (HealthPerson)realmObject.Person;
            Reason = (MicroClaveChangementReason)realmObject.Reason;
            Entry = (AllPossibleJournalEntries)realmObject.Entry;
        }
    }

    public class MicroClaveChangingEntryRO : RealmObject
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

        public void LoadDataFromModelObject(MicroClaveChangingEntry modelObject)
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
