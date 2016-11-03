using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Utilitys;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static BFH_USZ_PICC.Models.JournalEntry;
using static BFH_USZ_PICC.Utilitys.AllJournalEntriesConverter;



// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class JournalOverviewPage : BaseContentPage
    {
        List<EntryAndImage> journalEntrySelection = new List<EntryAndImage>();
        public JournalOverviewPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();

            //Get all the knowledge entries and add them to  the ListView
            List<JournalEntry> test = new List<JournalEntry>();

            int temp = 0;
            while (temp < 25)
            {
                test.Add(new BloodWithdrawalEntry(DateTime.Today, DateTime.Today, JournalEntry.HealthInstitution.HomeCare, JournalEntry.HealthPerson.FamilyDoctor, true, BloodFlow.Speedy));

                temp++;
            }

            JournalList.ItemsSource = test;

            //Part to initialize the selection for a new JournalEntry
            AllJournalEntriesConverter convertJournalEntries = new AllJournalEntriesConverter();

            journalEntrySelection.Add(convertJournalEntries.Convert(AllPossibleJournalEntries.BandagesChangingEntry));
            journalEntrySelection.Add(convertJournalEntries.Convert(AllPossibleJournalEntries.BloodWithdrawalEntry));
            journalEntrySelection.Add(convertJournalEntries.Convert(AllPossibleJournalEntries.CatheterFlushEntry));
            journalEntrySelection.Add(convertJournalEntries.Convert(AllPossibleJournalEntries.InfusionEntry));
            journalEntrySelection.Add(convertJournalEntries.Convert(AllPossibleJournalEntries.MicroClaveEntry));
            journalEntrySelection.Add(convertJournalEntries.Convert(AllPossibleJournalEntries.PICCAppliedDrugEntry));
            journalEntrySelection.Add(convertJournalEntries.Convert(AllPossibleJournalEntries.StatlockEntry));

            // ChoseAJournalEntry.ItemsSource = journalEntrySelection;
        }

        async void NewEntryButtonClicked(object sender, EventArgs e)
        {
            // setListViewChoseAJournalEntryVisible(true);
          
            var selectedEntry = await Xamarin.Forms.Application.Current.MainPage.DisplayActionSheet("Was wollen Sie hinzufügen?", "Abbrechen", null, 
                journalEntrySelection[0].Entry, journalEntrySelection[1].Entry, journalEntrySelection[2].Entry, journalEntrySelection[3].Entry, journalEntrySelection[4].Entry,
                journalEntrySelection[5].Entry, journalEntrySelection[6].Entry);

            if(selectedEntry!= null && selectedEntry != "Abbrechen")
            {
                await DisplayAlert("Information", "Nun würde ein neuer " + selectedEntry + " Eintrag eröffnet", "Ok");
            }
             
        }

       
        //void NewEntryCancelButtonClicked(object sender, EventArgs e)
        //{
        //    setListViewChoseAJournalEntryVisible(false);
        //}

        //private void setListViewChoseAJournalEntryVisible(bool trueOrFalse) {
        //    ChoseAJournalEntry.IsVisible = trueOrFalse;
        //}
    }
}
