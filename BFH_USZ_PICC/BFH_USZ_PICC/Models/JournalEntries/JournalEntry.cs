using BFH_USZ_PICC.Resx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BFH_USZ_PICC.Models
{
    /// <summary>
    /// Abstract class that provides all parameters that every subclass of the JournalEntry needs to implement.
    /// </summary>
    public abstract class JournalEntry
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


        public string Icon { get; } = "icon.png";

        public string Name { get; set; }
        /// <summary>
        /// Time when the JournalEntry has been created
        /// </summary>
        public DateTime CreationDateTime { get; set; }
        /// <summary>
        /// Time when the JournalEntry procedure takes place
        /// </summary>
        public DateTime ProcedureDateTime { get; set; }
        public AllPossibleJournalEntries Entry { get; set; }
        public HealthInstitution Institution { get; set; }
        public HealthPerson Person { get; set; }

        public static ObservableCollection<JournalEntry> AllEnteredJournalEntries = new ObservableCollection<JournalEntry>();
    }
}
