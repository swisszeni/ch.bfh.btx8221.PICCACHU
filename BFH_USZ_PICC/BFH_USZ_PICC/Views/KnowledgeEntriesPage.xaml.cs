﻿using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public sealed partial class KnowledgeEntriesPage : BaseContentPage
    {
        List<KnowledgeEntryTypeGroup> allEntries = new List<KnowledgeEntryTypeGroup>();

        public KnowledgeEntriesPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
        }
    }
}
