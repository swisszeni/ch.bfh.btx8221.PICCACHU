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
        public SettingsViewModel()
        {

            SettingsList = new List<SettingsNavigationMenuItem>();
            SettingsList.Add(new SettingsNavigationMenuItem { Title = AppResources.UserMasterDataPageTitleText, MenuItemKey = SettingsMenuItemKey.MasterData });
            SettingsList.Add(new SettingsNavigationMenuItem { Title = AppResources.SettingsPageMaintenanceReminderText, MenuItemKey = SettingsMenuItemKey.MaintenanceReminder });
            SettingsList.Add(new SettingsNavigationMenuItem { Title = AppResources.DiscalimerPageTitle, MenuItemKey = SettingsMenuItemKey.Disclaimer });
        }


        private List<SettingsNavigationMenuItem> _settingsList;
        public List<SettingsNavigationMenuItem> SettingsList
        {
            get { return _settingsList; }
            set { Set(ref _settingsList, value); }
        }


        private SettingsNavigationMenuItem _selectedEntry;
        public SettingsNavigationMenuItem SelectedEntry
        {
            get { return _selectedEntry; }
            set
            {
                Set(() => SelectedEntry, ref _selectedEntry, value);

                if (value != null)
                {
                    int key = (int)value.MenuItemKey;
                    switch (key)
                    {
                        case (int)SettingsMenuItemKey.MasterData:
                            //((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(UserMasterDataPage), new List<object> { false }));
                            return;
                        case (int)SettingsMenuItemKey.MaintenanceReminder:
                            //((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(MaintenanceReminderPage)));
                            return;
                        case (int)SettingsMenuItemKey.Disclaimer:
                            //((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(DisclaimerPage)));
                            return;
                    }
                }

            }
        }

    }
}