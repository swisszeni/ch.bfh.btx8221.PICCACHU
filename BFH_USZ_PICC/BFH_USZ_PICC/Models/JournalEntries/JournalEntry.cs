using BFH_USZ_PICC.Resx;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BFH_USZ_PICC.Models
{
    public enum AllPossibleJournalEntries
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
        [SQLite.PrimaryKey]
        public int ID { get; set; }
        public string Icon { get; } = "placeholder.png";
        /// <summary>
        /// Time when the JournalEntry has been created
        /// </summary>
        public DateTimeOffset CreationDateTime { get; set; }
        /// <summary>
        /// Time when the JournalEntry procedure takes place
        /// </summary>
        public DateTimeOffset ProcedureDateTime { get; set; }
        public AllPossibleJournalEntries Entry { get; set; }
        public HealthInstitution Institution { get; set; }
        public HealthPerson Person { get; set; }

        public static ObservableCollection<JournalEntry> AllEnteredJournalEntries = new ObservableCollection<JournalEntry>();
    }    
}

