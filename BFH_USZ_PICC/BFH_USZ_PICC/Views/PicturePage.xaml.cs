using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// A Page displayig a picture and its caption. Tapping the image closes the page
    /// </summary>
    public partial class PicturePage : BaseContentPage
    {
        // keep track of the numbers of taps
        int tapCount = 0;

        public PicturePage(ContentPage contained) : base(contained)
        {
            InitializeComponent();

            AddTapGestureRecognizer();
        }

        /// <summary>
        /// Adds a Gesture Regognizer to the picutre
        /// </summary>
        private void AddTapGestureRecognizer()
        {
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) =>
            {
                // Make sure that the PopAsync method is only called once
                if (tapCount < 1)
                {
                    ((PictureViewModel)BindingContext).HidePictureDetailCommand.Execute(null);
                }

                tapCount++;
            };

            ImageView.GestureRecognizers.Add(tapGesture);
        }
    }
}
