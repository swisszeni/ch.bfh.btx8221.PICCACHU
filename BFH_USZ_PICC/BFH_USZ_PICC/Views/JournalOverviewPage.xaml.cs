using BFH_USZ_PICC.ViewModels;
using System;
using Xamarin.Forms;



// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class JournalOverviewPage : BaseContentPage
    {
        //AllJournalEntriesConverter convertJournalEntries = new AllJournalEntriesConverter();
        public JournalOverviewPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            //Binds all journal entries to the binding context 
            BindingContext = new JournalOverviewViewModel();         
          
        }

        void SelectedEntry(object sender, EventArgs e)
        {
            JournalList.SelectedItem = null;
        }
    }
}

