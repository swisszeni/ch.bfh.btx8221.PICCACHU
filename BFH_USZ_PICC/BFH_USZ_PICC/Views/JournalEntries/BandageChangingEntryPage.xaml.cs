using BFH_USZ_PICC.Models;
using System;
using Xamarin.Forms;
using static BFH_USZ_PICC.Models.JournalEntry;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.ViewModels.JournalEntries;



// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Views.JournalEntries
{
    
    public sealed partial class BandageChangingEntryPage : BaseContentPage
    {
        private bool _firstAppearing = true;
        public BandageChangingEntryPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            AddPickers();
            ((BandageChangingViewModel)BindingContext).DisplayingEntry = new BandageChangingEntry();
            ((BandageChangingViewModel)BindingContext).IsEnabledOrVisible = true;


        }

        public BandageChangingEntryPage(ContentPage contained, BandageChangingEntry entry) : base(contained)
        {
            InitializeComponent();
            AddPickers();
            ((BandageChangingViewModel)BindingContext).DisplayingEntry = entry;
            ((BandageChangingViewModel)BindingContext).IsEnabledOrVisible = false;

        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            if (_firstAppearing)
            {
                ((BandageChangingViewModel)BindingContext).CheckForMainentanceInstruction.Execute(null);
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

            BandageChangingReasonPicker.Items.Add(AppResources.JournalEntryNotSpecifiedText);
            BandageChangingReasonPicker.Items.Add(AppResources.BandageChangingReasonRoutineText);
            BandageChangingReasonPicker.Items.Add(AppResources.BandageChangingReasonPunctureNotCoveredText);
            BandageChangingReasonPicker.Items.Add(AppResources.BandageChangingReasonBandageWetText);
            BandageChangingReasonPicker.Items.Add(AppResources.BandageChangingReasonBandageDoesNotStickAnymoreText);
            BandageChangingReasonPicker.Items.Add(AppResources.BandageChangingReasonSecondaryBleedingText);
            BandageChangingReasonPicker.Items.Add(AppResources.BandageChangingReasonPainText);

            BandageChangingAreaPicker.Items.Add(AppResources.JournalEntryNotSpecifiedText);
            BandageChangingAreaPicker.Items.Add(AppResources.BandageChangingAreaCompleteText);
            BandageChangingAreaPicker.Items.Add(AppResources.BandageChangingAreaOnlyBandageText);
            BandageChangingAreaPicker.Items.Add(AppResources.BandageChangingAreaOnlyStatlockText);

            BandageChangingPuncturePicker.Items.Add(AppResources.JournalEntryNotSpecifiedText);
            BandageChangingPuncturePicker.Items.Add(AppResources.BandagePunctureSituationSkinNotIrritantText);
            BandageChangingPuncturePicker.Items.Add(AppResources.BandagePunctureSituationReddenedPunctureText);
            BandageChangingPuncturePicker.Items.Add(AppResources.BandagePunctureSituationSwollenPunctureText);
            BandageChangingPuncturePicker.Items.Add(AppResources.BandagePunctureSituationPainfulPunctureText);
            BandageChangingPuncturePicker.Items.Add(AppResources.BandagePunctureSituationLiquidDischargeText);

            BandageChangingArmProcessSituationPicker.Items.Add(AppResources.JournalEntryNotSpecifiedText);
            BandageChangingArmProcessSituationPicker.Items.Add(AppResources.BandageArmProcessSituationPainfulText);
            BandageChangingArmProcessSituationPicker.Items.Add(AppResources.BandageArmProcessSituationSwollenText);
            BandageChangingArmProcessSituationPicker.Items.Add(AppResources.BandageArmProcessSituationReddenedText);
        }

    }
}
