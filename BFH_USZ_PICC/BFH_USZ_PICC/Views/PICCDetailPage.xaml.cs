using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{

    public sealed partial class PICCDetailPage : BaseContentPage
    {

        /// <summary>
        /// Default constructor
        /// 
        /// author: Raphael zenhäusern
        /// </summary>
        /// <param name="contained">BasePage</param>
        public PICCDetailPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            Title = AppResources.PICCDetailPageTitleText;
            AddPickerItems();
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
            InitializeComponent();
            Title = AppResources.PICCDetailPageAddNewPICCTitle;            
            AddPickerItems();
        }    

        /// <summary>
        /// Constructor with an ID to an existing PICC, call when a existing should be displayed/edited
        /// 
        /// author: Raphael zenhäusern
        /// </summary>
        /// <param name="contained">BasePage</param>
        /// <param name="existingPICC">Existing PICC</param>
        public PICCDetailPage(ContentPage contained, string existingPICCID) : base(contained)
        {
            InitializeComponent();
            Title = AppResources.PICCDetailPageEditPICCTitle;            
            AddPickerItems();
        }
       
        private void AddPickerItems()
        {
            PiccPositionPicker.Items.Add(AppResources.PICCDetailPagePickerNotDefinedText);
            PiccPositionPicker.Items.Add(AppResources.PICCDetailPagePickerPositionBelowElbowText);
            PiccPositionPicker.Items.Add(AppResources.PICCDetailPagePickerPositionAboveElbowText);

            PiccSidePicker.Items.Add(AppResources.PICCDetailPagePickerNotDefinedText);
            PiccSidePicker.Items.Add(AppResources.PICCDetailPagePickerSideLeftText);
            PiccSidePicker.Items.Add(AppResources.PICCDetailPagePickerSideRightText);

            CountryPicker.Items.Add(AppResources.PICCDetailPagePickerNotDefinedText);
            CountryPicker.Items.Add(AppResources.PICCDetailPagePickerCountrySwitzerlandText);
            CountryPicker.Items.Add(AppResources.PICCDetailPagePickerCountryAbroadText);
        }
    }
}
