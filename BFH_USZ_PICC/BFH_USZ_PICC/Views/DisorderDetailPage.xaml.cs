using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
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
                Application.Current.MainPage.DisplayAlert(AppResources.InformationText, AppResources.CallUSZTelemedicineNotPossibleText, AppResources.OkButtonText);
            }
        }

        async void CallUSZTelemedizin()
        {
            bool call = await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.CallUSZTelemedicineText, AppResources.YesButtonText, AppResources.NoButtonText);
            if (call)
            {
                var dialer = DependencyService.Get<ICaller>();
                if (dialer != null)
                    dialer.Dial("0764979662");
            }
        }
    }
}
