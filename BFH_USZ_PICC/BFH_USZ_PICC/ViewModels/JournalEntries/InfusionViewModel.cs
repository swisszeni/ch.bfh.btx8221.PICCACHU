using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
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
    class InfusionViewModel : JournalEntryBaseViewModel<InfusionEntry>
    {
        public InfusionViewModel() { }

        protected override void LoadFromModel()
        {
            InfusionType = _displayingEntry?.InfusionType == null ? 0 : _displayingEntry.InfusionType;
            if(InfusionType == InfusionType.Antibiotic)
            {
                AntibioticName = _displayingEntry?.AntibioticName;
            }
            InfusionAdministration = _displayingEntry?.InfusionAdministration == null ? 0 : _displayingEntry.InfusionAdministration;

            base.LoadFromModel();
        }

        protected override void SaveToModel()
        {
            _displayingEntry.InfusionType = InfusionType;
            if (InfusionType == InfusionType.Antibiotic)
            {
                _displayingEntry.AntibioticName = AntibioticName;
            }
            _displayingEntry.InfusionAdministration = InfusionAdministration;

            base.SaveToModel();
        }

        private InfusionType _infusionType;
        public InfusionType InfusionType
        {
            get { return _infusionType; }
            set
            {
                IsTypeAntibiotic = value == InfusionType.Antibiotic;
                Set(ref _infusionType, value);
            }
        }

        private string _antibioticName;
        public string AntibioticName
        {
            get { return _antibioticName; }
            set { Set(ref _antibioticName, value); }
        }

        private InfusionAdministration _infusionAdministration;
        public InfusionAdministration InfusionAdministration
        {
            get { return _infusionAdministration; }
            set { Set(ref _infusionAdministration, value); }
        }

        private bool _isTypeAntibiotic;
        public bool IsTypeAntibiotic
        {
            get { return _isTypeAntibiotic; }
            set { Set(ref _isTypeAntibiotic, value); }
        }
    }
}
