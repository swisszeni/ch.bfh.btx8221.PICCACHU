using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Resx;
using Realms;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    /// <summary>
    /// Extends the JournalEntry class with two parameters (Drug, Reason) to handle special events for applied drugs.
    /// </summary>
    public class AdministeredDrugEntry : JournalEntry
    {
        public override Type RealmObjectType
        {
            get { return typeof(AdministeredDrugEntryRO); }
        }
        public string Drug { get; set; }

        public AdministeredDrugEntry() { }

        public AdministeredDrugEntry(AdministeredDrugEntryRO realmObject)
        {
            ID = realmObject.ID;
            CreateDate = realmObject.CreateDate;
            ExecutionDate = realmObject.ExecutionDate;
            SupportingInstitution = (HealthInstitution)realmObject.SupportingInstitution;
            SupportingPerson = (HealthPerson)realmObject.SupportingPerson;
            Drug = realmObject.Drug;
        }
    }

    public class AdministeredDrugEntryRO : RealmObject, ILoadableRealmObject
    {
        // Base JournalEntry values
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset ExecutionDate { get; set; }
        public int SupportingInstitution { get; set; }
        public int SupportingPerson { get; set; }

        // Typespecific values
        public string Drug { get; set; }

        public void LoadDataFromModelObject(JournalEntry model)
        {
            if (model.GetType() == typeof(AdministeredDrugEntry))
            {
                var modelObject = (AdministeredDrugEntry)model;
                ID = modelObject.ID;
                CreateDate = modelObject.CreateDate;
                ExecutionDate = modelObject.ExecutionDate;
                SupportingInstitution = (int)modelObject.SupportingInstitution;
                SupportingPerson = (int)modelObject.SupportingPerson;
                Drug = modelObject.Drug;
            }
            else
            {
                // Passed wrong model to load from
                throw new InvalidCastException();
            }
        }
    } 
}
