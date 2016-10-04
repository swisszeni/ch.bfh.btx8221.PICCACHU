using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public sealed partial class DisorderDetailPage : BaseContentPage
    {
        public DisorderDetailPage(ContentPage contained, DisorderEntry selectedEntry) : base(contained)
        {
            InitializeComponent();
            BindingContext = selectedEntry;
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
