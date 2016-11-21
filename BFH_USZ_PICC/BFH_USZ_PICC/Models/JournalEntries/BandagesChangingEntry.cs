using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
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
    /// <summary>
    /// Extends the JournalEntry class with four parameters (ChangementReason, ChangementArea, PunctureSituation, ArmProcessSituation) to handle special events for the bandages changing procedure.
    /// </summary>
    class BandagesChangingEntry : JournalEntry
    {
        public ChangementReason Reason { get; set; }
        public ChangementArea Area { get; set; }
        public PunctureSituation Puncture { get; set; }
        public ArmProcessSituation ArmProcess { get; set; }
        
        public BandagesChangingEntry(DateTimeOffset creationalDateTime, DateTimeOffset procedureDateTime, HealthInstitution institution, HealthPerson person, ChangementReason reason, ChangementArea area,
            PunctureSituation puncture, ArmProcessSituation armProcess)
        {
            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = institution;
            Person = person;
            Reason = reason;
            Area = area;
            Puncture = puncture;
            ArmProcess = armProcess;

        }

    }
}
