using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;

namespace BFH_USZ_PICC.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        INavigationService _navigationService;

        public MenuViewModel()
        {
            _navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            _menuItems = new List<NavigationMenuItem>
                {
                    new NavigationMenuItem { Title = AppResources.MyPICCPageTitleText, MenuItemKey = MenuItemKey.PICC},
                    new NavigationMenuItem { Title = AppResources.KnowledgeEntriesTitleText, MenuItemKey = MenuItemKey.Knowledge},
                    new NavigationMenuItem { Title = AppResources.GlossaryPageTitleText, MenuItemKey = MenuItemKey.Glossary},
                    new NavigationMenuItem { Title = AppResources.DisorderPageTitleText, MenuItemKey = MenuItemKey.Disorder},
                    new NavigationMenuItem { Title = AppResources.JournalOverviewPageTitleText, MenuItemKey = MenuItemKey.Journal}
                };

            _settingsMenuItem = new NavigationMenuItem { Title = AppResources.SettingsPageTitleText, MenuItemKey = MenuItemKey.Settings };
        }

        private List<NavigationMenuItem> _menuItems;
        public List<NavigationMenuItem> MenuItems => _menuItems;

        public NavigationMenuItem _settingsMenuItem;
        public NavigationMenuItem SettingsMenuItem => _settingsMenuItem;

        #region RelayCommands

        private RelayCommand<NavigationMenuItem> _itemSelectedCommand;
        public RelayCommand<NavigationMenuItem> ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<NavigationMenuItem>((NavigationMenuItem selectedItem) =>
        {
            // Item selected, handle navigation
            _navigationService.NavigateToAsync(selectedItem.MenuItemKey);
        }));

        private RelayCommand _goToSettingsCommand;
        public RelayCommand GoToSettingsCommand => _goToSettingsCommand ?? (_goToSettingsCommand = new RelayCommand(() =>
        {
            // Button pressed, handle navigation
            _navigationService.NavigateToAsync(MenuItemKey.Settings);
        }));

        #endregion
    }
}