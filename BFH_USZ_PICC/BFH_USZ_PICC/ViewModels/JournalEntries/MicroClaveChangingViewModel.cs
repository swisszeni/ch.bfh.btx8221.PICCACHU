using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
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
    class MicroClaveChangingViewModel : ViewModelBase
    {
        private ILocalUserDataService _dataService;

        public MicroClaveChangingViewModel()
        {
            //Getting the dataservice
            _dataService = ServiceLocator.Current.GetInstance<ILocalUserDataService>();
        }

        private MicroClaveChangingEntry _displayingEntry;
        public MicroClaveChangingEntry DisplayingEntry
        {
            get { return _displayingEntry; }
            set
            {
                if (Set(ref _displayingEntry, value))
                {
                    Person = value.Person;
                    Institution = value.Institution;
                    ProcedureDate = (value.ProcedureDateTime).Date;
                    Reason = value.Reason;

                    // Update bindings
                    //RaisePropertyChanged("");
                }

                RaisePropertyChanged(() => Person);
                RaisePropertyChanged(() => Institution);
                RaisePropertyChanged(() => Reason);
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

        private DateTime _procedureDate;
        public DateTime ProcedureDate
        {
            get { return _procedureDate; }
            set { Set(ref _procedureDate, value); }
        }

        private MicroClaveChangementReason _reason;
        public MicroClaveChangementReason Reason
        {
            get { return _reason; }
            set { Set(ref _reason, value); }

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
            MicroClaveChangingEntry entry = new MicroClaveChangingEntry(DateTimeOffset.Now, (ProcedureDate.Date).ToLocalTime(), Institution, Person, Reason);
            //Add the object to the collection of JournalEntries
            await _dataService.SaveJournalEntryAsync(entry);
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
            if (await ((Shell)Application.Current.MainPage).DisplayAlert(AppResources.WarningText, AppResources.JournalEntriesDelteEntryConfirmationText, AppResources.YesButtonText, AppResources.NoButtonText))
            {
                await _dataService.DeleteJournalEntryAsync(DisplayingEntry);
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }));

        private RelayCommand _checkForMainentanceInstruction;
        public RelayCommand CheckForMainentanceInstruction => _checkForMainentanceInstruction ?? (_checkForMainentanceInstruction = new RelayCommand(async () =>
        {
            if (IsEnabledOrVisible)

            {
                if (await ((Shell)Application.Current.MainPage).DisplayAlert(AppResources.InformationText, AppResources.JournalEntriesAskForMainentanceInstructionText, AppResources.YesButtonText, AppResources.NoButtonText))
                {
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(MaintenanceInstructionPage), new List<object> { MainentanceInstructions.getMicroClaveInstruction() }));
                }
            }           
        }));
    }

}

