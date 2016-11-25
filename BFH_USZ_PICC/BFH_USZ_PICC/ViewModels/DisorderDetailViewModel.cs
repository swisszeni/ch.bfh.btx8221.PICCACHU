using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.ViewModels
{
    public class DisorderDetailViewModel : ViewModelBase
    {
        private DisorderEntry _displayingEntry;
        public DisorderEntry DisplayingEntry
        {
            get { return _displayingEntry; }
            set
            {
                if(Set(ref _displayingEntry, value))
                {
                    // Update all bindings
                    RaisePropertyChanged("");
                }
            }
        }

        public string Symptom => DisplayingEntry?.Symptom;
        public string Reason => DisplayingEntry?.Reason;
        public string Action => DisplayingEntry?.Action;

        private RelayCommand _contactHealthcareProfessionalCommand;
        public RelayCommand ContactHealthcareProfessionalCommand => _contactHealthcareProfessionalCommand ?? (_contactHealthcareProfessionalCommand = new RelayCommand(() =>
        {
            if (DependencyService.Get<ICaller>().CanMakePhonecall())
            {
                CallHealthcareProfessional();
            }
            else
            {
                // TODO: Translate strings
                Application.Current.MainPage.DisplayAlert("Fehlgeschlagen", "Ihr Gerät kann die USZ Telemedizin nicht anrufen.\nKontaktieren sie 044 666 66 66", "Ok");
            }
        }));

        private async void CallHealthcareProfessional()
        {
            // TODO: Translate strings
            bool call = await Application.Current.MainPage.DisplayAlert("Warnung", "USZ Telemedizin wirklich anrufen?", "Ja", "Nein");
            if (call)
            {
                var dialer = DependencyService.Get<ICaller>();
                if (dialer != null)
                    dialer.Dial("0764979662");
            }
        }
    }
}
