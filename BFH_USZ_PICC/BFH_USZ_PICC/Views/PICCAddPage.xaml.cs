using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BFH_USZ_PICC.Views
{
    public sealed partial class PICCAddPage : BaseContentPage
    {
        public PICCAddPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
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

        void SearchBarFocused(object o, EventArgs e)
        {
            AllModels.IsVisible = true;
        }     
    }
}
