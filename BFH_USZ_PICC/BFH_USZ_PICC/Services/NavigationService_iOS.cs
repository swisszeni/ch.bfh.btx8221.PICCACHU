using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Views;
using Xamarin.Forms;
using BFH_USZ_PICC.ViewModels;
using BFH_USZ_PICC.Controls;

namespace BFH_USZ_PICC.Services
{
    public class NavigationService_iOS : NavigationService
    {
        public NavigationService_iOS() : base()
        {

        }

        public async override Task PushViewDirectOnStack(Page pushingPage, bool modal = false)
        {
            INavigation nav = null;
            if (Application.Current.MainPage is MainPage_iOS)
            {
                nav = (Application.Current.MainPage as MainPage_iOS).CurrentPage.Navigation;
            }
            else if (Application.Current.MainPage != null)
            {
                nav = Application.Current.MainPage.Navigation;
            }

            if (modal)
            {
                await nav?.PushAsync(pushingPage);
            }
            else
            {
                await nav?.PushModalAsync(pushingPage);
            }
        }

        public async override Task NavigateBackAsync()
        {
            if (Application.Current.MainPage is MainPage_iOS)
            {
                var mainPage = Application.Current.MainPage as MainPage_iOS;
                await mainPage.CurrentPage.Navigation.PopAsync();
            }
            else if (Application.Current.MainPage != null)
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        public async override Task NavigateBackToRootAsync()
        {
            if (Application.Current.MainPage is MainPage_iOS)
            {
                var mainPage = Application.Current.MainPage as MainPage_iOS;
                await mainPage.CurrentPage.Navigation.PopToRootAsync();
            }
            else if (Application.Current.MainPage != null)
            {
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
        }

        protected async override Task InternalNavigateToMenuEntryAsync(MenuItemKey key, List<object> navParams)
        {
            // Check if main navigation Structure exists
            var mainPage = Application.Current.MainPage as MainPage_iOS;
            if (mainPage == null)
            {
                throw new Exception("Need MainPage to navigate.");
            }

            // We want to navigate to one of the main menu entries
            // First check if we not already are on this menu entry
            Type pageType = GetPageTypeForMenuKey(key);
            var currNavPage = (mainPage.CurrentPage as NavigationPage);
            if (pageType != (currNavPage?.CurrentPage as BasePage)?.GetContentType())
            {
                // Pop current stack to root. technically this shouldn't be a problem. but if the construct stays in memory, it could get one
                if (currNavPage != null)
                {
                    await currNavPage.PopToRootAsync();
                }
                mainPage.TrySetCurrentPage(pageType);
            }
        }

        protected async override Task InternalNavigateToAsync(Type viewModelType, List<object> navParams)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            Page page = null;

            if (viewModelType == typeof(OnBoardingViewModel))
            {
                // We want to navigate to one of the most basic views within the App, set it as main page
                page = Activator.CreateInstance(pageType) as Page;
                Application.Current.MainPage = page;
                await (page?.BindingContext as ViewModelBase)?.InitializeAsync(navParams);
            }
            else if (viewModelType == typeof(MainViewModel))
            {
                // We want to navigate to one of the most basic views within the App, set it as main page
                page = Activator.CreateInstance(pageType) as Page;
                InitializeMainPage((MainPage_iOS)page);
                await InitializeCurrentTabBarRootPage(navParams);
            }
            else if (Application.Current.MainPage is MainPage_iOS)
            {
                // We don't want to navigate to one of the roots and the current root is the MainPage (Navigation Shell)
                var mainPage = Application.Current.MainPage as MainPage_iOS;
                page = new BasePage(pageType);
                var navigationPage = mainPage.CurrentPage as USZ_PICC_NavigationPage;

                if (navigationPage != null)
                {
                    await (page as BasePage)?.ContentBindingContext?.InitializeAsync(navParams);
                    await navigationPage.Navigation.PushAsync(page);
                }
            }
        }

        private void InitializeMainPage(MainPage_iOS mainPage)
        {
            Application.Current.MainPage = mainPage;

            var menuVM = (mainPage.BindingContext as MainViewModel)?.MenuViewModel;
            if (menuVM != null)
            {
                foreach (var menuItem in menuVM.MenuItems)
                {
                    if (menuItem.MenuItemKey != MenuItemKey.Glossary)
                    {
                        var basePage = new BasePage(GetPageTypeForMenuKey(menuItem.MenuItemKey));
                        mainPage.AddRootPage(menuItem, new USZ_PICC_NavigationPage(basePage));
                    }
                }

                // Add the Settings manually since not included in the normal menu items
                var settingMenuItem = menuVM.SettingsMenuItem;
                var settingsPage = new BasePage(GetPageTypeForMenuKey(settingMenuItem.MenuItemKey));
                mainPage.AddRootPage(settingMenuItem, new USZ_PICC_NavigationPage(settingsPage));
            }
        }

        private async Task InitializeCurrentTabBarRootPage(List<object> navParams)
        {
            var mainPage = Application.Current.MainPage as MainPage_iOS;
            await ((mainPage.CurrentPage as USZ_PICC_NavigationPage).CurrentPage as BasePage).ContentBindingContext.InitializeAsync(navParams);
        }
    }
}
