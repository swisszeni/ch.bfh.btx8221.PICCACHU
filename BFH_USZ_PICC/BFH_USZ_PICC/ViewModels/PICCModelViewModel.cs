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
    class PICCModelViewModel : ViewModelBase
    {
        private ObservableCollection<PICCModel> _piccModels;
        public ObservableCollection<PICCModel> PICCModels
        {
            get { return _piccModels; }
            set { Set(ref _piccModels, value); }
        }

        public PICCModelViewModel()
        {
            PICCModels = new ObservableCollection<PICCModel>(PICCModel.AllModels());
        }
    }
}
