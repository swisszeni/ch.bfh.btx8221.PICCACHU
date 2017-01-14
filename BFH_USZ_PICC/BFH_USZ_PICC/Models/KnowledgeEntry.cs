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
    /// Container that represents an entry with an information article. Consists of multiple elements implementing <see cref="IKnowledgeEntryElement"/>
    /// </summary>
    public class KnowledgeEntry : IKnowledgeBaseEntry
    {
        public KnowledgeEntry() { }

        public KnowledgeEntry(KnowledgeEntryRO realmObject)
        {

        }

        [SQLite.PrimaryKey]
        public string ID { get; set; }
        public string LocalizedGroup => Group.GetString();
        [SQLite.Ignore]
        public MultilingualString Group { get; set; }
        public string GroupID { get; set; }
        public string LocalizedTitle => Title.GetString();
        [SQLite.Ignore]
        public MultilingualString Title { get; set; }
        public string TitleID { get; set; }

        [SQLite.Ignore]
        public List<IKnowledgeEntryElement> KnowledgeElements { get; set; }
        [SQLite.Ignore]
        public List<GlossaryEntry> GlossaryEntries { get; set; }
    }

    /// <summary>
    /// Corresponding Realm storage class for <see cref="KnowledgeEntry"/>
    /// </summary>
    public class KnowledgeEntryRO : RealmObject, ILoadableRealmObject
    {
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public MultilingualStringRO Group { get; set; }
        public MultilingualStringRO Title { get; set; }
        public IList<KnowledgeEntryTextElementRO> TextElements { get; }
        public IList<KnowledgeEntryImageElementRO> ImageElements { get; }
        public IList<GlossaryEntryRO> GlossaryEntries { get; }

        public void LoadDataFromModelObject(object model)
        {
            if (model.GetType() == typeof(KnowledgeEntry))
            {
                var modelObject = (KnowledgeEntry)model;
                ID = modelObject.ID;
                if (Group == null)
                {
                    Group = new MultilingualStringRO();
                }
                Group.LoadDataFromModelObject(modelObject.Group);

                if (Title == null)
                {
                    Title = new MultilingualStringRO();
                }
                Title.LoadDataFromModelObject(modelObject.Title);
            }
            else
            {
                // Passed wrong model to load from
                throw new InvalidCastException();
            }
        }
    }
}
