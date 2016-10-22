﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public enum StatLockChangementReason
    {
        Routine,
        Pollution,
        SticksNotGoodEnough,
        DamagedWing
    }
    /// <summary>
    /// Extends the JournalEntry class with one parameters (StatLockChangementReason) to handle special events for the StatLock changing procedure.
    /// </summary>
    class StatlockChangingEntry : JournalEntry
    {      

        public StatLockChangementReason Reason { get; set; }        

        public StatlockChangingEntry(DateTime creationalDateTime, DateTime procedureDateTime, HealthInstitution institution, HealthPerson person, StatLockChangementReason reason)
        {
            CreationDateTime = creationalDateTime;
            ProcedureDateTime = procedureDateTime;
            Institution = institution;
            Person = person;
            Reason = reason;
           
        }

    }
}