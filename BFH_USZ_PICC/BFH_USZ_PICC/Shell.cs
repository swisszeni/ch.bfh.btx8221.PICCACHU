using BFH_USZ_PICC.Controls;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.Services;
using BFH_USZ_PICC.ViewModels;
using BFH_USZ_PICC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static BFH_USZ_PICC.Views.UserMasterDataPage;

namespace BFH_USZ_PICC
{
    public class Shell : MasterDetailPage
    {
        Dictionary<MenuItemKey, NavigationPage> Pages { get; set; }

        public Shell()
        {
            this.MasterBehavior = MasterBehavior.Popover;

            Pages = new Dictionary<MenuItemKey, NavigationPage>();
            Master = new MenuPage(this);
            BindingContext = new BaseViewModel
            {
                Title = "USZ PICC",
                Icon = "slideout.png"
            };

            //setup home page
            NavigateAsync(MenuItemKey.PICC);

            InvalidateMeasure();
        }

        public async Task NavigateAsync(MenuItemKey id)
        {
            Page newPage;
            if (!Pages.ContainsKey(id))
            {
                switch (id)
                {
                    case MenuItemKey.PICC:
                        Pages.Add(id, new USZ_PICC_NavigationPage(new BasePage(typeof(MyPICCPage))));
                        break;
                    case MenuItemKey.Glossary:
                        Pages.Add(id, new USZ_PICC_NavigationPage(new BasePage(typeof(GlossaryPage))));
                        break;
                    case MenuItemKey.Knowledge:
                        Pages.Add(id, new USZ_PICC_NavigationPage(new BasePage(typeof(KnowledgeEntriesPage))));
                        break;
                    case MenuItemKey.Disorder:
                        Pages.Add(id, new USZ_PICC_NavigationPage(new BasePage(typeof(DisorderPage))));
                        break;
                    case MenuItemKey.Journal:
                        Pages.Add(id, new USZ_PICC_NavigationPage(new BasePage(typeof(JournalOverviewPage))));
                        break;
                    case MenuItemKey.Settings:
                        Pages.Add(id, new USZ_PICC_NavigationPage(new BasePage(typeof(SettingsPage))));
                        break;
                }
            }

            newPage = Pages[id];
            if (newPage == null)
                return;

            //pop to root
            if (Detail != null)
            {
                await Detail.Navigation.PopToRootAsync();
            }

            Detail = newPage;

            //if (IsUWPDesktop)
            //    return;

            if (Device.Idiom != TargetIdiom.Tablet)
                IsPresented = false;
        }

        public async Task DeepNavigateAsync(MenuItemKey basePageId, Type deepPageType, List<object> deepPageArgs = null)
        {
            await NavigateAsync(basePageId);
            USZ_PICC_NavigationPage basePage = (USZ_PICC_NavigationPage)Pages[basePageId];
            await basePage.PopToRootAsync();
            var baseContentPage = basePage.CurrentPage;
            await baseContentPage.Navigation.PushAsync(new BasePage(deepPageType, deepPageArgs));
        }

        private void AddPageToNavigationStructure(MenuItemKey page)
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CheckForFirstStart();
        }

        public async void CheckForFirstStart()
        {
            //Test for first start. bool should check if the user starts the app for the first time and ask him if he wants to add his personal data
            if (SettingsService.FirstAppExecution)
            {
                SettingsService.FirstAppExecution = false;
                var masterData = await AskUserToAddMasterData();
                if (masterData)
                {
                    await DeepNavigateAsync(MenuItemKey.Settings, typeof(UserMasterDataPage), new List<object> { true });
                }
            }
        }

        private async Task<bool> AskUserToAddMasterData()
        {
            return await DisplayAlert(AppResources.MasterDataText, AppResources.MasterDataBackUpQuestionText, AppResources.YesButtonText, AppResources.NoButtonText);
        }

    }
}
