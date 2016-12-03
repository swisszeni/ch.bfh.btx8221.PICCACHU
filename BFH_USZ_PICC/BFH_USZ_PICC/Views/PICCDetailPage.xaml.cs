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
            InitializeComponent();
            Title = AppResources.PICCDetailPageTitleText;
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
            displayMode = PICCDetailPageDisplayMode.Create;
            AddPickerItems();
            ((PICCDetailViewModel)BindingContext).DisplayingEntry  = new PICC(model, DateTime.Now, PICC.PICCInsertCountry.Undefined, null, PICC.PICCInsertSide.Undefined, PICC.PICCInsertPosition.Undefined);
            ((PICCDetailViewModel)BindingContext).IsVisibleOrEnabled = true;
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
            InitializeComponent();
            Title = AppResources.PICCDetailPageEditPICCTitle;
            displayMode = PICCDetailPageDisplayMode.View;
        }
       
        void AddPickerItems()
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
