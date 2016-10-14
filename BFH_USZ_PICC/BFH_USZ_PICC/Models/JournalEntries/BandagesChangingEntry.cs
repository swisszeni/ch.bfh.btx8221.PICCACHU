using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    /// <summary>
    /// Extends the JournalEntry class with four parameters (ChangementReason, ChangementArea, PunctureSituation, ArmProcessSituation) to handle special events for the bandages changing procedure.
    /// </summary>
    class BandagesChangingEntry : JournalEntry
    {
        public enum ChangementReason
        {
            Routine,
            PunctureNotCovered,
            BandageWet,
            BandageDoesNotStickAnymore,
            SecondaryBleeding,
            Pain

        }

        public enum ChangementArea
        {
            Complete,
            OnlyBandage,
            OnlyStatlock

        }

        public enum PunctureSituation
        {
            SkinNotIrritant,
            ReddenedPuncture,
            SwollenPuncture,
            PainfulPuncture,
            LiquidDischarge
        }

        public enum ArmProcessSituation
        {
            Painful,
            Swollen,
            Reddended           
        }
        
        public override DateTime CreationDateTime { get; }
        public override DateTime ProcedureDateTime { get; set; }
        public override HealthInstitution Institution { get; set; }
        public override HealthPerson Person { get; set; }

        public ChangementReason Reason { get; set; }
        public ChangementArea Area { get; set; }
        public PunctureSituation Puncture { get; set; }
        public ArmProcessSituation ArmProcess { get; set; }
        

        public BandagesChangingEntry(DateTime CreationalDateTime, DateTime ProcedureDateTime, HealthInstitution Instiution, HealthPerson Person, ChangementReason Reason, ChangementArea Area,
            PunctureSituation Puncture, ArmProcessSituation ArmProcess)
        {
            this.CreationDateTime = CreationalDateTime;
            this.ProcedureDateTime = ProcedureDateTime;
            this.Institution = Institution;
            this.Person = Person;
            this.Reason = Reason;
            this.Area = Area;
            this.Puncture = Puncture;
            this.ArmProcess = ArmProcess;

        }

    }
}
