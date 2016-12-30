using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static BFH_USZ_PICC.Models.JournalEntry;

namespace BFH_USZ_PICC.ViewModels.JournalEntries
{
    class InfusionViewModel : ViewModelBase
    {
        private InfusionEntry _displayingEntry;
        public InfusionEntry DisplayingEntry
        {
            get { return _displayingEntry; }
            set
            {
                if (Set(ref _displayingEntry, value))
                {
                    Person = value.Person;
                    Institution = value.Institution;
                    ProcedureDate = value.ProcedureDateTime;
                    InfusionType = value.Type;
                    InfusionAdministration = value.Administration;
                    AntibioticName = value.TypeAntibioticName;
                }

                RaisePropertyChanged(() => Person);
                RaisePropertyChanged(() => Institution);
                RaisePropertyChanged(() => InfusionType);
                RaisePropertyChanged(() => InfusionAdministration);
            }
        }

        private HealthPerson _person;
        public HealthPerson Person
        {
            get { return _person; }
            set { Set(ref _person, value); }
        }

        private HealthInstitution _institution;
        public HealthInstitution Institution
        {
            get { return _institution; }
            set { Set(ref _institution, value); }
        }

        private DateTimeOffset _procedureDate;
        public DateTimeOffset ProcedureDate
        {
            get { return _procedureDate; }
            set { Set(ref _procedureDate, value); }
        }

        private InfusionType _infusionType;
        public InfusionType InfusionType
        {
            get { return _infusionType; }
            set
            {
                if (value == InfusionType.Antibiotic)
                {
                    IsTypeAntibiotic = true;
                }
                else { IsTypeAntibiotic = false; }
                Set(ref _infusionType, value);
            }
        }

        private string _antibioticName;
        public string AntibioticName
        {
            get { return _antibioticName; }
            set { Set(ref _antibioticName, value); }
        }

        private InfusionAdministration _infusionAdministration;
        public InfusionAdministration InfusionAdministration
        {
            get { return _infusionAdministration; }
            set { Set(ref _infusionAdministration, value); }
        }

        private bool _isTypeAntibiotic;
        public bool IsTypeAntibiotic
        {
            get { return _isTypeAntibiotic; }
            set
            {
                if (!value)
                {
                    AntibioticName = null;
                }
                Set(ref _isTypeAntibiotic, value);
            }
        }

        private bool _isEnabledOrVisible;
        public bool IsEnabledOrVisible
        {
            get { return _isEnabledOrVisible; }
            set { Set(ref _isEnabledOrVisible, value); }
        }


        private RelayCommand _saveButtonCommand;
        public RelayCommand SaveButtonCommand => _saveButtonCommand ?? (_saveButtonCommand = new RelayCommand(async () =>
        {
            // create a new PICCAppliedDrugEntry with the user entered information
            InfusionEntry infusionEntry = new InfusionEntry(DateTime.Now, ProcedureDate, Institution, Person, InfusionType,
                InfusionAdministration, AntibioticName);
            //Add the object to the collection of JournalEntries
            JournalEntry.AllEnteredJournalEntries.Add(infusionEntry);
            //close the page
            await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
        }));

        private RelayCommand _cancelButtonCommand;
        public RelayCommand CancelButtonCommand => _cancelButtonCommand ?? (_cancelButtonCommand = new RelayCommand(async () =>
        {
            //Check if the user really wants to leave the page
            if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.CancelButtonPressedConfirmationText, AppResources.YesButtonText, AppResources.NoButtonText))
            {
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }));

        private RelayCommand _deleteButtonCommand;
        public RelayCommand DeleteButtonCommand => _deleteButtonCommand ?? (_deleteButtonCommand = new RelayCommand(async () =>
        {
            if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.JournalEntriesDelteEntryConfirmationText, AppResources.YesButtonText, AppResources.NoButtonText))
            {
                JournalEntry.AllEnteredJournalEntries.Remove(DisplayingEntry);
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }));

    }
}
