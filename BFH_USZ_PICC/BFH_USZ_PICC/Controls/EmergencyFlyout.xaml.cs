using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.ViewModels;
using BFH_USZ_PICC.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Controls
{
    public partial class EmergencyFlyout : Grid
    {

        public EmergencyFlyout()
        {
            InitializeComponent();

            // add a tapgesture recognizer to the background
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) =>
            {
                this.IsVisible = false;
            };
            BackgroundGrid.GestureRecognizers.Add(tapGesture);
        }

        void DisorderButton_Clicked(object sender, EventArgs e)
        {
            ServiceLocator.Current.GetInstance<INavigationService>().NavigateToAsync(MenuItemKey.Disorder);
        }

        void CallUSZTelemedizinButton_Clicked(object sender, EventArgs e)
        {
            if (DependencyService.Get<ICaller>().CanMakePhonecall())
            {
                CallUSZTelemedizin();
            }
            else
            {
                Application.Current.MainPage.DisplayAlert(AppResources.FailedText, AppResources.CallUSZTelemedicineNotPossibleText, AppResources.OkButtonText);
            }
        }

        async void CallUSZTelemedizin()
        {
            bool call = await Application.Current.MainPage.DisplayAlert(AppResources.InformationText, AppResources.CallUSZTelemedicineText, AppResources.YesButtonText, AppResources.NoButtonText);
            if (call)
            {
                var dialer = DependencyService.Get<ICaller>();
                if (dialer != null)
                {
                    // Originalnummer PICC Telemedizin USZ: +41 44 255 72 40
                    dialer.Dial("0041442557240");
                }
            }
        }
    }
}
