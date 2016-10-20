using BFH_USZ_PICC.Models;
using System;
using Xamarin.Forms;


// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MyPICCPage : BaseContentPage
    {

        public MyPICCPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
           // Title = "Meine PICC";
        }


        public async void SelectedFormerPICC(object o, EventArgs e)
        {
            // FIXME: total bullshit
            if (FormerPICCList.SelectedItem != null)
            {
                PICC selectedPICC = (PICC)FormerPICCList.SelectedItem;
                if (selectedPICC.RemovalDate != null)
                {
                    await DisplayAlert(selectedPICC.PICCModel.PICCName, "Legedatum: " + selectedPICC.InsertDate.ToString("d") + "\nEntfernungsdatum: " + ((DateTime)selectedPICC.RemovalDate).ToString("d"), "Abbrechen");

                }
                else
                {
                    await DisplayAlert(selectedPICC.PICCModel.PICCName, "Legedatum: " + selectedPICC.InsertDate.ToString("d") + "\nEntfernungsdatum: ", "Abbrechen");

                }

                FormerPICCList.SelectedItem = null;
            }
        }

        async void AddPICCClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BasePage(typeof(AddPICCPage)));
        }
    }
}
