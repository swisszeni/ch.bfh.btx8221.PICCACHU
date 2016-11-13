﻿using System;
using System.Collections.Generic;

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

        public string Name { get; set; }
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
