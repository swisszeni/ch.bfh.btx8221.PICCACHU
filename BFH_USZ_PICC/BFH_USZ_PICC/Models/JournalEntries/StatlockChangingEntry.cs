using BFH_USZ_PICC.Interfaces;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public enum StatLockChangementReason
    {
        NoInformation,
        Routine,
        SticksUnsatisfactorily,
        Pollution,
        DamagedWing
    }
    /// <summary>
    /// Extends the JournalEntry class with one parameter (StatLockChangementReason) to handle special events for the StatLock changing procedure.
    /// </summary>
    public class StatlockChangingEntry : JournalEntry
    {
        public override Type RealmObjectType
        {
            get { return typeof(StatlockChangingEntryRO); }
        }

        public StatLockChangementReason ChangementReason { get; set; }

        public StatlockChangingEntry() { }

        public StatlockChangingEntry(StatlockChangingEntryRO realmObject)
        {
            ID = realmObject.ID;
            CreateDate = realmObject.CreateDate;
            ExecutionDate = realmObject.CreateDate;
            SupportingInstitution = (HealthInstitution)realmObject.SupportingInstitution;
            SupportingPerson = (HealthPerson)realmObject.SupportingPerson;
            ChangementReason = (StatLockChangementReason) realmObject.ChangementReason;
        }
    }

    public class StatlockChangingEntryRO : RealmObject, ILoadableRealmObject
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
            if (model.GetType() == typeof(StatlockChangingEntry))
            {
                var modelObject = (StatlockChangingEntry)model;
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
