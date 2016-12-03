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
        public MyPICCViewModel()
        {
            CurrentPICC = PICC.CurrentPICC;
        }


        private PICC _currentPICC;
        public PICC CurrentPICC
        {
            get { return _currentPICC; }
            set
            {
                if (Set(ref _currentPICC, value))
                {
                    if (value != null)
                    {
                        IsAPiccAdded = false;
                    }
                }
                RaisePropertyChanged("CurrentPICC");
            }
        }

        private ObservableCollection<PICC> _previousPICC = PICC.PreviousPICC;
        public ObservableCollection<PICC> PreviousPICC
        {
            get { return _previousPICC; }
            set { Set(ref _previousPICC, value); }
        }

            
        private bool _isAPiccAdded = true;
        public bool IsAPiccAdded
        {
            get { return _isAPiccAdded; }
            set { Set(ref _isAPiccAdded, value); }
        }

        private RelayCommand _AddPICCCommand;
        public RelayCommand AddPICCCommand => _AddPICCCommand ?? (_AddPICCCommand = new RelayCommand(async () =>
        {
            await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(AddPICCPage)));

        }));

    }
}
