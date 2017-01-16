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
            // TODO: FIX problem of wrong title
            // Title = AppResources.PICCDetailPageEditPICCTitle; 
            // Title = AppResources.PICCDetailPageAddNewPICCTitle;      
            Title = AppResources.PICCDetailPageTitleText;
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
