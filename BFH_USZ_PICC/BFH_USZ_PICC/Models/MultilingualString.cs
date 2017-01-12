using BFH_USZ_PICC.Interfaces;
using Realms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    /// <summary>
    /// Stores and retreives translated strings in the database
    /// </summary>
    public class MultilingualString
    {
        // Storing the current Culture set for the App
        public static CultureInfo Culture { get; set; }

        // The implicit converter
        public static implicit operator string (MultilingualString multilingual)
        {
            return multilingual.String;
        }

        public MultilingualString() { }

        public MultilingualString(MultilingualStringRO realmObject)
        {
            ID = realmObject.ID;
            English = realmObject.English;
            German = realmObject.German;
            French = realmObject.French;
            Italian = realmObject.Italian;
        }

        [SQLite.PrimaryKey]
        public string ID { get; set; }
        public string English { get; set; }
        public string German { get; set; }
        public string French { get; set; }
        public string Italian { get; set; }

        [SQLite.Ignore]
        public string String => GetString();

        public string GetString()
        {
            var currentCulture = Culture;
            if (!currentCulture.IsNeutralCulture)
            {
                currentCulture = currentCulture.Parent;
            }

            return GetString(currentCulture);
        }

        public string GetString(CultureInfo ci)
        {
            var languageShort = ci.TwoLetterISOLanguageName;
            // If-Elese over the short since C# can't yet switch over a string
            string localizedString;
            if(languageShort == "de")
            {
                localizedString = German;
            } else if (languageShort == "fr")
            {
                localizedString = French;
            } else if (languageShort == "it")
            {
                localizedString = Italian;
            } else
            {
                // Default language fallback is EN
                localizedString = English;
            }

            return localizedString;
        }
    }

    /// <summary>
    /// Corresponding Realm storage class for <see cref="MultilingualString"/>
    /// </summary>
    public class MultilingualStringRO : RealmObject, ILoadableRealmObject
    {
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public string English { get; set; }
        public string German { get; set; }
        public string French { get; set; }
        public string Italian { get; set; }

        public void LoadDataFromModelObject(object model)
        {
            if (model.GetType() == typeof(MultilingualString))
            {
                var modelObject = (MultilingualString)model;
                ID = modelObject.ID;
                English = modelObject.English;
                German = modelObject.German;
                French = modelObject.French;
                Italian = modelObject.Italian;
            }
            else
            {
                // Passed wrong model to load from
                throw new InvalidCastException();
            }
        }
    }
}
