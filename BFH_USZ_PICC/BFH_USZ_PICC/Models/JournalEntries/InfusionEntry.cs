using BFH_USZ_PICC.Interfaces;
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
        public string AntibioticName { get; set; }
        public InfusionAdministration InfusionAdministration { get; set; }

        public InfusionEntry() { }

        public InfusionEntry(InfusionEntryRO realmObject) : base(realmObject)
        {
            InfusionType = (InfusionType)realmObject.InfusionType;
            AntibioticName = realmObject.AntibioticName;
            InfusionAdministration = (InfusionAdministration)realmObject.InfusionAdministration;
        }

    }

    public class InfusionEntryRO : RealmObject, ILoadableJournalEntryRealmObject
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
        public string AntibioticName { get; set; }
        public int InfusionAdministration { get; set; }


        public void LoadDataFromModelObject(JournalEntry model)
        {
            if (model.GetType() == typeof(InfusionEntry))
            {
                var modelObject = (InfusionEntry)model;
                ID = modelObject.ID;
                CreateDate = modelObject.CreateDate;
                ExecutionDate = modelObject.ExecutionDate;
                SupportingInstitution = (int)modelObject.SupportingInstitution;
                SupportingPerson = (int)modelObject.SupportingPerson;
                InfusionType = (int)modelObject.InfusionType;
                AntibioticName = modelObject.AntibioticName;
                InfusionAdministration = (int)modelObject.InfusionAdministration;
            }
            else
            {
                // Passed wrong model to load from
                throw new InvalidCastException();
            }
        }
    }
}
