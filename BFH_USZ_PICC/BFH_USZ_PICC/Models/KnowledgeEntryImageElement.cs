using BFH_USZ_PICC.Interfaces;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Models
{
    /// <summary>
    /// Image element from a <see cref="KnowledgeEntry"/>, contains the filename of the picture, a fitting caption and the index of it
    /// </summary>
    public class KnowledgeEntryImageElement : IKnowledgeEntryElement
    {
        public KnowledgeEntryImageElement() { }

        public KnowledgeEntryImageElement(KnowledgeEntryImageElementRO realmObject)
        {
            ID = realmObject.ID;
            PictureUri = realmObject.PictureUri;
            Caption = new MultilingualString(realmObject.Caption);
            ElementIndex = realmObject.ElementIndex;
        }

        [SQLite.PrimaryKey]
        public string ID { get; set; }
        public string PictureUri { get; set; }
        [SQLite.Ignore]
        public MultilingualString Caption { get; set; }
        public string CaptionID { get; set; }
        public int ElementIndex { get; set; }
        public object Element => PictureUri;
    }

    /// <summary>
    /// Corresponding Realm storage class for <see cref="KnowledgeEntryImageElement"/>
    /// </summary>
    public class KnowledgeEntryImageElementRO : RealmObject, ILoadableRealmObject
    {
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public string PictureUri { get; set; }
        public MultilingualStringRO Caption { get; set; }
        public int ElementIndex { get; set; }

        public void LoadDataFromModelObject(object model)
        {
            if (model.GetType() == typeof(KnowledgeEntryImageElement))
            {
                var modelObject = (KnowledgeEntryImageElement)model;
                ID = modelObject.ID;
                PictureUri = modelObject.PictureUri;
                if (Caption == null)
                {
                    Caption = new MultilingualStringRO();
                }
                Caption.LoadDataFromModelObject(modelObject.Caption);
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
