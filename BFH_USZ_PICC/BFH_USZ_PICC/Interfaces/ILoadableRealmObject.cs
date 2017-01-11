﻿using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Interfaces
{
    public interface ILoadableJournalEntryRealmObject
    {
        string ID { get; set; }
        DateTimeOffset CreateDate { get; set; }
        DateTimeOffset ExecutionDate { get; set; }
        int SupportingInstitution { get; set; }
        int SupportingPerson { get; set; }

        void LoadDataFromModelObject(JournalEntry entry);
    }
}
