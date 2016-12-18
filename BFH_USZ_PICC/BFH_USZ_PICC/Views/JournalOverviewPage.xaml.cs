using BFH_USZ_PICC.ViewModels;
using System;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public sealed partial class JournalOverviewPage : BaseContentPage
    {
        public JournalOverviewPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
        }

        // This method sets the selected journal entry to null (otherwise it would be marked).
        void SelectedEntry(object sender, EventArgs e)
        {
            JournalList.SelectedItem = null;
        }
    }
}
