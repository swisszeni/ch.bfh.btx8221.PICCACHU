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
        public override Type RealmObjectType
        {
            get { return typeof(InfusionEntryRO); }
        }

        public InfusionType InfusionType { get; set; }
        //Name of the antibiotic type if the the enum "InfusionType" is "Antibiotic" 
        public string TypeAntibioticName { get; set; }
        public InfusionAdministration Administration { get; set; }

        public InfusionEntry() { }

        public InfusionEntry(InfusionEntryRO realmObject)
        {
            ID = realmObject.ID;
            CreateDate = realmObject.CreateDate;
            ExecutionDate = realmObject.ExecutionDate;
            SupportingInstitution = (HealthInstitution)realmObject.SupportingInstitution;
            SupportingPerson = (HealthPerson)realmObject.SupportingPerson;
            InfusionType = (InfusionType)realmObject.InfusionType;
            TypeAntibioticName = realmObject.TypeAntibioticName;
            Administration = (InfusionAdministration)realmObject.Administration;
        }

    }

    public class InfusionEntryRO : RealmObject
    {
        // Base JournalEntry values
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset ExecutionDate { get; set; }
        public int SupportingInstitution { get; set; }
        public int SupportingPerson { get; set; }

        // Typespecific values
        public int InfusionType { get; set; }
        // Name of the antibiotic type if the the enum "InfusionType" is "Antibiotic" 
        public string TypeAntibioticName { get; set; }
        public int Administration { get; set; }


        public void LoadDataFromModelObject(InfusionEntry modelObject)
        {
            ID = modelObject.ID;
            CreateDate = modelObject.CreateDate;
            ExecutionDate = modelObject.ExecutionDate;
            SupportingInstitution = (int)modelObject.SupportingInstitution;
            SupportingPerson = (int)modelObject.SupportingPerson;
            InfusionType = (int)modelObject.InfusionType;
            TypeAntibioticName = modelObject.TypeAntibioticName;
            Administration = (int)modelObject.Administration;
        }
    }
}
