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
    public class BloodWithdrawalViewModel : JournalEntryBaseViewModel<BloodWithdrawalEntry>
    {
        public BloodWithdrawalViewModel() { }

        #region private methods

        protected override void LoadFromModel()
        {
            Flow = _displayingEntry?.Flow == null ? 0 : _displayingEntry.Flow;
            IsNaClFlushDone = _displayingEntry?.IsNaClFlushDone == null ? false : _displayingEntry.IsNaClFlushDone;

            base.LoadFromModel();
        }

        protected override void SaveToModel()
        {
            _displayingEntry.Flow = Flow;
            _displayingEntry.IsNaClFlushDone = IsNaClFlushDone;

            base.SaveToModel();
        }

        #endregion

        #region public properties

        private BloodFlow _flow;
        public BloodFlow Flow
        {
            get { return _flow; }
            set { Set(ref _flow, value); }
        }

        private bool _isNaClFlushDone;
        public bool IsNaClFlushDone
        {
            get { return _isNaClFlushDone; }
            set { Set(ref _isNaClFlushDone, value); }
        }

        #endregion
    }
}
