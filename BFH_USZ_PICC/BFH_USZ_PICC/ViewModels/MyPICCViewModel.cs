using BFH_USZ_PICC.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels
{
    class MyPICCViewModel : ViewModelBase
    {
        public MyPICCViewModel(PICC picc)
        {
            PreviousPICC = new ObservableCollection<PICC>();
        }

        private PICC _currentPICC;
        public PICC CurrentPICC
        {
            get { return _currentPICC; }
            set { Set(ref _currentPICC, value); }
        }

        private ObservableCollection<PICC> _previousPICC;
        public ObservableCollection<PICC> PreviousPICC
        {
            get { return _previousPICC; }
            set { Set(ref _previousPICC, value); }
        }
    }
}
