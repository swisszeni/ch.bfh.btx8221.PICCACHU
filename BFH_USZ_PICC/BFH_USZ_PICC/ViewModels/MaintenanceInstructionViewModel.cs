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
using BFH_USZ_PICC.Interfaces;

namespace BFH_USZ_PICC.ViewModels
{
    public class MaintenanceInstructionViewModel : ViewModelBase
    {
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            if (parameter is List<object> && ((List<object>)parameter).Count > 0)
            {
                //Make sure that the new loaded instruction starts at the frist step
                CarouselPosition = 0;
                MaintenanceInstruction = (MaintenanceInstruction)((List<object>)parameter).First();                

            }
            // Return "fake task" since Task.CompletedTask is not supported in this PCL
            return Task.FromResult(false);
        }

        private MaintenanceInstruction _maintenanceInstruction;
        public MaintenanceInstruction MaintenanceInstruction
        {
            get { return _maintenanceInstruction; }
            set
            {
                if (Set(ref _maintenanceInstruction, value))
                {                   
                    RaisePropertyChanged(() => CarouselPositionText);
                    GoToPreviousStepCommand.RaiseCanExecuteChanged();
                    GoToNextStepCommand.RaiseCanExecuteChanged();                   
                }
            }
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
                    GoToPreviousStepCommand.RaiseCanExecuteChanged();
                    GoToNextStepCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string CarouselPositionText
        {
            get
            {
                return String.Format(Resx.AppResources.MaintenaceInstructionCurrentPageNumberText, CarouselPosition + 1, MaintenanceInstruction?.InstructionSteps.Count);
            }
        }

        private RelayCommand _toggleTextToVoiceCommand;
        public RelayCommand ToggleTextToVoiceCommand => _toggleTextToVoiceCommand ?? (_toggleTextToVoiceCommand = new RelayCommand(() =>
        {
            // TODO: FIX
            CrossTextToSpeech.Current.Speak(MaintenanceInstruction?.InstructionSteps.ElementAt(CarouselPosition).Explanation);
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
        public RelayCommand GoToPreviousStepCommand => _goToPreviousStepCommand ?? (_goToPreviousStepCommand = new RelayCommand(() =>
        {
            if (CarouselPosition > 0)
            {
                CarouselPosition--;
            }
        }, () => { return CarouselPosition > 0; }));

        private RelayCommand _goToNextStepCommand;
        public RelayCommand GoToNextStepCommand => _goToNextStepCommand ?? (_goToNextStepCommand = new RelayCommand(() =>
        {
            if (CarouselPosition < MaintenanceInstruction?.InstructionSteps.Count - 1)
            {
                CarouselPosition++;
            }
        }, () => { return CarouselPosition < MaintenanceInstruction?.InstructionSteps.Count - 1; }));
    }
}
