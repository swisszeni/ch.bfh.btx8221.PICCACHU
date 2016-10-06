using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;


// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Controls
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public partial class EmergencyFlyout : Grid
    {

        public EmergencyFlyout()
        {
            InitializeComponent();
            
        }

        void ContactUSZTelemedizin(object sender, EventArgs e)
        {
            if (DependencyService.Get<ICaller>().CanMakePhonecall())
            {
                CallUSZTelemedizin();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Fehlgeschlagen", "Ihr Gerät kann die USZ Telemedizin nicht anrufen.\nKontaktieren sie 044 666 66 66", "Ok");
            }
        }

        async void CallUSZTelemedizin()
        {
            bool call = await App.Current.MainPage.DisplayAlert("Warnung", "USZ Telemedizin wirklich anrufen?", "Ja", "Nein");
            if (call)
            {
                var dialer = DependencyService.Get<ICaller>();
                if (dialer != null)
                    dialer.Dial("0764979662");
            }
        }
    }
}
