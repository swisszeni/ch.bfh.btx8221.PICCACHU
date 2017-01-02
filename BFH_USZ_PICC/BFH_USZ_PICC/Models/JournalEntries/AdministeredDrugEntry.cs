using BFH_USZ_PICC.Resx;
using Realms;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    /// <summary>
    /// Extends the JournalEntry class with two parameters (Drug, Reason) to handle special events for applied drugs.
    /// </summary>
    public class AdministeredDrugEntry : JournalEntry
    {        
        public string Drug { get; set; }

        public AdministeredDrugEntry()
        {          
            CreationDateTime = DateTimeOffset.Now;
            ProcedureDateTime = DateTimeOffset.Now;
            Institution = HealthInstitution.NoInformation;
            Person = HealthPerson.NoInformation;
            Drug = null;            
                                  
            Entry = AllPossibleJournalEntries.AdministeredDrugEntry;
        }
        public AdministeredDrugEntry(DateTimeOffset creationalDateTime, DateTimeOffset procedureDateTime, HealthInstitution instiution, HealthPerson person, string drug)
        {
            ID = Guid.NewGuid().ToString();

            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = instiution;
            Person = person;
            Drug = drug;

            Entry = AllPossibleJournalEntries.AdministeredDrugEntry;
        }

        public AdministeredDrugEntry(AdministeredDrugEntryRO realmObject)
        {
            ID = realmObject.ID;
            CreationDateTime = realmObject.CreationDateTime;
            ProcedureDateTime = realmObject.ProcedureDateTime;
            Institution = (HealthInstitution)realmObject.Institution;
            Person = (HealthPerson)realmObject.Person;
            Drug = realmObject.Drug;
            Entry = (AllPossibleJournalEntries)realmObject.Entry;
            
        }
    }

    public class AdministeredDrugEntryRO : RealmObject
    {
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public string Icon { get; } = "placeholder.png";
         /// <summary>
        /// Time when the JournalEntry has been created
        /// </summary>
        public DateTimeOffset CreationDateTime { get; set; }
        /// <summary>
        /// Time when the JournalEntry procedure takes place
        /// </summary>
        public DateTimeOffset ProcedureDateTime { get; set; }
        public int Entry { get; set; }
        public int Institution { get; set; }
        public int Person { get; set; }
        public string Drug { get; set; }

        public void LoadDataFromModelObject(AdministeredDrugEntry modelObject)
        {
            ID = modelObject.ID;
            CreationDateTime = modelObject.CreationDateTime;
            ProcedureDateTime = modelObject.ProcedureDateTime;
            Institution = (int)modelObject.Institution;
            Person = (int)modelObject.Person;
            Drug = modelObject.Drug;

            Entry = (int)modelObject.Entry;
        }
    } 
}
