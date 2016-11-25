using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public enum InfusionType
    {
        Antibiotic,
        NutritionSubstance,
        BloodComponent,
        ExaminationSubstance,
        Chemotherapy,
        Other

    }

    public enum Medication
    {
        WithoutProblem,
        Fast,
        Hesitant

    }

    /// <summary>
    /// Extends the JournalEntry class with two parameters (InfusionType, Medication) to handle special events for the infusion procedure
    /// </summary>
    public class InfusionEntry : JournalEntry
    {
        public InfusionType Type { get; set; }
        public Medication Application { get; set; }
        
        public InfusionEntry(DateTimeOffset creationalDateTime, DateTimeOffset procedureDateTime, HealthInstitution institution, HealthPerson person, InfusionType type, Medication application,
            double QuantityInMilliliter, bool IsBloodReflowVisible)
        {
            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = institution;
            Person = person;
            Type = type;
            Application = application;

        }

    }
}
