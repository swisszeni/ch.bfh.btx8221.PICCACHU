using BFH_USZ_PICC.Models;
using System;
using Xamarin.Forms;
using BFH_USZ_PICC.Resx;

namespace BFH_USZ_PICC.Views.JournalEntries
{
    public sealed partial class CatheterFlushEntryPage : BaseContentPage
    {
        public CatheterFlushEntryPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            AddPickers();
        }

        public CatheterFlushEntryPage(ContentPage contained, CatheterFlushEntry entry) : base(contained)
        {
            InitializeComponent();
            AddPickers();
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
