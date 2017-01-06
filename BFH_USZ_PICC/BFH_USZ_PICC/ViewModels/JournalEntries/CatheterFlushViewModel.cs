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
    class CatheterFlushViewModel : JournalEntryBaseViewModel<CatheterFlushEntry>
    {
        public CatheterFlushViewModel() { }

        protected override void LoadFromModel()
        {
            FlushType = _displayingEntry?.FlushType == null ? 0 : _displayingEntry.FlushType;
            FlushReason = _displayingEntry?.FlushReason == null ? 0 : _displayingEntry.FlushReason;
            FlushResult = _displayingEntry?.FlushResult == null ? 0 : _displayingEntry.FlushResult;
            QuantityInMilliliter = _displayingEntry?.QuantityInMilliliter == null ? 0.0f : _displayingEntry.QuantityInMilliliter;
            IsBloodReflowVisible = _displayingEntry?.IsBloodReflowVisible == null ? false : _displayingEntry.IsBloodReflowVisible;

            base.LoadFromModel();
        }

        protected override void SaveToModel()
        {
            _displayingEntry.FlushType = FlushType;
            _displayingEntry.FlushReason = FlushReason;
            _displayingEntry.FlushResult = FlushResult;
            _displayingEntry.QuantityInMilliliter = QuantityInMilliliter;
            _displayingEntry.IsBloodReflowVisible = IsBloodReflowVisible;

            base.SaveToModel();
        }

        private FlushType _flushType;
        public FlushType FlushType
        {
            get { return _flushType; }
            set { Set(ref _flushType, value); }
        }

        private FlushReason _flushReason;
        public FlushReason FlushReason
        {
            get { return _flushReason; }
            set { Set(ref _flushReason, value); }
        }

        private FlushResult _flushResult;
        public FlushResult FlushResult
        {
            get { return _flushResult; }
            set { Set(ref _flushResult, value); }
        }

        private double _quantityInMilliliter;
        public double QuantityInMilliliter
        {
            get { return _quantityInMilliliter; }
            set { Set(ref _quantityInMilliliter, value); }
        }

        private bool _isBloodReflowVisible;
        public bool IsBloodReflowVisible
        {
            get { return _isBloodReflowVisible; }
            set { Set(ref _isBloodReflowVisible, value); }
        }
    }
}
