using Realms;
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
            ID = Guid.NewGuid().ToString();

            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = institution;
            Person = person;
            Type = type;
            Administration = administration;
            TypeAntibioticName = antibioticName;

            Entry = AllPossibleJournalEntries.InfusionEntry;

        }

        public InfusionEntry(InfusionEntryRO realmObject)
        {
            ID = realmObject.ID;
            CreationDateTime = realmObject.CreationDateTime;
            ProcedureDateTime = realmObject.ProcedureDateTime;
            Institution = (HealthInstitution)realmObject.Institution;
            Person = (HealthPerson)realmObject.Person;
            Type = (InfusionType)realmObject.Type;
            TypeAntibioticName = realmObject.TypeAntibioticName;
            Administration = (InfusionAdministration)realmObject.Administration;


            Entry = (AllPossibleJournalEntries)realmObject.Entry;

        }

    }

    public class InfusionEntryRO : RealmObject
    {
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public string Icon { get; } = "placeholder.png";
        /// <summary>
        /// Time when the JournalEntry has been created
        /// </summary>
        public DateTimeOffset CreationDateTime { get; set; }
        /// <summary>
        /// Time when the JournalEntry procedure takes place
        /// </summary>
        public DateTimeOffset ProcedureDateTime { get; set; }
        public int Entry { get; set; }
        public int Institution { get; set; }
        public int Person { get; set; }
        public int Type { get; set; }
        //Name of the antibiotic type if the the enum "InfusionType" is "Antibiotic" 
        public string TypeAntibioticName { get; set; }
        public int Administration { get; set; }


        public void LoadDataFromModelObject(InfusionEntry modelObject)
        {
            ID = modelObject.ID;
            CreationDateTime = modelObject.CreationDateTime;
            ProcedureDateTime = modelObject.ProcedureDateTime;
            Institution = (int)modelObject.Institution;
            Person = (int)modelObject.Person;
            Type = (int)modelObject.Type;
            TypeAntibioticName = modelObject.TypeAntibioticName;
            Administration = (int)modelObject.Administration;

            Entry = (int)modelObject.Entry;
        }
    }
}
