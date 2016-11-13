using BFH_USZ_PICC.Models;
using System;
using Xamarin.Forms;
using static BFH_USZ_PICC.Models.JournalEntry;
using BFH_USZ_PICC.Resx;



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


            // Add all possible institutions to the related picker
            HealthInstitutionPicker.Items.Add(AppResources.JournalEntryInstitutionNotSpecifiedText);
            HealthInstitutionPicker.Items.Add(AppResources.JournalEntryInstitutionHospitalText);
            HealthInstitutionPicker.Items.Add(AppResources.JournalEntryInstitutionOutpatienClinicText);
            HealthInstitutionPicker.Items.Add(AppResources.JournalEntryInstitutionRehabilitationText);
            HealthInstitutionPicker.Items.Add(AppResources.JournalEntryInstitutionHomeCareText);
            HealthInstitutionPicker.Items.Add(AppResources.JournalEntryInstitutionOthersText);




        }

        async void SaveDrugEntryButtonClicked(object sender, EventArgs e)
        {
            // create a new PICCAppliedDrugEntry with the user entered information
            PICCAppliedDrugEntry drugEntry = new PICCAppliedDrugEntry(DateTime.Now, ProcedureDate.Date, (HealthInstitution)HealthInstitutionPicker.SelectedIndex, HealthPerson.AffectedPerson, DrugEntry.Text);
            //Add the object to the collection of JournalEntries
            JournalEntry.AllEnteredJournalEntries.Add(drugEntry);
            //close the modal page
            await Navigation.PopModalAsync();
        }

        async void CancelDrugEntryButtonClicked(object sender, EventArgs e)
        {
            //Check if the user really wants to leave the page
            if (await DisplayAlert("Warnung!", "Wollen Sie die Eingabe wirklich abbrechen?", "Ja", "Nein"))
            {

                await Navigation.PopModalAsync();
            }
        }
    }
}
