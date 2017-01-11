using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {   

        private RelayCommand _moveToMasterDataPageCommand;
        public RelayCommand MoveToMasterDataPageCommand => _moveToMasterDataPageCommand ?? (_moveToMasterDataPageCommand = new RelayCommand(() =>
        {
            ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(UserMasterDataPage), new List<object> { false }));

        }));

        private RelayCommand _moveToMasterMaintenanceReminderPageCommand;
        public RelayCommand MoveToMasterMaintenanceReminderPageCommand => _moveToMasterMaintenanceReminderPageCommand ?? (_moveToMasterMaintenanceReminderPageCommand = new RelayCommand(() =>
        {
            ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(MaintenanceReminderPage)));

        }));

       
        
    }
}