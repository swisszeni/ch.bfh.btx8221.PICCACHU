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
    public class Application : Xamarin.Forms.Application
    {
        public Application()
        {
            // The root page of your application
            //MainPage = new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                XAlign = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms! Hallo Florian :)"
            //            }
            //        }
            //    }
            //};

            //MainPage = new Shell();
            if (Device.OS == TargetPlatform.Windows)
            {
                OnStart();
            }
        }

        protected override async void OnStart()
        {
            MainPage = new Shell();
            // Handle when your app starts
            SetLocale();

            //FIXME Test for first start. bool should check if the user starts the app for the first time and ask him if he wants to add his master data
            bool isFirstStart = true;
            if (isFirstStart)
            {
                var masterData = await MainPage.DisplayAlert("Stammdaten", "Möchten Sie Ihre persönlichen Daten in der App hinterlegen? Sie können die Angaben jederzeit in den Einstellungen unter 'Persönliche Daten' anpassen", "Ja", "Nein");
                if (masterData)
                {
                    Shell test = new Shell();
                    MainPage = test;
                    await test.NavigateAsync(MenuItemKey.UserMasterData);
                }
            }
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
