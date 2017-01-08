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
    public class AdministeredDrugViewModel : JournalEntryBaseViewModel<AdministeredDrugEntry>
    {
        public AdministeredDrugViewModel() { }

        #region private methods

        protected override void LoadFromModel()
        {
            Drug = _displayingEntry?.Drug;

            base.LoadFromModel();
        }

        protected override void SaveToModel()
        {
            _displayingEntry.Drug = Drug;

            base.SaveToModel();
        }

        #endregion

        #region public properties

        private string _drug;
        public string Drug
        {
            get { return _drug; }
            set { Set(ref _drug, value); }
        }

        #endregion
    }
}
