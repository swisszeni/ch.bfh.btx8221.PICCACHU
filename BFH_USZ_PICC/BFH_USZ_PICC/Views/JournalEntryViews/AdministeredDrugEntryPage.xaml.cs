using BFH_USZ_PICC.Models;
using System;
using Xamarin.Forms;
using static BFH_USZ_PICC.Models.JournalEntry;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.ViewModels.JournalEntryViews;



// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Views.JournalEntryViews
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class AdministeredDrugEntryPage : BaseContentPage
    {
        public AdministeredDrugEntryPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            BindingContext = new AdministeredDrugViewModel(null);
            
        }

        public AdministeredDrugEntryPage(ContentPage contained, PICCAppliedDrugEntry entry) : base(contained)
        {
            InitializeComponent();
            BindingContext = new AdministeredDrugViewModel(entry);

        }

    }
}
