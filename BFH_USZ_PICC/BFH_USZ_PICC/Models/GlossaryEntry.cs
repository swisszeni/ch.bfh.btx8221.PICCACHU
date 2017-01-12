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
    /// Glossary Entry with a word and the corresponding explanation
    /// </summary>
    public class GlossaryEntry
    {
        public GlossaryEntry() { }

        public GlossaryEntry(GlossaryEntryRO realmObject)
        {
            ID = realmObject.ID;
            Word = new MultilingualString(realmObject.Word);
            Explanation = new MultilingualString(realmObject.Explanation);
        }

        [SQLite.PrimaryKey]
        public string ID { get; set; }
        [SQLite.Ignore]
        public MultilingualString Word { get; set; }
        public string WordID { get; set; }
        [SQLite.Ignore]
        public MultilingualString Explanation { get; set; }
        public string ExplanationID { get; set; }
    }

    /// <summary>
    /// Corresponding Realm storage class for <see cref="GlossaryEntry"/>
    /// </summary>
    public class GlossaryEntryRO : RealmObject, ILoadableRealmObject
    {
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public MultilingualStringRO Word { get; set; }
        public MultilingualStringRO Explanation { get; set; }

        public void LoadDataFromModelObject(object model)
        {
            if (model.GetType() == typeof(GlossaryEntry))
            {
                var modelObject = (GlossaryEntry)model;
                ID = modelObject.ID;
                if (Word == null)
                {
                    Word = new MultilingualStringRO();
                }
                Word.LoadDataFromModelObject(modelObject.Word);

                if (Explanation == null)
                {
                    Explanation = new MultilingualStringRO();
                }
                Explanation.LoadDataFromModelObject(modelObject.Explanation);
            }
            else
            {
                // Passed wrong model to load from
                throw new InvalidCastException();
            }
        }
    }
}
