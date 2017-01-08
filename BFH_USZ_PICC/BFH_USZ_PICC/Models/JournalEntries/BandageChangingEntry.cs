using BFH_USZ_PICC.Interfaces;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public enum BandageChangementReason
    {   
        NoInformation,
        Routine,
        PunctureNotCovered,
        BandageWet,
        BandageDoesNotStickAnymore,
        SecondaryBleeding,
        Pain
    }

    public enum BandageChangementArea
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
        public override Type RealmObjectType
        {
            get { return typeof(BandageChangingEntryRO); }
        }

        public BandageChangementReason ChangementReason { get; set; }
        public BandageChangementArea ChangementArea { get; set; }
        public BandagePunctureSituation Puncture { get; set; }
        public BandageArmProcessSituation ArmProcess { get; set; }


        public BandageChangingEntry() { }

        public BandageChangingEntry(BandageChangingEntryRO realmObject) : base(realmObject)
        {
            ChangementReason = (BandageChangementReason)realmObject.ChangementReason;
            ChangementArea = (BandageChangementArea) realmObject.ChangementArea;
            Puncture = (BandagePunctureSituation) realmObject.Puncture;
            ArmProcess = (BandageArmProcessSituation) realmObject.ArmProcess;
        }
    }

    public class BandageChangingEntryRO : RealmObject, ILoadableJournalEntryRealmObject
    {
        // Base JournalEntry values
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset ExecutionDate { get; set; }
        public int SupportingInstitution { get; set; }
        public int SupportingPerson { get; set; }

        // Typespecific values
        public int ChangementReason { get; set; }
        public int ChangementArea { get; set; }
        public int Puncture { get; set; }
        public int ArmProcess { get; set; }


        public void LoadDataFromModelObject(JournalEntry model)
        {
            if (model.GetType() == typeof(BandageChangingEntry))
            {
                var modelObject = (BandageChangingEntry)model;
                ID = modelObject.ID;
                CreateDate = modelObject.CreateDate;
                ExecutionDate = modelObject.ExecutionDate;
                SupportingInstitution = (int)modelObject.SupportingInstitution;
                SupportingPerson = (int)modelObject.SupportingPerson;
                ChangementReason = (int)modelObject.ChangementReason;
                ChangementArea = (int)modelObject.ChangementArea;
                Puncture = (int)modelObject.Puncture;
                ArmProcess = (int)modelObject.ArmProcess;
            }
            else
            {
                // Passed wrong model to load from
                throw new InvalidCastException();
            }
        }
    }
}
