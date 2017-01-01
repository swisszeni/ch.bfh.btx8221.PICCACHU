using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC
{
    public partial class Application : Xamarin.Forms.Application
    {
        public Application()
        {
            InitializeComponent();

            if (Device.OS == TargetPlatform.Windows)
            {
                InitNavigation();
            }
        }

        protected override async void OnStart()
        {
            base.OnStart();

            SetLocale();

            if (Device.OS != TargetPlatform.Windows)
            {
                await InitNavigation();
            }
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
            SetLocale();
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        /// <summary>
        /// Sets the current locale defined in the OS. For iOS and Andoid only as UWP does this automatially
        /// </summary>
        private void SetLocale()
        {
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                // set the RESX for resource localization
                Resx.AppResources.Culture = ci;
                // set the Thread for locale-aware methods
                DependencyService.Get<ILocalize>().SetLocale(ci);
            }
        }
    }
}
