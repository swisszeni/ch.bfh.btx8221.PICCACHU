using BFH_USZ_PICC.Controls;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;


// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MaintenanceInstructionPage : BaseContentPage
    {
        public MaintenanceInstructionPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            //BindingContext = new InstructionViewModel();
            ObservableCollection<Image> MainenanceInstruction = new ObservableCollection<Image>();

            MainenanceInstruction.Add(new Image { Source = "icon.png" });
            MainenanceInstruction.Add(new Image { Source = "icon.png" });
            MainenanceInstruction.Add(new Image { Source = "icon.png" });
            //MainenanceInstruction.Add(new InstructionElement("icon.png", "Seite 2"));
            //MainenanceInstruction.Add(2, new InstructionElement("icon.png", "Seite 3"));

            InstructionCarousel.ItemsSource = MainenanceInstruction;

            

        }
    }
}
