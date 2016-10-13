﻿using BFH_USZ_PICC.Controls;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using System;
using Xamarin.Forms;


// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class DisorderPage : BaseContentPage
    {
        public DisorderPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            Title = "Störungen";

            //Create a new instance of the DisorderViewModel class and add the current Navgation object (DisorderPage) in order to be able to call the "PushAsync" method within the DisorderViewModel class.
            BindingContext = new DisorderViewModel();
            
        }

        //This method sets the selected disorder entry to null (otherwise it would be marked as selected after closing the disorder detail page).
        void SelectedDisorder(object sender, EventArgs e)
        {
            DisorderList.SelectedItem = null;
        }
    }
}