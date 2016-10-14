using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    /// <summary>
    /// Extends the JournalEntry class with two parameters (InfusionType, Medication) to handle special events for the infusion procedure
    /// </summary>
    class InfusionEntry : JournalEntry
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

        public override DateTime CreationDateTime { get; }
        public override DateTime ProcedureDateTime { get; set; }
        public override HealthInstitution Institution { get; set; }
        public override HealthPerson Person { get; set; }

        public InfusionType Type { get; set; }
        public Medication Application { get; set; }
        
        public InfusionEntry(DateTime CreationalDateTime, DateTime ProcedureDateTime, HealthInstitution Instiution, HealthPerson Person, InfusionType Type, Medication Application,
            double QuantityInMilliliter, bool IsBloodReflowVisible)
        {
            this.CreationDateTime = CreationalDateTime;
            this.ProcedureDateTime = ProcedureDateTime;
            this.Institution = Institution;
            this.Person = Person;
            this.Type = Type;
            this.Application = Application;

        }

    }
}
