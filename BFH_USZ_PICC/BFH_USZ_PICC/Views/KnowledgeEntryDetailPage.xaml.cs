using BFH_USZ_PICC.Interfaces;
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
        public KnowledgeEntryDetailPage(ContentPage contained, KnowledgeEntry selectedEntry) : base(contained)
        {
            InitializeComponent();
            ((KnowledgeEntryDetailViewModel)BindingContext).DisplayingEntry = selectedEntry;
            Title = selectedEntry.Title;
            BuildViewElements();
        }

        // this method adds all the needed knowledge elements to the correct position
        private void BuildViewElements()
        {
            //the index variable adds the knowledgeElement to its particular position
            int index = 0;

            StackLayout knowledgeEntryView = new StackLayout();
            knowledgeEntryView.Orientation = StackOrientation.Vertical;
            knowledgeEntryView.VerticalOptions = LayoutOptions.EndAndExpand;

            //check if the element is either a text or an image
            foreach (var entryElement in ((KnowledgeEntryDetailViewModel)BindingContext).DisplayingEntry.KnowledgeElements)
            {
                var elementType = entryElement.GetType();
                if (elementType == typeof(KnowledgeEntryTextElement))
                {

                    knowledgeEntryView.Children.Insert(index, (new Label
                    {
                        Text = (string)entryElement.Element
                    }));

                    index++;

                }
                else if (elementType == typeof(KnowledgeEntryImageElement))
                {
                    string imageSource = (string)entryElement.Element;
                    Image currentImage = new Image { Source = imageSource};
                    currentImage.Aspect = Aspect.AspectFit;
                    //currentImage.HeightRequest = 300;
                    //currentImage.WidthRequest = 150;
                    AddTabGestureRecognizerToImage(currentImage, imageSource);

                    knowledgeEntryView.Children.Insert(index, currentImage);
                    index++;

                    //Checks if a caption is set. If yes, a new label for the caption will be generated
                    KnowledgeEntryImageElement imgElem = (KnowledgeEntryImageElement)entryElement;
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

            GlossaryList.Header = knowledgeEntryView;
        }

        //this method adds a gesture reognizer to an image. If the image is touched, it will be displayed in it's real size on a new page
        private void AddTabGestureRecognizerToImage(Image imageElem, string imageSource)
        {

            // Adds a Gesture Regognizer to link a word with the glossary
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) =>
            {
                if (imageElem != null)
                {
                    // TODO: FIX
                    Navigation.PushAsync(new BasePage(typeof(PicturePage), new List<object> { imageSource }));
                }
            };

            imageElem.GestureRecognizers.Add(tapGesture);
        }


        //This method sets the selected glossary entry to null (otherwise it would be marked).
        private void GlossaryEntrySelected(object sender, EventArgs e)
        {
            GlossaryList.SelectedItem = null;
        }
    }
}
