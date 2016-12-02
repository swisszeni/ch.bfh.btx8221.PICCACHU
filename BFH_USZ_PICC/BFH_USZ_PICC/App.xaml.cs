using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BFH_USZ_PICC
{
    public partial class Application : Xamarin.Forms.Application
    {
        public Application()
        {
            InitializeComponent();

            MainPage = new Shell();
        }

        protected override void OnStart()
        {            
            // Handle when your app startss
            SetLocale();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            SetLocale();
        }

        /// <summary>
        /// Sets the current locale defined in the OS. For iOS and Andoid only as UWP does this automatially
        /// </summary>
        protected void SetLocale()
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
