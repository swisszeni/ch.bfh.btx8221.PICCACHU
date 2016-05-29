using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels
{
    class MyPICCViewModel : INotifyPropertyChanged
    {

        public MyPICCViewModel(PICC picc)
        {
            FormerPICC = new ObservableCollection<PICC>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Checks if a binded property has been changed and fires the event
        /// </summary>
        /// <param name="propertyname"></param>
        protected internal void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        private PICC _currentPICC;
        public PICC CurrentPICC
        {
            get { return _currentPICC; }
            set
            {
                if (_currentPICC != value)
                {
                    _currentPICC = value;
                    OnPropertyChanged("CurrentPICC");
                }
            }
        }

        public ObservableCollection<PICC> FormerPICC { get; private set; }
    }
}
