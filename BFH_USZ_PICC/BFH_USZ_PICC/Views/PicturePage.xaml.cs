using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public partial class PicturePage : BaseContentPage
    {
        //Counts the tabs on the displayed image
        int tapCount = 1;

        public PicturePage(ContentPage contained, KnowledgeEntryImageElement source) : base(contained)
        {
            InitializeComponent();
            Title = "Bild Detail";

            // Cast the ImageElemnt first to a KnowledgeEntryElement and cast its source to an Image
            SelectedImage.Source = ((Image)((IKnowledgeEntryElement)source).element).Source;

            // Adds a Gesture Regognizer to the loaded picutre
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) =>
            {
                //Make sure that the PopAsync method is only called once
                if (tapCount == 1)
                {
                    Navigation.PopAsync();
                }

                tapCount++;
            };
            SelectedImage.GestureRecognizers.Add(tapGesture);

            // Checks if the ImageElement has a caption and add it to the label
            if (source.Caption != null)
            {
                SelectedImageCaption.IsVisible = true;
                SelectedImageCaption.Text = source.Caption;
            }

        }
    }
}
