﻿using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace BFH_USZ_PICC.Views
{
    public partial class KnowledgeEntryDetailPage : BaseContentPage
    {
        public KnowledgeEntryDetailPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();

            // TODO: Fix problem of wrong title

            ((KnowledgeEntryDetailViewModel)BindingContext).PropertyChanged += DisplayingEntryChanged;

            BuildViewElements();
        }

        private void DisplayingEntryChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(KnowledgeEntryDetailViewModel.DisplayingEntry))
            {
                // DisplayingEntry is updated, rebuild the view
                BuildViewElements();
            }
        }

        // this method adds all the needed knowledge elements to the correct position
        private void BuildViewElements()
        {
            // Check that DisplayingEntry is actually set
            if (((KnowledgeEntryDetailViewModel)BindingContext).DisplayingEntry == null)
            {
                return;
            }

            //the index variable adds the knowledgeElement to its particular position
            int index = 0;

            StackLayout knowledgeEntryView = new StackLayout();
            knowledgeEntryView.Orientation = StackOrientation.Vertical;
            knowledgeEntryView.VerticalOptions = LayoutOptions.EndAndExpand;

            //check if the element is either a text or an image
            foreach (var entry in ((KnowledgeEntryDetailViewModel)BindingContext).DisplayingEntry.KnowledgeElements)
            {
                if (entry.type == "text")
                {

                    knowledgeEntryView.Children.Insert(index, (new Label
                    {
                        Text = (string)entry.element
                    }));

                    index++;

                }
                else if (entry.type == "image")
                {

                    Image currentImage = (Image)entry.element;
                    currentImage.Aspect = Aspect.AspectFit;
                    //currentImage.HeightRequest = 300;
                    //currentImage.WidthRequest = 150;

                    addTabGestureRecognizerToImage(entry);
                    knowledgeEntryView.Children.Insert(index, currentImage);
                    index++;

                    //Checks if a caption is set. If yes, a new label for the caption will be generated
                    KnowledgeEntryImageElement imgElem = (KnowledgeEntryImageElement)entry;
                    if (imgElem.Caption != null)
                    {
                        knowledgeEntryView.Children.Insert(index, (new Label
                        {
                            Text = imgElem.Caption,
                            HorizontalTextAlignment = TextAlignment.Center

                        }));
                        index++;
                    }

                }
            }

            knowledgeEntryView.Children.Insert(index, (new Label
            {
                Text = "\n\n\n" + AppResources.KnowledgeEntryDetailPageMatchingGlossariesText,
                HorizontalTextAlignment = TextAlignment.Start
            }));

            knowledgeEntryView.Padding = new Thickness(15);

            GlossaryList.Header = knowledgeEntryView;
        }

        //this method adds a gesture reognizer to an image. If the image is touched, it will be displayed in it's real size on a new page
        private void addTabGestureRecognizerToImage(IKnowledgeEntryElement imageElem)
        {

            // Adds a Gesture Regognizer to link a word with the glossary
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) =>
            {
                if (imageElem != null)
                {
                    ((KnowledgeEntryDetailViewModel)BindingContext).ShowPictureDetailCommand.Execute(imageElem);
                }
            };

            Image image = (Image)imageElem.element;

            image.GestureRecognizers.Add(tapGesture);
        }
    }
}
