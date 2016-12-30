using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
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

    //public enum JournalEntryPageStatus
    //{
    //    Create, 
    //    Edit,
    //    View
    //}

    class AdministeredDrugViewModel : ViewModelBase
    {
        private ILocalUserDataService _dataService;

        public AdministeredDrugViewModel()
        {
            //Getting the dataservice
            _dataService = ServiceLocator.Current.GetInstance<ILocalUserDataService>();

           
        }

        private AdministeredDrugEntry _displayingEntry;
        public AdministeredDrugEntry DisplayingEntry
        {
            get { return _displayingEntry; }
            set
            {
                if (Set(ref _displayingEntry, value))
                {
                    Person = value.Person;
                    Institution = value.Institution;
                    ProcedureDate = value.ProcedureDateTime;
                    Drug = value.Drug;

                    // Update bindings
                    //RaisePropertyChanged("");
                }

                RaisePropertyChanged(() => Person);
                RaisePropertyChanged(() => Institution);
            }
        }

        //FIXME: Implement proper View/Edit/Create pattern
        //private JournalEntryPageStatus _status;
        //public JournalEntryPageStatus Status
        //{
        //    get { return _status; }
        //    set {
        //        Set(ref _status, value);
        //    }
        //}

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

        private string _drug;
        public string Drug
        {
            get { return _drug; }
            set { Set(ref _drug, value); }
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
            AdministeredDrugEntry entry = new AdministeredDrugEntry(DateTime.Now, ProcedureDate, Institution, Person, Drug);
            //Add the object to the collection of JournalEntries            
            //JournalEntry.AllEnteredJournalEntries.Add(entry);
            
            //TEST
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
            if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.JournalEntriesDelteEntryConfirmationText, AppResources.YesButtonText, AppResources.NoButtonText))
            {
                JournalEntry.AllEnteredJournalEntries.Remove(DisplayingEntry);
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }));
    }
}
