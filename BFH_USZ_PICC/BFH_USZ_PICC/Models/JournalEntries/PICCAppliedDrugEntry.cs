﻿using BFH_USZ_PICC.Resx;
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
    public class PICCAppliedDrugEntry : JournalEntry
    {
        public string Drug { get; set; }
              
        public PICCAppliedDrugEntry(DateTimeOffset creationalDateTime, DateTimeOffset procedureDateTime, HealthInstitution instiution, HealthPerson person, string drug)
        {
            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = instiution;
            Person = person;
            Drug = drug;

            Entry = AllPossibleJournalEntries.PICCAppliedDrugEntry; 
        }

    }
}
