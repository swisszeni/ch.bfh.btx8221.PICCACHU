using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.ViewModels;
using System;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{

    public sealed partial class SettingsPage : BaseContentPage
    {
        public SettingsPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();          

        }

        // This method sets the selected picc entry to null (otherwise it would be marked).
        private void SelectedEntry(object sender, EventArgs e)
        {
            SettingsListView.SelectedItem = null;
        }

    }
}