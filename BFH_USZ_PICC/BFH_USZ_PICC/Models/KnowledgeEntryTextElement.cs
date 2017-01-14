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
    /// Text element from a <see cref="KnowledgeEntry"/>, contains the multilingual text and the index of it
    /// </summary>
    public class KnowledgeEntryTextElement : IKnowledgeEntryElement
    {
        public KnowledgeEntryTextElement() { }
        public KnowledgeEntryTextElement(KnowledgeEntryTextElementRO realmObject)
        {
            ID = realmObject.ID;
            Text = new MultilingualString(realmObject.Text);
            ElementIndex = realmObject.ElementIndex;
        }

        [SQLite.PrimaryKey]
        public string ID { get; set; }
        [SQLite.Ignore]
        public MultilingualString Text { get; set; }
        public string TextID { get; set; }
        public int ElementIndex { get; set; }
        public object Element => Text;
    }

    /// <summary>
    /// Corresponding Realm storage class for <see cref="KnowledgeEntryTextElement"/>
    /// </summary>
    public class KnowledgeEntryTextElementRO : RealmObject, ILoadableRealmObject
    {
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public MultilingualStringRO Text { get; set; }
        public int ElementIndex { get; set; }

        public void LoadDataFromModelObject(object model)
        {
            if (model.GetType() == typeof(KnowledgeEntryTextElement))
            {
                var modelObject = (KnowledgeEntryTextElement)model;
                ID = modelObject.ID;
                if (Text == null)
                {
                    Text = new MultilingualStringRO();
                }
                Text.LoadDataFromModelObject(modelObject.Text);
                ElementIndex = modelObject.ElementIndex;
            }
            else
            {
                // Passed wrong model to load from
                throw new InvalidCastException();
            }
        }
    }
}
