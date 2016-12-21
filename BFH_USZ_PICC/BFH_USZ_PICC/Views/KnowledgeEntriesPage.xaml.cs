using BFH_USZ_PICC.Models;
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

        //This method sets the selected knowledge entry to null (otherwise it would be marked as selected after closing the detail page).
        void SelectedKnowledgeEntry(object sender, EventArgs e)
        {
            KnowledgeList.SelectedItem = null;
        }
    }
}
