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




            //if (pageType != ((mainPage.Detail as NavigationPage)?.CurrentPage as BasePage)?.GetContentType())
            //{
            //    var page = new BasePage(pageType);
            //    await(page as BasePage)?.ContentBindingContext?.InitializeAsync(navParams);
            //    mainPage.Detail = new USZ_PICC_NavigationPage(page);
            //}

            //mainPage.IsPresented = false;
        }

        protected async override Task InternalNavigateToAsync(Type viewModelType, List<object> navParams)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            Page page = null;

            if(viewModelType == typeof(OnBoardingViewModel))
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
                Application.Current.MainPage = page;

                await (page?.BindingContext as ViewModelBase)?.InitializeAsync(navParams);
            }















            //if (viewModelType == typeof(OnBoardingViewModel) || viewModelType == typeof(MainViewModel))
            //{
            //    // We want to navigate to one of the most basic views within the App, set it as main page
            //    page = Activator.CreateInstance(pageType) as Page;
            //    Application.Current.MainPage = page;

            //    await (page?.BindingContext as ViewModelBase)?.InitializeAsync(navParams);
            //}
            //else if (Application.Current.MainPage is MainPage)
            //{
            //    // We don't want to navigate to one of the roots and the current root is the MainPage (Navigation Shell)
            //    page = new BasePage(pageType);
            //    var mainPage = Application.Current.MainPage as MainPage;
            //    var navigationPage = mainPage.Detail as USZ_PICC_NavigationPage;

            //    if (navigationPage != null)
            //    {
            //        await(page as BasePage)?.ContentBindingContext?.InitializeAsync(navParams);
            //        await navigationPage.Navigation.PushAsync(page);
            //    }
            //}
        }

        private void InitializeMainPage(MainPage_iOS mainPage)
        {
            var mainVM = mainPage.BindingContext as MenuViewModel;
            if (mainVM != null)
            {
                foreach (var menuItem in mainVM.MenuItems)
                {
                    var basePage = new BasePage(GetPageTypeForMenuKey(menuItem.MenuItemKey));
                    mainPage.AddRootPage(menuItem, new USZ_PICC_NavigationPage(basePage));
                }
            }


        //new BasePage(typeof)
        //mainPage.AddRootPage();
    }
}
}
