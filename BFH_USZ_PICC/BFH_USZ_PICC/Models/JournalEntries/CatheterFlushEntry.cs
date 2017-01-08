using BFH_USZ_PICC.Interfaces;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public enum FlushType
    {   
        NoInformation,
        NaCi,
        Heparin,
        Urokinase
    }

    public enum FlushReason
    {
        NoInformation,
        Routine,
        BloodSampling,
        PartiallyBlocked,
        Blocked
    }


    public enum FlushResult
    {
        NoInformation,
        FlushWithoutResistance,
        FlushWithResistance,
        FlushNotPossible
    }

    /// <summary>
    /// Extends the JournalEntry class with four parameters (FlushReason, FlushResult, QuantityInMilliliter, IsBloodReflowVisible) to handle special events for the blood catheter flush procedure
    /// </summary>
    public class CatheterFlushEntry : JournalEntry
    {
        public override Type RealmObjectType
        {
            get { return typeof(CatheterFlushEntryRO); }
        }

        public FlushType FlushType { get; set; }
        public FlushReason FlushReason { get; set; }
        public FlushResult FlushResult { get; set; }
        public double QuantityInMilliliter { get; set; }
        public bool IsBloodReflowVisible { get; set; }

        public CatheterFlushEntry() { }

        public CatheterFlushEntry(CatheterFlushEntryRO realmObject) : base(realmObject)
        {
            FlushType = (FlushType)realmObject.FlushType;
            FlushReason = (FlushReason)realmObject.FlushReason;
            FlushResult = (FlushResult)realmObject.FlushResult;
            QuantityInMilliliter = realmObject.QuantityInMilliliter;
            IsBloodReflowVisible = realmObject.IsBloodReflowVisible;
        }

    }

    public class CatheterFlushEntryRO : RealmObject, ILoadableJournalEntryRealmObject
    {
        // Base JournalEntry values
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset ExecutionDate { get; set; }
        public int SupportingInstitution { get; set; }
        public int SupportingPerson { get; set; }

        // Typespecific values
        public int FlushType { get; set; }
        public int FlushReason { get; set; }
        public int FlushResult { get; set; }
        public double QuantityInMilliliter { get; set; }
        public bool IsBloodReflowVisible { get; set; }

        public void LoadDataFromModelObject(JournalEntry model)
        {
            if (model.GetType() == typeof(CatheterFlushEntry))
            {
                var modelObject = (CatheterFlushEntry)model;
                ID = modelObject.ID;
                CreateDate = modelObject.CreateDate;
                ExecutionDate = modelObject.ExecutionDate;
                SupportingInstitution = (int)modelObject.SupportingInstitution;
                SupportingPerson = (int)modelObject.SupportingPerson;
                FlushType = (int)modelObject.FlushType;
                FlushReason = (int)modelObject.FlushReason;
                FlushResult = (int)modelObject.FlushResult;
                QuantityInMilliliter = modelObject.QuantityInMilliliter;
                IsBloodReflowVisible = modelObject.IsBloodReflowVisible;
            }
            else
            {
                // Passed wrong model to load from
                throw new InvalidCastException();
            }
        }
    }
}
