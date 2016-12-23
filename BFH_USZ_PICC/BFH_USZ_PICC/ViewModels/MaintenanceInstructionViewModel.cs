using BFH_USZ_PICC.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Plugin.TextToSpeech;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels
{
    public class MaintenanceInstructionViewModel : ViewModelBase
    {
        private List<MaintenanceInstruction> _maintenanceInstructionSteps;
        public List<MaintenanceInstruction> MaintenanceInstructionSteps
        {
            get { return _maintenanceInstructionSteps; }
            set { Set(ref _maintenanceInstructionSteps, value); }
        }

        private int _carouselPosition;
        public int CarouselPosition
        {
            get { return _carouselPosition; }
            set
            {
                if (Set(ref _carouselPosition, value))
                {
                    RaisePropertyChanged(() => CarouselPositionText);
                }
            }
        }

        public string CarouselPositionText
        {
            get { return $"{CarouselPosition+1}"; }
        }

        private RelayCommand _toggleTextToVoiceCommand;
        public RelayCommand ToggleTextToVoiceCommand => _toggleTextToVoiceCommand ?? (_toggleTextToVoiceCommand = new RelayCommand(() =>
        {
            
            CrossTextToSpeech.Current.Speak(MaintenanceInstructionSteps.ElementAt(CarouselPosition).Explanation);
            //Check if the user really wants to leave the page
            //if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.CancelButtonPressedConfirmationText, AppResources.YesButtonText, AppResources.NoButtonText))
            //{
            //    await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            //}
        }));

        private RelayCommand _toggleVoiceControlCommand;
        public RelayCommand ToggleVoiceControlCommand => _toggleVoiceControlCommand ?? (_toggleVoiceControlCommand = new RelayCommand(async () =>
        {
            //Check if the user really wants to leave the page
            //if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.CancelButtonPressedConfirmationText, AppResources.YesButtonText, AppResources.NoButtonText))
            //{
            //    await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            //}
        }));

        private RelayCommand _goToPreviousStepCommand;
        public RelayCommand GoToPreviousStepCommand => _goToPreviousStepCommand ?? (_goToPreviousStepCommand = new RelayCommand(async () =>
        {
            //Check if the user really wants to leave the page
            //if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.CancelButtonPressedConfirmationText, AppResources.YesButtonText, AppResources.NoButtonText))
            //{
            //    await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            //}
        }, () => { return CarouselPosition > 0; }));

        private RelayCommand _goToNextStepCommand;
        public RelayCommand GoToNextStepCommand => _goToNextStepCommand ?? (_goToNextStepCommand = new RelayCommand(async () =>
        {
            //Check if the user really wants to leave the page
            //if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.CancelButtonPressedConfirmationText, AppResources.YesButtonText, AppResources.NoButtonText))
            //{
            //    await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            //}
        }, () => { return CarouselPosition < 0; }));
    }
}
