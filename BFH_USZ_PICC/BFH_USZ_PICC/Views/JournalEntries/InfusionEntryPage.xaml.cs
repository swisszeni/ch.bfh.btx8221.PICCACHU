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
    public sealed partial class InfusionEntryPage : BaseContentPage
    {
        public InfusionEntryPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            AddPickers();
            ((InfusionViewModel)BindingContext).DisplayingEntry = new InfusionEntry();
            ((InfusionViewModel)BindingContext).IsEnabledOrVisible = true;
        }

        public InfusionEntryPage(ContentPage contained, InfusionEntry entry) : base(contained)
        {
            InitializeComponent();
            AddPickers();
            ((InfusionViewModel)BindingContext).DisplayingEntry = entry;
            ((InfusionViewModel)BindingContext).IsEnabledOrVisible = false;
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

            InfusionReasonPicker.Items.Add(AppResources.JournalEntryNotSpecifiedText);
            InfusionReasonPicker.Items.Add(AppResources. InfusionReasonAntibioticText);
            InfusionReasonPicker.Items.Add(AppResources.InfusionReasonNutritionalSubstanceText);
            InfusionReasonPicker.Items.Add(AppResources.InfusionReasonBloodComponentText);
            InfusionReasonPicker.Items.Add(AppResources.InfusionReasonExaminationSubstanceText);
            InfusionReasonPicker.Items.Add(AppResources.InfusionReasonChemotherapyText);
            InfusionReasonPicker.Items.Add(AppResources.InfusionReasonOthersText);

            InfusionAdministrationPicker.Items.Add(AppResources.JournalEntryNotSpecifiedText);
            InfusionAdministrationPicker.Items.Add(AppResources.InfusionAdministrationWithoutProblemText);
            InfusionAdministrationPicker.Items.Add(AppResources.InfusionAdministrationFastText);
            InfusionAdministrationPicker.Items.Add(AppResources.InfusionAdministrationHesitantText);



        }

    }
}
