using Realms;
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
            ID = Guid.NewGuid().ToString();

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

        public BandageChangingEntry(BandageChangingEntryRO realmObject)
        {
            ID = realmObject.ID;
            CreationDateTime = realmObject.CreationDateTime;
            ProcedureDateTime = realmObject.ProcedureDateTime;
            Institution = (HealthInstitution)realmObject.Institution;
            Person = (HealthPerson)realmObject.Person;
            Reason = (BandageChangingReason)realmObject.Reason;
            Area = (BandageChangingArea) realmObject.Area;
            Puncture = (BandagePunctureSituation) realmObject.Puncture;
            ArmProcess = (BandageArmProcessSituation) realmObject.ArmProcess;


            Entry = (AllPossibleJournalEntries)realmObject.Entry;

        }

    }

    public class BandageChangingEntryRO : RealmObject
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
        public int Area { get; set; }
        public int Puncture { get; set; }
        public int ArmProcess { get; set; }


        public void LoadDataFromModelObject(BandageChangingEntry modelObject)
        {
            ID = modelObject.ID;
            CreationDateTime = modelObject.CreationDateTime;
            ProcedureDateTime = modelObject.ProcedureDateTime;
            Institution = (int)modelObject.Institution;
            Person = (int)modelObject.Person;
            Reason = (int)modelObject.Reason;
            Area = (int)modelObject.Area;
            Puncture = (int)modelObject.Puncture;
            ArmProcess = (int)modelObject.ArmProcess;

            Entry = (int)modelObject.Entry;
        }
    }
}
