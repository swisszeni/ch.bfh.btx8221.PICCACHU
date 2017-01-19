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
        Imprint
    }
    public class SettingsViewModel : ViewModelBase
    {
        INavigationService _navigationService;

        public SettingsViewModel()
        {
            _navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            SettingsList = new List<SettingsNavigationMenuItem>() {
                new SettingsNavigationMenuItem { Title = AppResources.UserMasterDataPageTitleText, Details = AppResources.UserMasterDataPageDescription, MenuItemKey = SettingsMenuItemKey.MasterData },
                new SettingsNavigationMenuItem { Title = AppResources.SettingsPageMaintenanceReminderText, Details = AppResources.MaintenanceReminderPageDescription, MenuItemKey = SettingsMenuItemKey.MaintenanceReminder },
                new SettingsNavigationMenuItem { Title = AppResources.DiscalimerPageTitle, Details = AppResources.DisclaimerPageDescription, MenuItemKey = SettingsMenuItemKey.Disclaimer },
                new SettingsNavigationMenuItem { Title = AppResources.ImprintPageTitle, Details = AppResources.ImprintPageDescription, MenuItemKey = SettingsMenuItemKey.Imprint }
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
                    _navigationService.NavigateToAsync<SettingsMasterDataViewModel>(new List<object> { false });
                    return;
                case SettingsMenuItemKey.MaintenanceReminder:
                    _navigationService.NavigateToAsync<SettingsMaintenanceReminderViewModel>();
                    return;
                case SettingsMenuItemKey.Disclaimer:
                    _navigationService.NavigateToAsync<SettingsDisclaimerViewModel>();
                    return;
                case SettingsMenuItemKey.Imprint:
                    _navigationService.NavigateToAsync<SettingsImprintViewModel>();
                    return;
            }
        }));

        #endregion
    }
}