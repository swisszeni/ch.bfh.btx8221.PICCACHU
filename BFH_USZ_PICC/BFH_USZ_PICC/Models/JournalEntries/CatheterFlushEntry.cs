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
            CreationDateTime = DateTime.Now;
            ProcedureDateTime = DateTime.Now;
            Institution = HealthInstitution.NoInformation;
            Person = HealthPerson.NoInformation;
            Type = FlushType.NoInformation;
            Reason = FlushReason.NoInformation;
            Result = FlushResult.NoInformation;
            QuantityInMilliliter = 0;
            IsBloodReflowVisible = false;

            Entry = AllPossibleJournalEntries.CatheterFlushEntry;
        }

        public CatheterFlushEntry(DateTime creationalDateTime, DateTime procedureDateTime, HealthInstitution institution, HealthPerson person, FlushType type, FlushResult result,
            FlushReason reason, double quantityInMilliliter, bool isBloodReflowVisible)
        {
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

    }
}
