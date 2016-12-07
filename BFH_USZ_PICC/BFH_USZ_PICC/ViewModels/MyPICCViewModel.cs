using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        private PICC _currentPICC;
        public PICC CurrentPICC
        {
            get { return _currentPICC; }
            set { Set(ref _currentPICC, value); }

        }

        private ObservableCollection<PICC> _previousPICC = PICC.PreviousPICC;
        public ObservableCollection<PICC> PreviousPICC
        {
            get { return _previousPICC; }
            set { Set(ref _previousPICC, value); }
        }

            
        private bool _isAPiccAdded;
        public bool IsAPiccAdded
        {
            get { return _isAPiccAdded; }
            set { Set(ref _isAPiccAdded, value); }
        }

        private RelayCommand _addPICCCommand;
        public RelayCommand AddPICCCommand => _addPICCCommand ?? (_addPICCCommand = new RelayCommand(async () =>
        {
            await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(AddPICCPage)));

        }));

        
        private RelayCommand _currentPICCButtonCommand;
        public RelayCommand CurrentPICCButtonCommand => _currentPICCButtonCommand ?? (_currentPICCButtonCommand = new RelayCommand(async() =>
        {
            await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(PICCDetailPage), new List<object> { CurrentPICC }));

        }));

        private RelayCommand _reloadCurrentPiccBinding;
        public RelayCommand ReloadCurrentPiccBinding => _reloadCurrentPiccBinding ?? (_reloadCurrentPiccBinding = new RelayCommand(() =>
        {
            CurrentPICC =  PICC.CurrentPICC;

            if(CurrentPICC == null)
            {
                IsAPiccAdded = false;
                return;
            }
            IsAPiccAdded = true; 

        }));

    }
}
