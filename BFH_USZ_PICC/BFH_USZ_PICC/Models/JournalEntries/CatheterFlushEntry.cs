using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public enum FlushType
    {   
        NoInformation,
        NaCi,
        Heparin,
        Urokinase
    }

    public enum FlushReason
    {
        NoInformation,
        Routine,
        BloodSampling,
        PartiallyBlocked,
        Blocked
    }


    public enum FlushResult
    {
        NoInformation,
        FlushWithoutResistance,
        FlushWithResistance,
        FlushNotPossible

    }

    /// <summary>
    /// Extends the JournalEntry class with four parameters (FlushReason, FlushResult, QuantityInMilliliter, IsBloodReflowVisible) to handle special events for the blood catheter flush procedure
    /// </summary>
    public class CatheterFlushEntry : JournalEntry
    {
        public FlushType Type { get; set; }
        public FlushReason Reason { get; set; }
        public FlushResult Result { get; set; }
        public double QuantityInMilliliter { get; set; }
        public bool IsBloodReflowVisible { get; set; }

        public CatheterFlushEntry()
        {
            CreationDateTime = DateTimeOffset.Now;
            ProcedureDateTime = DateTimeOffset.Now;
            Institution = HealthInstitution.NoInformation;
            Person = HealthPerson.NoInformation;
            Type = FlushType.NoInformation;
            Reason = FlushReason.NoInformation;
            Result = FlushResult.NoInformation;
            QuantityInMilliliter = 0;
            IsBloodReflowVisible = false;

            Entry = AllPossibleJournalEntries.CatheterFlushEntry;
        }

        public CatheterFlushEntry(DateTimeOffset creationalDateTime, DateTimeOffset procedureDateTime, HealthInstitution institution, HealthPerson person, FlushType type, FlushResult result,
            FlushReason reason, double quantityInMilliliter, bool isBloodReflowVisible)
        {
            ID = Guid.NewGuid().ToString();

            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = institution;
            Person = person;
            Type = type;
            Reason =  reason;
            Result = result;
            QuantityInMilliliter = quantityInMilliliter;
            IsBloodReflowVisible = isBloodReflowVisible;

            Entry = AllPossibleJournalEntries.CatheterFlushEntry;
        }

        public CatheterFlushEntry(CatheterFlushEntryRO realmObject)
        {
            ID = realmObject.ID;
            CreationDateTime = realmObject.CreationDateTime;
            ProcedureDateTime = realmObject.ProcedureDateTime;
            Institution = (HealthInstitution)realmObject.Institution;
            Person = (HealthPerson)realmObject.Person;
            Type = (FlushType)realmObject.Type;
            Reason = (FlushReason)realmObject.Reason;
            Result = (FlushResult)realmObject.Result;
            QuantityInMilliliter = realmObject.QuantityInMilliliter;
            IsBloodReflowVisible = realmObject.IsBloodReflowVisible;

            Entry = (AllPossibleJournalEntries)realmObject.Entry;

        }

    }

    public class CatheterFlushEntryRO : RealmObject
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
        public int Type { get; set; }
        public int Reason { get; set; }
        public int Result { get; set; }
        public double QuantityInMilliliter { get; set; }
        public bool IsBloodReflowVisible { get; set; }

        public void LoadDataFromModelObject(CatheterFlushEntry modelObject)
        {
            ID = modelObject.ID;
            CreationDateTime = modelObject.CreationDateTime;
            ProcedureDateTime = modelObject.ProcedureDateTime;
            Institution = (int)modelObject.Institution;
            Person = (int)modelObject.Person;
            Type = (int)modelObject.Type;
            Reason = (int)modelObject.Reason;
            Result = (int)modelObject.Result;
            QuantityInMilliliter = modelObject.QuantityInMilliliter;
            IsBloodReflowVisible = modelObject.IsBloodReflowVisible;

            Entry = (int)modelObject.Entry;
        }
    }
}
