using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static BFH_USZ_PICC.Models.JournalEntry;

namespace BFH_USZ_PICC.ViewModels.JournalEntries
{
    public class BandageChangingViewModel : JournalEntryBaseViewModel<BandageChangingEntry>
    {
        public BandageChangingViewModel() { }

        #region navigation events

        /// <summary>
        /// Displays an Alert asking the user to show the Instruction for the Maintenance
        /// </summary>
        public async override void OnFirstAppearance()
        {
            if (IsUserInputEnabled)
            {
                if (await DisplayAlert(AppResources.InformationText, AppResources.JournalEntriesAskForMainentanceInstructionText, AppResources.YesButtonText, AppResources.NoButtonText))
                {
                    await NavigationService.NavigateToAsync<MaintenanceInstructionViewModel>(new List<object> { MainentanceInstructions.getBandageChangingInstruction() });
                }
            }
        }

        #endregion

        #region private methods

        protected override void LoadFromModel()
        {
            ChangementReason = _displayingEntry?.ChangementReason == null ? 0 : _displayingEntry.ChangementReason;
            ChangementArea = _displayingEntry?.ChangementArea == null ? 0 : _displayingEntry.ChangementArea;
            Puncture = _displayingEntry?.Puncture == null ? 0 : _displayingEntry.Puncture;
            ArmProcess = _displayingEntry?.ArmProcess == null ? 0 : _displayingEntry.ArmProcess;

            base.LoadFromModel();
        }

        protected override void SaveToModel()
        {
            _displayingEntry.ChangementReason = ChangementReason;
            _displayingEntry.ChangementArea = ChangementArea;
            _displayingEntry.Puncture = Puncture;
            _displayingEntry.ArmProcess = ArmProcess;

            base.SaveToModel();
        }

        #endregion

        #region public properties

        private BandageChangementReason _changementReason;
        public BandageChangementReason ChangementReason
        {
            get { return _changementReason; }
            set { Set(ref _changementReason, value); }
        }

        private BandageChangementArea _changementArea;
        public BandageChangementArea ChangementArea
        {
            get { return _changementArea; }
            set { Set(ref _changementArea, value); }
        }

        private BandagePunctureSituation _puncture;
        public BandagePunctureSituation Puncture
        {
            get { return _puncture; }
            set { Set(ref _puncture, value); }
        }

        private BandageArmProcessSituation _armProcess;
        public BandageArmProcessSituation ArmProcess
        {
            get { return _armProcess; }
            set { Set(ref _armProcess, value); }
        }

        #endregion

    }
}
