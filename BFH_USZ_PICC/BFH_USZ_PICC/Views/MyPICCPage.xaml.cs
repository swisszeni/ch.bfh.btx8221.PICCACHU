using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using System;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public sealed partial class MyPICCPage : BaseContentPage
    {
        public MyPICCPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            ((MyPICCViewModel)BindingContext).ReloadCurrentPiccBinding.Execute(null);
        }

        // This method sets the selected picc entry to null (otherwise it would be marked).
        private void SelectedEntry(object sender, EventArgs e)
        {
            FormerPICCList.SelectedItem = null;
        }
    }
}

