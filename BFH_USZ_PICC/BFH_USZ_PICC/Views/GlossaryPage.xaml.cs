using BFH_USZ_PICC.Controls;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using System;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public sealed partial class GlossaryPage : BaseContentPage
    {
        public GlossaryPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
        }

        // This method sets the selected glossary entry to null (otherwise it would be marked).
        private void GlossaryEntrySelected(object sender, EventArgs e)
        {
            GlossaryList.SelectedItem = null;
        }
    }
}
