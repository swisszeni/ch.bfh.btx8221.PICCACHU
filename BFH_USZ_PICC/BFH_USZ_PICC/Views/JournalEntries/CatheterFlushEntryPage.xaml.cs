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
    public sealed partial class CatheterFlushEntryPage : BaseContentPage
    {
        public CatheterFlushEntryPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            AddPickers();
            ((CatheterFlushViewModel)BindingContext).DisplayingEntry = new CatheterFlushEntry();
            ((CatheterFlushViewModel)BindingContext).IsEnabledOrVisible = true;

        }

        public CatheterFlushEntryPage(ContentPage contained, CatheterFlushEntry entry) : base(contained)
        {
            InitializeComponent();
            AddPickers();
            ((CatheterFlushViewModel)BindingContext).DisplayingEntry = entry;
            ((CatheterFlushViewModel)BindingContext).IsEnabledOrVisible = false;

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

            FlushReasonPicker.Items.Add(AppResources.JournalEntryNotSpecifiedText);
            FlushReasonPicker.Items.Add(AppResources.CatheterFlushReasonRoutineText);
            FlushReasonPicker.Items.Add(AppResources.CatheterFlushReasonBloodSamplingText);
            FlushReasonPicker.Items.Add(AppResources.CatheterFlushReasonPartiallyBlockedText);
            FlushReasonPicker.Items.Add(AppResources.CatheterFlushReasonBlockedText);

            FlushTypePicker.Items.Add(AppResources.JournalEntryNotSpecifiedText);
            FlushTypePicker.Items.Add(AppResources.CatheterFlushTypeNaClText);
            FlushTypePicker.Items.Add(AppResources.CatheterFlushTypeHeparinText);
            FlushTypePicker.Items.Add(AppResources.CatheterFlushTypeUrokinaseText);

            FlushResultPicker.Items.Add(AppResources.JournalEntryNotSpecifiedText);
            FlushResultPicker.Items.Add(AppResources.CatheterFlushResultFlushWithoutResistanceText);
            FlushResultPicker.Items.Add(AppResources.CatheterFlushResultFlushWithResistanceText);
            FlushResultPicker.Items.Add(AppResources.CatheterFlushResultFlushNotPossibleText);
        }

    }
}
