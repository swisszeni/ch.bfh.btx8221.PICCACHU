using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using BFH_USZ_PICC.Views;
using BFH_USZ_PICC.ViewModels.JournalEntries;
using BFH_USZ_PICC.Views.JournalEntries;
using Xamarin.Forms;
using BFH_USZ_PICC.Controls;

namespace BFH_USZ_PICC.Services
{
    public class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> _viewModelmappings;
        protected readonly Dictionary<MenuItemKey, Type> _menuKeymappings;

        public NavigationService()
        {
            _viewModelmappings = new Dictionary<Type, Type>();
            _menuKeymappings = new Dictionary<MenuItemKey, Type>();

            CreatePageViewModelMappings();
            CreateMenuKeyPageMappings();
        }

        #region INavigationService Implementation

        public Task InitializeAsync()
        {
            if (SettingsService.FirstAppExecution)
            {
                // first execution, navigate to onboarding
                // return NavigateToAsync<OnBoardingViewModel>();
                return NavigateToAsync<MainViewModel>();
            } else
            {
                // app has already run at least once, navigate to normal MainView
                return NavigateToAsync<MainViewModel>();
            }
        }
        
        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return NavigateToAsync<TViewModel>(null);
        }

        public Task NavigateToAsync(MenuItemKey pageKey)
        {
            return NavigateToAsync(pageKey, null);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return NavigateToAsync(viewModelType, null);
        }

        public Task NavigateToAsync<TViewModel>(List<object> navParams) where TViewModel : ViewModelBase
        {
            Type vmType = typeof(TViewModel);
            MenuItemKey menuKey = MenuItemKey.PICC;
            if (ViewModelIsMenuPage(vmType, ref menuKey))
            {
                return NavigateToAsync(menuKey, navParams);
            }

            return InternalNavigateToAsync(vmType, navParams);
        }

        public Task NavigateToAsync(MenuItemKey pageKey, List<object> navParams)
        {
            return InternalNavigateToMenuEntryAsync(pageKey, navParams);
        }

        public Task NavigateToAsync(Type viewModelType, List<object> navParams)
        {
            return InternalNavigateToAsync(viewModelType, navParams);
        }

        public virtual async Task PushViewDirectOnStack(Page pushingPage, bool modal = false)
        {
            INavigation nav = null;
            if (Application.Current.MainPage is MainPage)
            {
                nav = (Application.Current.MainPage as MainPage).Detail.Navigation;
            } else if(Application.Current.MainPage != null)
            {
                nav = Application.Current.MainPage.Navigation;
            }

            if(modal)
            {
                await nav?.PushAsync(pushingPage);
            } else
            {
                await nav?.PushModalAsync(pushingPage);
            }
        }

        public Task DeepNavigateToAsync(Type deepViewModelType, MenuItemKey basePageKey)
        {
            throw new NotImplementedException();
        }

        public Task DeepNavigateToAsync<TViewModel>(MenuItemKey basePageKey) where TViewModel : ViewModelBase
        {
            throw new NotImplementedException();
        }

        public Task DeepNavigateToAsync(Type deepViewModelType, MenuItemKey basePageKey, List<object> deepPagenavParams)
        {
            throw new NotImplementedException();
        }

        public Task DeepNavigateToAsync<TViewModel>(MenuItemKey basePageKey, List<object> deepPagenavParams) where TViewModel : ViewModelBase
        {
            throw new NotImplementedException();
        }

        public async virtual Task NavigateBackAsync()
        {
            if (Application.Current.MainPage is MainPage)
            {
                var mainPage = Application.Current.MainPage as MainPage;
                await mainPage.Detail.Navigation.PopAsync();
            }
            else if (Application.Current.MainPage != null)
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        public async virtual Task NavigateBackToRootAsync()
        {
            if (Application.Current.MainPage is MainPage)
            {
                var mainPage = Application.Current.MainPage as MainPage;
                await mainPage.Detail.Navigation.PopToRootAsync();
            }
            else if (Application.Current.MainPage != null)
            {
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
        }

        public Task RemoveLastFromBackStackAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the mapping from a ViewModel to its corresponding View.
        /// This allows for navigation by ViewModel and thus loading different
        /// Views for the VM depending on the current Device OS or Idiom
        /// </summary>
        private void CreatePageViewModelMappings()
        {
            if (Device.OS == TargetPlatform.iOS)
            {
                _viewModelmappings.Add(typeof(MainViewModel), typeof(MainPage_iOS));
            } else
            {
                _viewModelmappings.Add(typeof(MainViewModel), typeof(MainPage));
            }

            _viewModelmappings.Add(typeof(OnBoardingViewModel), typeof(OnBoardingPage));

            // My PICC
            _viewModelmappings.Add(typeof(PICCOverviewViewModel), typeof(PICCOverviewPage));
            _viewModelmappings.Add(typeof(PICCAddViewModel), typeof(PICCAddPage));
            _viewModelmappings.Add(typeof(PICCDetailViewModel), typeof(PICCDetailPage));
            _viewModelmappings.Add(typeof(PICCFormerDetailViewModel), typeof(PICCFormerDetailPage));

            // Knowledge Base
            _viewModelmappings.Add(typeof(KnowledgeBaseViewModel), typeof(KnowledgeBasePage));
            _viewModelmappings.Add(typeof(KnowledgeEntriesViewModel), typeof(KnowledgeEntriesPage));
            _viewModelmappings.Add(typeof(KnowledgeEntryDetailViewModel), typeof(KnowledgeEntryDetailPage));
            _viewModelmappings.Add(typeof(PictureViewModel), typeof(PicturePage));
            _viewModelmappings.Add(typeof(GlossaryViewModel), typeof(GlossaryPage));

            // Disorders
            _viewModelmappings.Add(typeof(DisorderViewModel), typeof(DisorderPage));
            _viewModelmappings.Add(typeof(DisorderDetailViewModel), typeof(DisorderDetailPage));

            // Journal
            _viewModelmappings.Add(typeof(JournalOverviewViewModel), typeof(JournalOverviewPage));
            _viewModelmappings.Add(typeof(AdministeredDrugViewModel), typeof(AdministeredDrugEntryPage));
            _viewModelmappings.Add(typeof(BandageChangingViewModel), typeof(BandageChangingEntryPage));
            _viewModelmappings.Add(typeof(BloodWithdrawalViewModel), typeof(BloodWithdrawalEntryPage));
            _viewModelmappings.Add(typeof(CatheterFlushViewModel), typeof(CatheterFlushEntryPage));
            _viewModelmappings.Add(typeof(InfusionViewModel), typeof(InfusionEntryPage));
            _viewModelmappings.Add(typeof(MicroClaveChangingViewModel), typeof(MicroClaveChangingEntryPage));
            _viewModelmappings.Add(typeof(StatlockChangingViewModel), typeof(StatlockChangingEntryPage));
            _viewModelmappings.Add(typeof(MaintenanceInstructionViewModel), typeof(MaintenanceInstructionPage));

            // Settings
            _viewModelmappings.Add(typeof(SettingsViewModel), typeof(SettingsPage));
            _viewModelmappings.Add(typeof(SettingsMasterDataViewModel), typeof(SettingsMasterDataPage));
            _viewModelmappings.Add(typeof(SettingsMaintenanceReminderViewModel), typeof(SettingsMaintenanceReminderPage));
            _viewModelmappings.Add(typeof(SettingsDisclaimerViewModel), typeof(SettingsDisclaimerPage));
            _viewModelmappings.Add(typeof(SettingsImprintViewModel), typeof(SettingsImprintPage));
        }

        private void CreateMenuKeyPageMappings()
        {
            _menuKeymappings.Add(MenuItemKey.PICC, typeof(PICCOverviewPage));
            if (Device.OS == TargetPlatform.iOS)
            {
                _menuKeymappings.Add(MenuItemKey.Knowledge, typeof(KnowledgeBasePage));
            } else
            {
                _menuKeymappings.Add(MenuItemKey.Knowledge, typeof(KnowledgeEntriesPage));
            }
            
            _menuKeymappings.Add(MenuItemKey.Glossary, typeof(GlossaryPage));
            _menuKeymappings.Add(MenuItemKey.Disorder, typeof(DisorderPage));
            _menuKeymappings.Add(MenuItemKey.Journal, typeof(JournalOverviewPage));
            _menuKeymappings.Add(MenuItemKey.Settings, typeof(SettingsPage));
        }

        protected bool ViewModelIsMenuPage(Type viewModelType, ref MenuItemKey menuKey)
        {
            Type pageType;
            try
            {
                pageType = GetPageTypeForViewModel(viewModelType);
            } catch
            {
                return false;
            }

            if(pageType != null && _menuKeymappings.ContainsValue(pageType))
            {
                menuKey = _menuKeymappings.FirstOrDefault(x => x.Value == pageType).Key;
                return true;
            }

            return false;
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_viewModelmappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _viewModelmappings[viewModelType];
        }

        protected Type GetPageTypeForMenuKey(MenuItemKey key)
        {
            if (!_menuKeymappings.ContainsKey(key))
            {
                throw new KeyNotFoundException($"No map for ${key} was found on navigation mappings");
            }

            return _menuKeymappings[key];
        }

        protected virtual async Task InternalNavigateToMenuEntryAsync(MenuItemKey key, List<object> navParams)
        {
            // Check if main navigation Structure exists
            var mainPage = Application.Current.MainPage as MainPage;
            if (mainPage == null)
            {
                throw new Exception("Need MainPage to navigate.");
            }

            // We want to navigate to one of the main menu entries
            // First check if we not already are on this menu entry
            Type pageType = GetPageTypeForMenuKey(key);
            var currNavPage = (mainPage.Detail as NavigationPage);
            if (pageType != (currNavPage?.CurrentPage as BasePage)?.GetContentType())
            {
                var page = new BasePage(pageType);
                await (page as BasePage)?.ContentBindingContext?.InitializeAsync(navParams);
                // Pop current stack to root. technically this shouldn't be a problem. but if the construct stays in memory, it could get one
                if(currNavPage != null)
                {
                    await currNavPage.PopToRootAsync();
                }
                mainPage.Detail = new USZ_PICC_NavigationPage(page);
            }

            mainPage.IsPresented = false;
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, List<object> navParams)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            Page page = null;

            if (viewModelType == typeof(OnBoardingViewModel) || viewModelType == typeof(MainViewModel))
            {
                // We want to navigate to one of the most basic views within the App, set it as main page
                page = Activator.CreateInstance(pageType) as Page;
                Application.Current.MainPage = page;

                await (page?.BindingContext as ViewModelBase)?.InitializeAsync(navParams);
            } else if (Application.Current.MainPage is MainPage)
            {
                // We don't want to navigate to one of the roots and the current root is the MainPage (Navigation Shell)
                page = new BasePage(pageType);
                var mainPage = Application.Current.MainPage as MainPage;
                var navigationPage = mainPage.Detail as USZ_PICC_NavigationPage;

                if (navigationPage != null)
                {
                    await (page as BasePage)?.ContentBindingContext?.InitializeAsync(navParams);
                    await navigationPage.Navigation.PushAsync(page);
                }
            }
        }

        #endregion

    }
}
