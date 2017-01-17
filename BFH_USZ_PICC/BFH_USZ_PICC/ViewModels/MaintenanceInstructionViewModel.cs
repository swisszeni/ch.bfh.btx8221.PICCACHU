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

        #region navigation events

        public override Task InitializeAsync(List<object> navigationData)
        {
            if (navigationData is List<object> && ((List<object>)navigationData).Count > 0)
            {
                var param = ((List<object>)navigationData).First();
                if (param.GetType() == typeof(MaintenanceInstruction))
                {
                    // Make sure that the new loaded instruction starts at the frist step
                    CarouselPosition = 0;
                    MaintenanceInstruction = (MaintenanceInstruction)param;
                }
            }

            return base.InitializeAsync(navigationData);
        }

        #endregion

        #region public properties

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

        #endregion

        #region relay commands

        private RelayCommand _toggleTextToVoiceCommand;
        public RelayCommand ToggleTextToVoiceCommand => _toggleTextToVoiceCommand ?? (_toggleTextToVoiceCommand = new RelayCommand(() =>
        {
            CrossTextToSpeech.Current.Speak(MaintenanceInstruction?.InstructionSteps.ElementAt(CarouselPosition).Explanation);

            // TODO: FULLY IMPLEMENT
        }));

        private RelayCommand _toggleVoiceControlCommand;
        public RelayCommand ToggleVoiceControlCommand => _toggleVoiceControlCommand ?? (_toggleVoiceControlCommand = new RelayCommand(() =>
        {
            // TODO: FULLY IMPLEMENT
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

        #endregion
        
    }
}
