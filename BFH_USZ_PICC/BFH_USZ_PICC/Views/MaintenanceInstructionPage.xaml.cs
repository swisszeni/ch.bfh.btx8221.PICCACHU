using BFH_USZ_PICC.Controls;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;



// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MaintenanceInstructionPage : BaseContentPage
    {
        public MaintenanceInstructionPage(ContentPage contained, List<MaintenanceInstruction> instruction) : base(contained)
        {
            InitializeComponent();
            ((MaintenanceInstructionViewModel)BindingContext).MaintenanceInstruction = new ObservableCollection<MaintenanceInstruction>(instruction); 
           
        }
    }
}
