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
    /// A Single Instructionstep consisting of a picture and an explanation
    /// </summary>
    public class MaintenanceInstructionStep
    {
        public MaintenanceInstructionStep() { }

        public MaintenanceInstructionStep(MaintenanceInstructionStepRO realmObject)
        {
            ID = realmObject.ID;
            PictureUri = realmObject.PictureUri;
            Explanation = new MultilingualString(realmObject.Explanation);
        }

        [SQLite.PrimaryKey]
        public string ID { get; set; }
        public string PictureUri { get; set; }
        [SQLite.Ignore]
        public MultilingualString Explanation { get; set; }
        public string ExplanationID { get; set; }
    }

    /// <summary>
    /// Corresponding Realm storage class for <see cref="MaintenanceInstructionStep"/>
    /// </summary>
    public class MaintenanceInstructionStepRO : RealmObject, ILoadableRealmObject
    {
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public string PictureUri { get; set; }
        public MultilingualStringRO Explanation { get; set; }

        public void LoadDataFromModelObject(object model)
        {
            if (model.GetType() == typeof(MaintenanceInstructionStep))
            {
                var modelObject = (MaintenanceInstructionStep)model;
                ID = modelObject.ID;
                PictureUri = modelObject.PictureUri;
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
