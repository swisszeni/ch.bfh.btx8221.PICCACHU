using BFH_USZ_PICC.Resx;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BFH_USZ_PICC.Models
{
    public enum JournalEntryType
    {
        BandagesChangingEntry,
        BloodWithdrawalEntry,
        CatheterFlushEntry,
        InfusionEntry,
        MicroClaveEntry,
        AdministeredDrugEntry,
        StatlockEntry
    }

    public enum HealthInstitution
    {
        NoInformation,
        Hospital,
        Ambulatory,
        Rehabilitation,
        HomeCare,
        Others
    }

    public enum HealthPerson
    {
        NoInformation,
        FamilyDoctor,
        Specialist,
        NursingStaff,
        XRayStaff,
        MedicalTechnicalAssistant,
        HealthExpertStaff,
        Relative,
        AffectedPerson,
        Others
    }
    /// <summary>
    /// Abstract class that provides all parameters that every subclass of the JournalEntry needs to implement.
    /// </summary>
    public abstract class JournalEntry
    {
        [SQLite.Ignore]
        public virtual Type RealmObjectType { get; }

        [SQLite.PrimaryKey]
        public string ID { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset ExecutionDate { get; set; }
        public HealthInstitution SupportingInstitution { get; set; }
        public HealthPerson SupportingPerson { get; set; }
    }    
}

