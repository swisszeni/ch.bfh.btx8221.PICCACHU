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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.ViewModels
{

    public class SettingsNavigationMenuItem
    {
        public SettingsMenuItemKey MenuItemKey { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public SettingsNavigationMenuItem() { }

    }

    public enum SettingsMenuItemKey
    {
        MasterData,
        MaintenanceReminder,
        Disclaimer,

    }
    public class SettingsViewModel : ViewModelBase
    {
        INavigationService _navigationService;

        public SettingsViewModel()
        {
            _navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            SettingsList = new List<SettingsNavigationMenuItem>() {
                new SettingsNavigationMenuItem { Title = AppResources.UserMasterDataPageTitleText, MenuItemKey = SettingsMenuItemKey.MasterData },
                new SettingsNavigationMenuItem { Title = AppResources.SettingsPageMaintenanceReminderText, MenuItemKey = SettingsMenuItemKey.MaintenanceReminder },
                new SettingsNavigationMenuItem { Title = AppResources.DiscalimerPageTitle, MenuItemKey = SettingsMenuItemKey.Disclaimer }
            };
        }

        #region public properties

        private List<SettingsNavigationMenuItem> _settingsList;
        public List<SettingsNavigationMenuItem> SettingsList
        {
            get { return _settingsList; }
            set { Set(ref _settingsList, value); }
        }

        #endregion

        #region relay commands

        private RelayCommand<SettingsNavigationMenuItem> _itemSelectedCommand;
        public RelayCommand<SettingsNavigationMenuItem> ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<SettingsNavigationMenuItem>((SettingsNavigationMenuItem selectedItem) =>
        {
            // Item selected, handle navigation
            switch (selectedItem.MenuItemKey)
            {
                case SettingsMenuItemKey.MasterData:
                    _navigationService.NavigateToAsync<MasterDataViewModel>(new List<object> { false });
                    return;
                case SettingsMenuItemKey.MaintenanceReminder:
                    _navigationService.NavigateToAsync<MaintenanceReminderViewModel>();
                    return;
                case SettingsMenuItemKey.Disclaimer:
                    _navigationService.NavigateToAsync<DisclaimerViewModel>();
                    return;
            }
        }));

        #endregion
    }
}