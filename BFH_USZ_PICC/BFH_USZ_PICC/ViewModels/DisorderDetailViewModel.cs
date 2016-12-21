using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
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
                Application.Current.MainPage.DisplayAlert(AppResources.FailedText, AppResources.CallUSZTelemedicineNotPossibleText, AppResources.OkButtonText);
            }
        }));

        private async void CallHealthcareProfessional()
        {
            bool call = await Application.Current.MainPage.DisplayAlert(AppResources.WarningText,AppResources.CallUSZTelemedicineText, AppResources.YesButtonText, AppResources.NoButtonText);
            if (call)
            {
                var dialer = DependencyService.Get<ICaller>();
                if (dialer != null)
                    dialer.Dial("0041442557240");
            }
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            if(parameter is List<object> && ((List<object>)parameter).Count > 0)
            {
                DisplayingEntry = (DisorderEntry)((List<object>)parameter).First();
            }
            // Return "fake task" since Task.CompletedTask is not supported in this PCL
            return Task.FromResult(false);
        }
    }
}
