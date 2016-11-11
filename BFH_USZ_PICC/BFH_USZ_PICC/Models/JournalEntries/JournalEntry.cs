using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BFH_USZ_PICC.Utilitys.AllJournalEntriesConverter;

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
            PICCAppliedDrugEntry,
            StatlockEntry
        }

        public enum HealthInstitution
        {
            None,
            Hospital,
            Ambulatory,
            Rehabilitation,
            HomeCare,            
            Others
        }

        public enum HealthPerson
        {   
            None,
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
        /// <summary>
        /// Time when the JournalEntry has been created
        /// </summary>
        public DateTime CreationDateTime { get; set; }
        /// <summary>
        /// Time when the JournalEntry procedure takes place
        /// </summary>
        public DateTime ProcedureDateTime { get; set; }
        public HealthInstitution Institution { get; set; }
        public HealthPerson Person { get; set; }

        public static AllPossibleJournalEntries AllEntries { get; }

        public static List<JournalEntry> AllEnteredJournalEntries = new List<JournalEntry>();
    }
}
