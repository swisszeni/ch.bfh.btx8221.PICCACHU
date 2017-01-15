using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;

namespace BFH_USZ_PICC.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public MenuViewModel()
        {
            _menuItems = new List<NavigationMenuItem>
                {
                    new NavigationMenuItem { Title = AppResources.MyPICCPageTitleText, MenuItemKey = MenuItemKey.PICC},
                    new NavigationMenuItem { Title = AppResources.KnowledgeEntriesTitleText, MenuItemKey = MenuItemKey.Knowledge},
                    new NavigationMenuItem { Title = AppResources.DisorderPageTitleText, MenuItemKey = MenuItemKey.Disorder},
                    new NavigationMenuItem { Title = AppResources.JournalOverviewPageTitleText, MenuItemKey = MenuItemKey.Journal}
                };
        }

        private List<NavigationMenuItem> _menuItems;
        public List<NavigationMenuItem> MenuItems => _menuItems;

        #region RelayCommands

        private RelayCommand<NavigationMenuItem> _itemSelectedCommand;
        public RelayCommand<NavigationMenuItem> ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<NavigationMenuItem>((NavigationMenuItem selectedItem) =>
        {
            // Item selected, handle navigation
            //selectedItem
        }));

        #endregion
    }
}