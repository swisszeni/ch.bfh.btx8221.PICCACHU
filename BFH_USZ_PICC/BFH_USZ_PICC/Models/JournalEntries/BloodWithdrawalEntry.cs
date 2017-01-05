using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    /// <summary>
    /// 
    /// </summary>
    public enum BloodFlow
    {   
        NoInformation,
        Speedy,
        Hesitant,
        None
    }
    /// <summary>
    /// Extends the JournalEntry class with two parameters (IsNaCiFlashDone, Flow) to handle special events for the blood withrawal procedure
    /// </summary>
    public class BloodWithdrawalEntry : JournalEntry
    {
        public override Type RealmObjectType
        {
            get { return typeof(BloodWithdrawalEntryRO); }
        }

        public bool IsNaCiFlushDone { get; set; }
        public BloodFlow Flow { get; set; }

        public BloodWithdrawalEntry() { }

        public BloodWithdrawalEntry(BloodWithdrawalEntryRO realmObject)
        {
            ID = realmObject.ID;
            CreateDate = realmObject.CreateDate;
            ExecutionDate = realmObject.ExecutionDate;
            SupportingInstitution = (HealthInstitution)realmObject.SupportingInstitution;
            SupportingPerson = (HealthPerson)realmObject.SupportingPerson;
            IsNaCiFlushDone = realmObject.IsNaCiFlushDone;
            Flow = (BloodFlow)realmObject.Flow;
        }
    }

    public class BloodWithdrawalEntryRO : RealmObject
    {
        // Base JournalEntry values
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset ExecutionDate { get; set; }
        public int SupportingInstitution { get; set; }
        public int SupportingPerson { get; set; }

        // Typespecific values
        public bool IsNaCiFlushDone { get; set; }
        public int Flow { get; set; }


        public void LoadDataFromModelObject(BloodWithdrawalEntry modelObject)
        {
            ID = modelObject.ID;
            CreateDate = modelObject.CreateDate;
            ExecutionDate = modelObject.ExecutionDate;
            SupportingInstitution = (int)modelObject.SupportingInstitution;
            SupportingPerson = (int)modelObject.SupportingPerson;
            IsNaCiFlushDone = modelObject.IsNaCiFlushDone;
            Flow = (int)modelObject.Flow;
        }
    }
}
