using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels.JournalEntries
{
    public abstract class JournalEntryBaseViewModel<T> : ViewModelBase where T : JournalEntry, new()
    {
        protected ILocalUserDataService _dataService;
        protected T _displayingEntry;

        public JournalEntryBaseViewModel()
        {
            _dataService = ServiceLocator.Current.GetInstance<ILocalUserDataService>();
        }

        #region navigation events

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            if (parameter is List<object> && ((List<object>)parameter).Count > 0)
            {
                // Passes an ID if there should be an existing Entry displayed
                var id = (string)((List<object>)parameter).First();
                if ((string)((List<object>)parameter).First() != null)
                {
                    // Load form Database
                    _displayingEntry = await _dataService.GetJournalEntryAsync<T>(id);
                } 
            } else
            {
                // No existing entry, we assume we want to create a new entry
                _displayingEntry = (T)Activator.CreateInstance(typeof(T));
                _displayingEntry.ExecutionDate = DateTime.Now;

                StartEditing();
            }

            LoadFromModel();
        }

        public override Task OnNavigatedFromAsync()
        {
            EndEditing();

            // Return "fake task" since Task.CompletedTask is not supported in this PCL
            return Task.FromResult(false);
        }

        #endregion

        #region private methods

        private void StartEditing()
        {
            IsUserInputEnabled = true;
        }

        private void EndEditing()
        {
            IsUserInputEnabled = false;
        }

        protected virtual void LoadFromModel()
        {
            SupportingPerson = _displayingEntry?.SupportingPerson == null ? 0 : _displayingEntry.SupportingPerson;
            SupportingInstitution = _displayingEntry?.SupportingInstitution == null ? 0 : _displayingEntry.SupportingInstitution;
            ExecutionDate = _displayingEntry?.ExecutionDate == null ? DateTime.Now : _displayingEntry.ExecutionDate.Date;

            // Actually, this shoudln't be needed... but because of some weird timing, it is.
            RaisePropertyChanged("");
        }

        protected virtual void SaveToModel()
        {
            _displayingEntry.SupportingPerson = SupportingPerson;
            _displayingEntry.SupportingInstitution = SupportingInstitution;
            var execDate = ExecutionDate.Date;
            _displayingEntry.ExecutionDate = DateTime.SpecifyKind(execDate, DateTimeKind.Utc); ;
            _displayingEntry.CreateDate = DateTimeOffset.Now;

            // Save to DB
            _dataService.SaveJournalEntryAsync<T>(_displayingEntry);
        }

        #endregion

        #region public properties

        private bool _isUserInputEnabled;
        public bool IsUserInputEnabled
        {
            get { return _isUserInputEnabled; }
            set { Set(ref _isUserInputEnabled, value); }
        }

        private HealthPerson _supportingPerson;
        public HealthPerson SupportingPerson
        {
            get { return _supportingPerson; }
            set { Set(ref _supportingPerson, value); }
        }

        private HealthInstitution _supportingInstitution;
        public HealthInstitution SupportingInstitution
        {
            get { return _supportingInstitution; }
            set { Set(ref _supportingInstitution, value); }
        }

        private DateTime _executionDate;
        public DateTime ExecutionDate
        {
            get { return _executionDate; }
            set { Set(ref _executionDate, value); }
        }

        #endregion

        #region RelayCommands

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand => _saveCommand ?? (_saveCommand = new RelayCommand(() =>
        {
            EndEditing();
            SaveToModel();
            ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
        }));

        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand => _cancelCommand ?? (_cancelCommand = new RelayCommand(async () =>
        {
            //Check if the user really wants to leave the page
            if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.CancelButtonPressedConfirmationText, AppResources.YesButtonText, AppResources.NoButtonText))
            {
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }));

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new RelayCommand(async () =>
        {
            if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.JournalEntriesDelteEntryConfirmationText, AppResources.YesButtonText, AppResources.NoButtonText))
            {
                await _dataService.DeleteJournalEntryAsync(_displayingEntry);
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }));

        #endregion
    }
}
