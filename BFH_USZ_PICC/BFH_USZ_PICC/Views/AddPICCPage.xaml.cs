using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
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
        public AddPICCPage(ContentPage contained) : base(contained)
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
