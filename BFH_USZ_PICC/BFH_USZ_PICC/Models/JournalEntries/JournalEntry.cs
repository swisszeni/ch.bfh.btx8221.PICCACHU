using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{   
    /// <summary>
    /// Abstract class that provides all parameters that every subclass of the JournalEntry needs to implement.
    /// </summary>
    abstract class JournalEntry
    {   
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

        /// <summary>
        /// Time when the JournalEntry has been created
        /// </summary>
        public abstract DateTime CreationDateTime { get; }
        /// <summary>
        /// Time when the JournalEntry procedure takes place
        /// </summary>
        public abstract DateTime ProcedureDateTime { get; set; }
        public abstract HealthInstitution Institution { get; set; }
        public abstract HealthPerson Person { get; set; }

    }
}
