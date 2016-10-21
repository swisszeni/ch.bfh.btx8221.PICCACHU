using BFH_USZ_PICC.Models;
using System;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{

    public sealed partial class PICCDetailPage : BaseContentPage
    {

        public enum PICCDetailPageDisplayMode
        {
            Create,
            Edit,
            View
        }

        private PICCDetailPageDisplayMode displayMode = PICCDetailPageDisplayMode.Create;

        /// <summary>
        /// Default constructor
        /// 
        /// author: Raphael zenhäusern
        /// </summary>
        /// <param name="contained">BasePage</param>
        public PICCDetailPage(ContentPage contained) : base(contained)
        {
            InitializeLayout();
            //Title = "PICC";
        }

        /// <summary>
        /// Constructor with a PICCModel, call when a new PICC should be created for the PICCModell passed
        /// 
        /// author: Raphael zenhäusern
        /// </summary>
        /// <param name="contained">BasePage</param>
        /// <param name="model">PICCModel to create</param>
        public PICCDetailPage(ContentPage contained, PICCModel model) : base(contained)
        {
            InitializeLayout();
            Title = "PICC erfassen";
            displayMode = PICCDetailPageDisplayMode.Create;
        }

        /// <summary>
        /// Constructor with a existing PICC, call when a existing should be displayed/edited
        /// 
        /// author: Raphael zenhäusern
        /// </summary>
        /// <param name="contained">BasePage</param>
        /// <param name="existingPICC">Existing PICC</param>
        public PICCDetailPage(ContentPage contained, PICC existingPICC) : base(contained)
        {
            InitializeLayout();
            Title = "PICC bearbeiten";
            displayMode = PICCDetailPageDisplayMode.View;
        }

        private void InitializeLayout()
        {
            InitializeComponent();

            if (displayMode == PICCDetailPageDisplayMode.Create)
            {
                PiccInformation.IsVisible = true;
                EditButton.IsVisible = false;
                PiccRemoveButton.IsVisible = false;
                EnableControls(true);
            }
        }

        /// <summary>
        /// This method either enables or disables the input field for the picc information
        /// </summary>
        /// <param name="enable"></param>
        private void EnableControls(bool enable)
        {
            PiccName.IsEnabled = enable;
            InsertedDate.IsEnabled = enable;
            InsertCity.IsEnabled = enable;
            PiccSide.IsEnabled = enable;
            PiccPosition.IsEnabled = enable;
            PiccFrench.IsEnabled = enable;
            Country.IsEnabled = enable;
            PiccRemoveButton.IsEnabled = enable;

            //Changes the visibility to either save/cancel buttons or edit/addAPicc buttons
            SaveAndCancelButtons.IsVisible = enable;
            EditAndAddButtons.IsVisible = (!enable);
        }

        async void CancelNewPiccEntry()
        {
            bool cancel = await DisplayAlert("Warnung!", "Wollen Sie die Eingabe wirklich abbrechen?", "Ja", "Nein");

            if (cancel)
            {
                await Navigation.PopModalAsync();
            }
        }

        public void PiccRemoveButtonClicked(object o, EventArgs e)
        {

        }

        void EditButtonClicked(object o, EventArgs e)
        {
            EnableControls(true);
        }

        async void SaveButtonClicked(object o, EventArgs e)
        {

        }

        async void CancelButtonClicked(object o, EventArgs e)
        {
            bool cancel = await DisplayAlert("Warnung!", "Wollen Sie die Eingabe wirklich abbrechen?", "Ja", "Nein");

            if (cancel)
            {

            }

        }

        /// <summary>
        /// This method checks if the user has selected Switzerland, Abroad or nothing on the inserted country picker. If the user
        /// has no country selected, he is not able to enter a city.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void CountrySelected(object o, EventArgs e)
        {

        }
    }
}
