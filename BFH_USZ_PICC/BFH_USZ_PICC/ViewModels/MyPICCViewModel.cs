﻿using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels
{
    class MyPICCViewModel : ViewModelBase
    {
        private ILocalUserDataService _dataService;

        public MyPICCViewModel()
        {
            // Getting the dataservice
            _dataService = ServiceLocator.Current.GetInstance<ILocalUserDataService>();
        }

        #region navigation events

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            PopulatePICCsAsync();

            // Return "fake task" since Task.CompletedTask is not supported in this PCL
            return Task.FromResult(false);
        }

        #endregion

        #region private methods

        public async void PopulatePICCsAsync()
        {
            CurrentPICC = await _dataService.GetCurrentPICCAsync();
                                    
            PreviousPICC = await _dataService.GetFormerPICCsAsync();
        }

        #endregion

        #region public properties

        public bool HasCurrentPicc { get { return CurrentPICC != null; } }
        private PICC _currentPICC;
        public PICC CurrentPICC
        {
            get { return _currentPICC; }
            set
            {
                if (Set(ref _currentPICC, value))
                {
                    RaisePropertyChanged(() => HasCurrentPicc);
                }
            }            

        }

        private List<PICC> _previousPICC;
        public List<PICC> PreviousPICC
        {
            get { return _previousPICC; }
            set { Set(ref _previousPICC, value); }
        }

        private PICC _selectedEntry;
        public PICC SelectedEntry
        {
            get { return _selectedEntry; }
            set
            {
                Set(() => SelectedEntry, ref _selectedEntry, value);

                //Checks if _selectedEntry is not null (this can be if the user leaves the app on the device back button)
                if (_selectedEntry != null)
                {
                    ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(PICCDetailPage), new List<object> { SelectedEntry.ID }));
                }
            }
        }

        #endregion

        #region RelayCommands

        private RelayCommand _addPICCCommand;
        public RelayCommand AddPICCCommand => _addPICCCommand ?? (_addPICCCommand = new RelayCommand(async () =>
        {
            await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(AddPICCPage)));

        }));


        private RelayCommand _currentPICCButtonCommand;
        public RelayCommand CurrentPICCButtonCommand => _currentPICCButtonCommand ?? (_currentPICCButtonCommand = new RelayCommand(async () =>
        {
            await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(PICCDetailPage), new List<object> { CurrentPICC.ID }));
        }));

        #endregion
    }
}
