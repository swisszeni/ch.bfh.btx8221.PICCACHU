using BFH_USZ_PICC.Interfaces;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public enum MicroClaveChangementReason
    {
        NoInformation,
        Pollution,
        Routine        
    }

    /// <summary>
    /// Extends the JournalEntry class with one parameters (MicroClaveChangementReason) to handle special events for the MicroClave changing procedure.
    /// </summary>
    public class MicroClaveChangingEntry : JournalEntry
    {
        public override Type RealmObjectType
        {
            get { return typeof(MicroClaveChangingEntryRO); }
        }

        public MicroClaveChangementReason ChangementReason { get; set; }

        public MicroClaveChangingEntry() { }

        public MicroClaveChangingEntry(MicroClaveChangingEntryRO realmObject)
        {
            ID = realmObject.ID;
            CreateDate = realmObject.CreateDate;
            ExecutionDate = realmObject.ExecutionDate;
            SupportingInstitution = (HealthInstitution)realmObject.SupportingInstitution;
            SupportingPerson = (HealthPerson)realmObject.SupportingPerson;
            ChangementReason = (MicroClaveChangementReason)realmObject.ChangementReason;
        }
    }

    public class MicroClaveChangingEntryRO : RealmObject, ILoadableRealmObject
    {
        // Base JournalEntry values
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset ExecutionDate { get; set; }
        public int SupportingInstitution { get; set; }
        public int SupportingPerson { get; set; }

        // Typespecific values
        public int ChangementReason { get; set; }

        public void LoadDataFromModelObject(JournalEntry model)
        {
            if (model.GetType() == typeof(MicroClaveChangingEntry))
            {
                var modelObject = (MicroClaveChangingEntry)model;
                ID = modelObject.ID;
                CreateDate = modelObject.CreateDate;
                ExecutionDate = modelObject.ExecutionDate;
                SupportingInstitution = (int)modelObject.SupportingInstitution;
                SupportingPerson = (int)modelObject.SupportingPerson;
                ChangementReason = (int)modelObject.ChangementReason;
            }
            else
            {
                // Passed wrong model to load from
                throw new InvalidCastException();
            }
        }
    }
}
