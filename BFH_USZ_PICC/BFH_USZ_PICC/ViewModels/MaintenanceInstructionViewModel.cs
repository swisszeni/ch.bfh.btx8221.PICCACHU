using BFH_USZ_PICC.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels
{
    public class MaintenanceInstructionViewModel : ViewModelBase
    {
        private ObservableCollection<MaintenanceInstruction> _maintenanceInstruction;
        public ObservableCollection<MaintenanceInstruction> MaintenanceInstruction
        {
            get { return _maintenanceInstruction; }
            set
            {
                if (Set(ref _maintenanceInstruction, value))
                {
                    // Update all bindings
                    RaisePropertyChanged("");
                }
            }
        }

    }
}
