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
    /// Instruction to perform a Maintenance. Consists of different <see cref="MaintenanceInstructionStep"/>
    /// </summary>
    public class MaintenanceInstruction : IKnowledgeBaseEntry
    {
        public MaintenanceInstruction() { InstructionSteps = new List<MaintenanceInstructionStep>(); }

        public MaintenanceInstruction(MaintenanceInstructionRO realmObject)
        {
            ID = realmObject.ID;
            Group = new MultilingualString(realmObject.Group);
            Title = new MultilingualString(realmObject.Title);
            InstructionSteps = new List<MaintenanceInstructionStep>();
            foreach (var stepRO in realmObject.InstructionSteps)
            {
                InstructionSteps.Add(new MaintenanceInstructionStep(stepRO));
            }
        }

        [SQLite.PrimaryKey]
        public string ID { get; set; }
        public string LocalizedGroup => Group.GetString();
        public MultilingualString Group { get; set; }
        public string LocalizedTitle => Title.GetString();
        public MultilingualString Title { get; set; }
        public List<MaintenanceInstructionStep> InstructionSteps { get; set; }
    }

    /// <summary>
    /// Corresponding Realm storage class for <see cref="MaintenanceInstruction"/>
    /// </summary>
    public class MaintenanceInstructionRO : RealmObject, ILoadableRealmObject
    {
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public MultilingualStringRO Group { get; set; }
        public MultilingualStringRO Title { get; set; }
        public IList<MaintenanceInstructionStepRO> InstructionSteps { get; }

        public void LoadDataFromModelObject(object model)
        {
            if (model.GetType() == typeof(MaintenanceInstruction))
            {
                var modelObject = (MaintenanceInstruction)model;
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

                // The InstructionSteps
                // Existing List
                foreach (var step in modelObject.InstructionSteps)
                {
                    if (InstructionSteps.Where((x) => x.ID == step.ID).Count() > 0)
                    {
                        // Contained in List
                        var existingRO = InstructionSteps.FirstOrDefault((x) => x.ID == step.ID);
                        existingRO.LoadDataFromModelObject(step);
                    }
                    else
                    {
                        // Add to list
                        var stepRO = new MaintenanceInstructionStepRO();
                        stepRO.LoadDataFromModelObject(step);
                        InstructionSteps.Add(stepRO);
                    }
                }
            }
            else
            {
                // Passed wrong model to load from
                throw new InvalidCastException();
            }
        }
    }
}
