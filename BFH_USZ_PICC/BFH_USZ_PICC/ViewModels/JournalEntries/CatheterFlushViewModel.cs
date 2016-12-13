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
    class CatheterFlushViewModel : ViewModelBase
    {
        private CatheterFlushEntry _displayingEntry;
        public CatheterFlushEntry DisplayingEntry
        {
            get { return _displayingEntry; }
            set
            {
                if (Set(ref _displayingEntry, value))
                {
                    Person = value.Person;
                    Institution = value.Institution;
                    ProcedureDate = value.ProcedureDateTime;
                    Reason = value.Reason;
                    Type = value.Type;
                    Result = value.Result;
                    QuantityInMilliliter = value.QuantityInMilliliter;
                    IsBloodReflowVisible = value.IsBloodReflowVisible;  
                }

                RaisePropertyChanged(() => Person);
                RaisePropertyChanged(() => Institution);
                RaisePropertyChanged(() => Reason);
                RaisePropertyChanged(() => Type);
                RaisePropertyChanged(() => Result);

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

        private FlushReason _reason;
        public FlushReason Reason
        {
            get { return _reason; }
            set { Set(ref _reason, value); }
        }

        private FlushType _type;
        public FlushType Type
        {
            get { return _type; }
            set { Set(ref _type, value); }
        }

        private FlushResult _result;
        public FlushResult Result
        {
            get { return _result; }
            set { Set(ref _result, value); }
        }

        private double _quantityInMilliliter;
        public double QuantityInMilliliter
        {
            get { return _quantityInMilliliter; }
            set { Set(ref _quantityInMilliliter, value); }
        }

        private bool _isBloodReflowVisible;
        public bool IsBloodReflowVisible
        {
            get { return _isBloodReflowVisible; }
            set { Set(ref _isBloodReflowVisible, value); }
        }


        private bool _isEnabledOrVisible;
        public bool IsEnabledOrVisible
        {
            get { return _isEnabledOrVisible; }
            set { Set(ref _isEnabledOrVisible, value); }
        }


        private RelayCommand _saveButtonCommand;
        public RelayCommand SaveButtonCommand => _saveButtonCommand ?? (_saveButtonCommand = new RelayCommand(async () => {
        // create a new PICCAppliedDrugEntry with the user entered information
        CatheterFlushEntry entry = new CatheterFlushEntry(DateTime.Now, ProcedureDate, Institution, Person, Type, Result, Reason,
            QuantityInMilliliter, IsBloodReflowVisible);               
            //Add the object to the collection of JournalEntries
            JournalEntry.AllEnteredJournalEntries.Add(entry);
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
        public RelayCommand DeleteButtonCommand => _deleteButtonCommand ?? (_deleteButtonCommand = new RelayCommand(async () => {
            if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.JournalEntriesDelteEntryConfirmationText, AppResources.YesButtonText, AppResources.NoButtonText))
            {
                JournalEntry.AllEnteredJournalEntries.Remove(DisplayingEntry);
                await((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }));

    }
}
