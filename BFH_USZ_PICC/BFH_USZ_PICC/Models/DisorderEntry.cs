using BFH_USZ_PICC.Interfaces;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    /// <summary>
    /// Explains a disorder as symptom, reason and action
    /// </summary>
    public class DisorderEntry
    {
        public DisorderEntry() { }

        public DisorderEntry(DisorderEntryRO realmObject)
        {
            ID = realmObject.ID;
            Keyword = new MultilingualString(realmObject.Keyword);
            Symptom = new MultilingualString(realmObject.Symptom);
            Reason = new MultilingualString(realmObject.Reason);
            Action = new MultilingualString(realmObject.Action);
        }

        [SQLite.PrimaryKey]
        public string ID { get; set; }
        [SQLite.Ignore]
        public MultilingualString Keyword { get; set; }
        public string KeywordID { get; set; }
        [SQLite.Ignore]
        public MultilingualString Symptom { get; set; }
        public string SymptomID { get; set; }
        [SQLite.Ignore]
        public MultilingualString Reason { get; set; }
        public string ReasonID { get; set; }
        [SQLite.Ignore]
        public MultilingualString Action { get; set; }
        public string ActionID { get; set; }
    }

    /// <summary>
    /// Corresponding Realm storage class for <see cref="DisorderEntry"/>
    /// </summary>
    public class DisorderEntryRO : RealmObject, ILoadableRealmObject
    {
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public MultilingualStringRO Keyword { get; set; }
        public MultilingualStringRO Symptom { get; set; }
        public MultilingualStringRO Reason { get; set; }
        public MultilingualStringRO Action { get; set; }

        public void LoadDataFromModelObject(object model)
        {
            if (model.GetType() == typeof(DisorderEntry))
            {
                var modelObject = (DisorderEntry)model;
                ID = modelObject.ID;
                if (Keyword == null)
                {
                    Keyword = new MultilingualStringRO();
                }
                Keyword.LoadDataFromModelObject(modelObject.Keyword);

                if (Symptom == null)
                {
                    Symptom = new MultilingualStringRO();
                }
                Symptom.LoadDataFromModelObject(modelObject.Symptom);

                if (Reason == null)
                {
                    Reason = new MultilingualStringRO();
                }
                Reason.LoadDataFromModelObject(modelObject.Reason);

                if (Action == null)
                {
                    Action = new MultilingualStringRO();
                }
                Action.LoadDataFromModelObject(modelObject.Action);
            }
            else
            {
                // Passed wrong model to load from
                throw new InvalidCastException();
            }
        }
    }
}
