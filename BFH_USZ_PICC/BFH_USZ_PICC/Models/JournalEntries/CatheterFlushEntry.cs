using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    /// <summary>
    /// Extends the JournalEntry class with four parameters (FlushReason, FlushResult, QuantityInMilliliter, IsBloodReflowVisible) to handle special events for the blood catheter flush procedure
    /// </summary>
    class CatheterFlushEntry : JournalEntry
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

        public override DateTime CreationDateTime { get; }
        public override DateTime ProcedureDateTime { get; set; }
        public override HealthInstitution Institution { get; set; }
        public override HealthPerson Person { get; set; }

        public FlushReason Reason { get; set; }
        public FlushResult Result { get; set; }
        public double QuantityInMilliliter { get; set; }
        public bool IsBloodReflowVisible { get; set; }

        public CatheterFlushEntry(DateTime CreationalDateTime, DateTime ProcedureDateTime, HealthInstitution Instiution, HealthPerson Person, FlushReason Reason, FlushResult Result,
            double QuantityInMilliliter, bool IsBloodReflowVisible)
        {
            this.CreationDateTime = CreationalDateTime;
            this.ProcedureDateTime = ProcedureDateTime;
            this.Institution = Institution;
            this.Person = Person;
            this.Reason = Reason;
            this.Result = Result;
            this.QuantityInMilliliter = QuantityInMilliliter;
            this.IsBloodReflowVisible = IsBloodReflowVisible;
        }

    }
}
