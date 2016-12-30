using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public enum InfusionType
    {
        NoInformation,
        Antibiotic,
        NutritionalSubstance,
        BloodComponent,
        ExaminationSubstance,
        Chemotherapy,
        Other

    }

    public enum InfusionAdministration
    {   
        NoInformation,
        WithoutProblem,
        WithResistance,
        NotPossible
    }

    /// <summary>
    /// Extends the JournalEntry class with two parameters (InfusionType, Medication) to handle special events for the infusion procedure
    /// </summary>
    public class InfusionEntry : JournalEntry
    {
        public InfusionType Type { get; set; }

        //Name of the antibiotic type if the the enum "InfusionType" is "Antibiotic" 
        public string TypeAntibioticName { get; set; }
        public InfusionAdministration Administration { get; set; }

        public InfusionEntry()
        {
            CreationDateTime = DateTimeOffset.Now;
            ProcedureDateTime = DateTimeOffset.Now;
            Institution = HealthInstitution.NoInformation;
            Person = HealthPerson.NoInformation;
            Type = InfusionType.NoInformation;
            Administration = InfusionAdministration.NoInformation;
            TypeAntibioticName = null;

            Entry = AllPossibleJournalEntries.InfusionEntry;
        }


        public InfusionEntry(DateTimeOffset creationalDateTime, DateTimeOffset procedureDateTime, HealthInstitution institution, HealthPerson person, InfusionType type, 
            InfusionAdministration administration, string antibioticName)
        {
            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = institution;
            Person = person;
            Type = type;
            Administration = administration;
            TypeAntibioticName = antibioticName;

            Entry = AllPossibleJournalEntries.InfusionEntry;

        }

    }
}
