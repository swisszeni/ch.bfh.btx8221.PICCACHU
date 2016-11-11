using BFH_USZ_PICC.Controls;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using System;
using Xamarin.Forms;
using static BFH_USZ_PICC.Models.JournalEntry;
using static BFH_USZ_PICC.Utilitys.AllJournalEntriesConverter;


// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Views.JournalEntryViews
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class AdministeredDrugEntryPage : BaseContentPage
    {

        public AdministeredDrugEntryPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
     
            
        }

        async void SaveDrugEntryButtonClicked(object sender, EventArgs e)
        {
            PICCAppliedDrugEntry drugEntry = new PICCAppliedDrugEntry(DateTime.Now, ProcedureDate.Date, JournalEntry.HealthInstitution.Ambulatory, JournalEntry.HealthPerson.AffectedPerson, DrugEntry.Text);
            AllEnteredJournalEntries.Add(drugEntry);
            await Navigation.PopModalAsync();
        }

        async void CancelDrugEntryButtonClicked(object sender, EventArgs e)
        {
            if(await DisplayAlert("Warnung!", "Wollen Sie die Eingabe wirklich abbrechen?", "Ja", "Nein")){

                await Navigation.PopModalAsync();
            }
        }
    }
}
