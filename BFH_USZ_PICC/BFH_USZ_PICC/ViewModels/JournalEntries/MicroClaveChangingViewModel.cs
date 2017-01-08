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
    public class MicroClaveChangingViewModel : JournalEntryBaseViewModel<MicroClaveChangingEntry>
    {
        public MicroClaveChangingViewModel() { }

        #region private methods

        protected override void LoadFromModel()
        {
            ChangementReason = _displayingEntry?.ChangementReason == null ? 0 : _displayingEntry.ChangementReason;

            base.LoadFromModel();
        }

        protected override void SaveToModel()
        {
            _displayingEntry.ChangementReason = ChangementReason;

            base.SaveToModel();
        }

        #endregion

        #region public properties

        private MicroClaveChangementReason _changementReason;
        public MicroClaveChangementReason ChangementReason
        {
            get { return _changementReason; }
            set { Set(ref _changementReason, value); }

        }

        #endregion
    }
}
