using BFH_USZ_PICC.Models;
using System;
using Xamarin.Forms;
using static BFH_USZ_PICC.Models.JournalEntry;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.ViewModels.JournalEntries;



// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Views.JournalEntries
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MicroClaveChangingEntryPage : BaseContentPage
    {
        private bool _firstAppearing = true;
        public MicroClaveChangingEntryPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            AddPickers();
            ((MicroClaveChangingViewModel)BindingContext).DisplayingEntry = new MicroClaveChangingEntry();
            ((MicroClaveChangingViewModel)BindingContext).IsEnabledOrVisible = true;

        }               

        public MicroClaveChangingEntryPage(ContentPage contained, MicroClaveChangingEntry entry) : base(contained)
        {
            InitializeComponent();
            AddPickers();
            ((MicroClaveChangingViewModel)BindingContext).DisplayingEntry = entry;
            ((MicroClaveChangingViewModel)BindingContext).IsEnabledOrVisible = false;

        }
        public override void OnAppearing()
        {
            base.OnAppearing();
            if (_firstAppearing)
            {
                ((MicroClaveChangingViewModel)BindingContext).CheckForMainentanceInstruction.Execute(null);
                _firstAppearing = false;
            }
        }

        void AddPickers()
        {
            HealthInstitutionPicker.Items.Add(AppResources.JournalEntryNotSpecifiedText);
            HealthInstitutionPicker.Items.Add(AppResources.JournalEntryInstitutionHospitalText);
            HealthInstitutionPicker.Items.Add(AppResources.JournalEntryInstitutionOutpatienClinicText);
            HealthInstitutionPicker.Items.Add(AppResources.JournalEntryInstitutionRehabilitationText);
            HealthInstitutionPicker.Items.Add(AppResources.JournalEntryInstitutionHomeCareText);
            HealthInstitutionPicker.Items.Add(AppResources.JournalEntryOthersText);

            HealthPersonPicker.Items.Add(AppResources.JournalEntryNotSpecifiedText);
            HealthPersonPicker.Items.Add(AppResources.JournalEntryPersonFamilyDoctorText);
            HealthPersonPicker.Items.Add(AppResources.JournalEntryPersonSpecialistText);
            HealthPersonPicker.Items.Add(AppResources.JournalEntryPersonNursingStaffText);
            HealthPersonPicker.Items.Add(AppResources.JournalEntryPersonXrayStaffText);
            HealthPersonPicker.Items.Add(AppResources.JournalEntryPersonMedicalTechnicalAssistantText);
            HealthPersonPicker.Items.Add(AppResources.JournalEntryPersonHealthExpertStaffText);
            HealthPersonPicker.Items.Add(AppResources.JournalEntryPersonRelativeText);
            HealthPersonPicker.Items.Add(AppResources.JournalEntryPersonAffectedPersonText);
            HealthPersonPicker.Items.Add(AppResources.JournalEntryOthersText);

            MicroClaveChaningReasonPicker.Items.Add(AppResources.JournalEntryNotSpecifiedText);
            MicroClaveChaningReasonPicker.Items.Add(AppResources.MicroClaveChangingEntryRoutineText);
            MicroClaveChaningReasonPicker.Items.Add(AppResources.MicroClaveChangingEntryPollutionText);

        }

    }
}
