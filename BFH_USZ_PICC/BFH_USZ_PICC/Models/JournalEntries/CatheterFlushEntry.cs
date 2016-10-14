using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public enum FlushReason
    {
        NaCi,
        Heparin,
        Urokinase
    }

    public enum FlushResult
    {
        FlushWithoutResistance,
        FlushWithResistance,
        FlushNotPossible

    }

    /// <summary>
    /// Extends the JournalEntry class with four parameters (FlushReason, FlushResult, QuantityInMilliliter, IsBloodReflowVisible) to handle special events for the blood catheter flush procedure
    /// </summary>
    class CatheterFlushEntry : JournalEntry
    {
        public FlushReason Reason { get; set; }
        public FlushResult Result { get; set; }
        public double QuantityInMilliliter { get; set; }
        public bool IsBloodReflowVisible { get; set; }

        public CatheterFlushEntry(DateTime creationalDateTime, DateTime procedureDateTime, HealthInstitution institution, HealthPerson person, FlushReason reason, FlushResult result,
            double quantityInMilliliter, bool isBloodReflowVisible)
        {
            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = institution;
            Person = person;
            Reason = reason;
            Result = result;
            QuantityInMilliliter = quantityInMilliliter;
            IsBloodReflowVisible = isBloodReflowVisible;
        }

    }
}
