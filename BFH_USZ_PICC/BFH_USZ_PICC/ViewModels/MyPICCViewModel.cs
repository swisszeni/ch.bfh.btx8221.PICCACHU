using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
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
using System.Windows.Input;

namespace BFH_USZ_PICC.ViewModels
{
    class MyPICCViewModel : ViewModelBase
    {
        private ILocalUserDataService _dataService;

        public MyPICCViewModel()
        {
            // Getting the data service
            _dataService = ServiceLocator.Current.GetInstance<ILocalUserDataService>();
        }

        #region navigation events

        public override Task InitializeAsync(List<object> navigationData)
        {
            PopulatePICCsAsync();

            return base.InitializeAsync(navigationData);
        }

        public override Task OnNavigatedToAsync(NavigationMode mode)
        {
            PopulatePICCsAsync();

            return base.OnNavigatedToAsync(mode);
        }

        #endregion

        #region private methods

        private async void PopulatePICCsAsync()
        {
            CurrentPICC = await _dataService.GetCurrentPICCAsync();

            var previousPICCListUnsorted = await _dataService.GetFormerPICCsAsync();
            PreviousPICC = previousPICCListUnsorted.OrderByDescending((x) => x.RemovalDate).ThenBy((x) => x.PICCModel.PICCName).ToList();          
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

        public bool HasPreviousPicc { get { return PreviousPICC != null && PreviousPICC.Count > 0; } }
        private List<PICC> _previousPICC;
        public List<PICC> PreviousPICC
        {
            get { return _previousPICC; }
            set
            {
                if (Set(ref _previousPICC, value))
                {
                    RaisePropertyChanged(() => HasPreviousPicc);
                }
            }
        }

        #endregion

        #region relay commands

        private RelayCommand _addPICCCommand;
        public RelayCommand AddPICCCommand => _addPICCCommand ?? (_addPICCCommand = new RelayCommand(() =>
        {
            NavigationService.NavigateToAsync<AddPICCViewModel>();
        }));


        private RelayCommand _goToCurrentPICCDetailCommand;
        public RelayCommand GoToCurrentPICCDetailCommand => _goToCurrentPICCDetailCommand ?? (_goToCurrentPICCDetailCommand = new RelayCommand(() =>
        {
            NavigationService.NavigateToAsync<PICCDetailViewModel>(new List<object> { CurrentPICC.ID });
        }));        

        private RelayCommand _moveToJournalEntryOverviewPageCommand;
        public RelayCommand MoveToJournalEntryOverviewPageCommand => _moveToJournalEntryOverviewPageCommand ?? (_moveToJournalEntryOverviewPageCommand = new RelayCommand(() =>
        {
            NavigationService.NavigateToAsync(MenuItemKey.Journal);
        }));

        private RelayCommand<PICC> _deleteFormerPICCCommand;
        public RelayCommand<PICC> DeleteFormerPICCCommand => _deleteFormerPICCCommand ?? (_deleteFormerPICCCommand = new RelayCommand<PICC>(async (PICC selectedPICC) => 
        {
            if (selectedPICC != null)
            {
                if (await DisplayAlert(AppResources.WarningText, AppResources.MyPICCPageDeletePICCWarningText, AppResources.YesButtonText, AppResources.NoButtonText))
                {
                    await _dataService.DeltePICCAsync(selectedPICC);
                    PopulatePICCsAsync();
                }
            }
        }));

        private RelayCommand<PICC> _itemSelectedCommand;
        public RelayCommand<PICC> ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<PICC>((PICC selectedItem) =>
        {
            // Item selected, handle navigation
            NavigationService.NavigateToAsync<FormerPICCDetailViewModel>(new List<object> { selectedItem.ID });
        }));

        #endregion

    }
}
