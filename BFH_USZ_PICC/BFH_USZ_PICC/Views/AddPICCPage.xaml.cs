using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;


// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class AddPICCPage : BaseContentPage
    {

        // Add a ViewModel
        PICCModelViewModel PICCViewModelInstance = new PICCModelViewModel();

        public AddPICCPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            Title = "PICC hinzufügen";

            if (PICCViewModelInstance != null && PICCViewModelInstance.PICCModels.Count > 0)
            {
                BindingContext = PICCViewModelInstance;
            }
        }


        /// <summary>
        /// Gets the input string from the SearchBar and checks if a PICC exists with the given information.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void PiccSearchButtonClicked(object o, EventArgs e)
        {
            string searchName = PICCEntry.Text;
            searchForAPiccModel(searchName);

        }

        /// <summary>
        /// Sets the visibility of the PiccModel ListView to false if the user has unfocused the searchbar
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void SearchBarUnfocused(object o, EventArgs e)
        {
            AllModels.IsVisible = false;
        }

        /// <summary>
        /// Sets the visibility of the PiccModel ListView to true if the user has focused the searchbar
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void SearchBarFocused(object o, EventArgs e)
        {
            AllModels.IsVisible = true;
        }

        void SerachForAPiccModel(object o, EventArgs e)
        {
            AllModels.IsVisible = true;
            FilterLocations(PICCEntry.Text);
        }

        /// <summary>
        /// If the user has selected a PICC model, he/she will be forwarded to the modfify page together with the selected model
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void SelectedPicc(object o, EventArgs e)
        {
            if (AllModels.SelectedItem != null)
            {
                Navigation.PushAsync(new BasePage(typeof(PICCDetailPage), new List<object> { AllModels.SelectedItem }));
                AllModels.SelectedItem = null;
            }
        }

        /// <summary>
        /// If the user wants to add a PICC model manually, an empty PiccModel object is generated.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void AddPiccManualButtonClick(object o, EventArgs e)
        {
            PICCModel model = new PICCModel(null, 0, null, null);
            Navigation.PushAsync(new BasePage(typeof(PICCDetailPage), new List<object> { model }));
        }

        /// <summary>
        /// Enable the camera for barcode scan. If a barcode is returned, it checks if there is a match with a PICC barcode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void ScanClick(object sender, EventArgs e)
        {
            //var barcode = DependencyService.Get<IBarcodeScanner>();
            //var barcodeResult = await barcode.StringFromBarcode();

            //if (barcodeResult != null)
            //{
            //    searchForAPiccModel(barcodeResult);
            //}
            //Create a new ZXIngScannerPage
            var scanPage = new ZXingScannerPage();

            //Disable the FlashButton
            scanPage.DefaultOverlayShowFlashButton = false;
            
            //If the scaner has a result: stop scanning, close the lpage, check if the result is not null and give the result to the "searchForAPiccModel" method. 
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;
                
                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopAsync();
                    if (result != null)
                    {
                        searchForAPiccModel(result.Text);
                    }
                });
            };

            //Opens the scanPage with the parameters set above
            await Navigation.PushAsync(scanPage);

        }

        /// <summary>
        /// Checks if either the entered name or the barcode can be found within the given PICC models. If no, a popup will inform the user.
        /// </summary>
        /// <param name="nameOrBarcode"></param>
        async void searchForAPiccModel(string nameOrBarcode)
        {
            foreach (PICCModel piccModel in PICCViewModelInstance.PICCModels)
            {
                // if either the picc name or the barcode could be found in the database
                if ((string.Compare(piccModel.PICCName, nameOrBarcode, StringComparison.OrdinalIgnoreCase) == 0) || (string.Compare(piccModel.Barcode, nameOrBarcode, StringComparison.OrdinalIgnoreCase) == 0))
                {
                    await Navigation.PushAsync(new BasePage(typeof(PICCDetailPage), new List<object> { piccModel }));
                    return;
                }
            }

            bool registerManually = await DisplayAlert("Information", "PICC Modell konnte nicht gefunden werden", "PICC manuell erfassen", "OK");
            if (registerManually)
            {
                // User wants to create model manually, create a new model with the searchterm preset as text
                PICCModel model = new PICCModel(PICCEntry.Text, 0, null, null);
                await Navigation.PushAsync(new BasePage(typeof(PICCDetailPage), new List<object> { model }));
            }
            else
            {
                // User dismissed create, empty the searchfield
                PICCEntry.Text = "";
            }

        }

        /// <summary>
        /// Refreshes the AllModels ListView by checking if the entered information in the related Searchbar matches with a PICC
        /// </summary>
        /// <param name="filter"></param>
        void FilterLocations(string filter)
        {
            AllModels.BeginRefresh();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                AllModels.IsVisible = true;
                // FIXME: This code is bullshit, use proper mvvm arch
                //AllModels.ItemsSource = PICCViewModelInstance.PICCModels.Where(model => model.PiccName.ToLower().Contains(filter.ToLower()));
            }
            else
            {
                AllModels.IsVisible = false;
            }

            AllModels.EndRefresh();
        }
    }
}
