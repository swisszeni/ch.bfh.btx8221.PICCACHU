using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{

    public enum BandageChangingReason
    {   
        NoInformation,
        Routine,
        PunctureNotCovered,
        BandageWet,
        BandageDoesNotStickAnymore,
        SecondaryBleeding,
        Pain
    }

    public enum BandageChangingArea
    {
        NoInformation,
        Complete,
        OnlyBandage,
        OnlyStatlock

    }

    public enum BandagePunctureSituation
    {
        NoInformation,
        SkinNotIrritant,
        ReddenedPuncture,
        SwollenPuncture,
        PainfulPuncture,
        LiquidDischarge
    }

    public enum BandageArmProcessSituation
    {
        NoInformation,
        Painful,
        Swollen,
        Reddended
    }
    /// <summary>
    /// Extends the JournalEntry class with four parameters (ChangementReason, ChangementArea, PunctureSituation, ArmProcessSituation) to handle special events for the bandages changing procedure.
    /// </summary>
    public class BandageChangingEntry : JournalEntry
    {
        public BandageChangingReason Reason { get; set; }
        public BandageChangingArea Area { get; set; }
        public BandagePunctureSituation Puncture { get; set; }
        public BandageArmProcessSituation ArmProcess { get; set; }


        public BandageChangingEntry()
        {
            CreationDateTime = DateTimeOffset.Now;
            ProcedureDateTime = DateTimeOffset.Now;
            Institution = HealthInstitution.NoInformation;
            Person = HealthPerson.NoInformation;
            Reason = BandageChangingReason.NoInformation;
            Area = BandageChangingArea.NoInformation;
            Puncture = BandagePunctureSituation.NoInformation;
            ArmProcess = BandageArmProcessSituation.NoInformation;

            Entry = AllPossibleJournalEntries.BandagesChangingEntry;

        }
        public BandageChangingEntry(DateTimeOffset creationalDateTime, DateTimeOffset procedureDateTime, HealthInstitution institution, HealthPerson person, BandageChangingReason reason, BandageChangingArea area,
            BandagePunctureSituation puncture, BandageArmProcessSituation armProcess)
        {
            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = institution;
            Person = person;
            Reason = reason;
            Area = area;
            Puncture = puncture;
            ArmProcess = armProcess;

            Entry = AllPossibleJournalEntries.BandagesChangingEntry;

        }

    }
}
