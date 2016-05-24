using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using System;
using Xamarin.Forms;


namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public partial class KnowledgeEntryDetailPage : BasePage
    {
        public KnowledgeEntryDetailPage(KnowledgeEntry selectedEntry) : base()
        {
            InitializeComponent();
            addPageElements(selectedEntry);
   
        }

        void OnSelect(object sender, EventArgs e)
        {
            //   Checks if the GlossaryList.SelectetItem value is null(value will be null after the following "if" statement).
            if (GlossaryList.SelectedItem != null)
            {

                // Casts the selected object to a glossary entry and moves forward to the glossary page
                GlossaryEntry selectedEntry = (GlossaryEntry)GlossaryList.SelectedItem;
                Navigation.PushAsync(new GlossaryPage(selectedEntry));
                GlossaryList.SelectedItem = null;
            }
        }

        // this method adds all the needed knowledge elements to the correct position
        private void addPageElements(KnowledgeEntry selectedEntry)
        {
            {
                //Adds the glossary entries to the realted list
                GlossaryList.ItemsSource = selectedEntry.glossaryEntries;

                //the index variable adds the knowledgeElement to its particular position
                int index = 0;

                //   < StackLayout x: Name = "KnowledgeEntryPageLayout" Orientation = "Vertical"
                //HorizontalOptions = "EndAndExpand" VerticalOptions = "FillAndExpand" >

                StackLayout knowledgeEntryView = new StackLayout();
                knowledgeEntryView.Orientation = StackOrientation.Vertical;
                knowledgeEntryView.VerticalOptions = LayoutOptions.EndAndExpand;

                //check if the element is either a text or an image
                foreach (var entry in selectedEntry.knowledgeElements)
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
                        currentImage.HeightRequest = 300;
                        currentImage.WidthRequest = 150;

                        addTabGestureRecognizerToImage(entry);
                        knowledgeEntryView.Children.Insert(index, currentImage);
                        index++;

                        //Checks if a caption is set. If yes, a new label for the caption will be generated
                        KnowledgeEntryImageElement imgElem = (KnowledgeEntryImageElement)entry;
                        if (imgElem.caption != null)
                        {
                            knowledgeEntryView.Children.Insert(index, (new Label
                            {
                                Text = imgElem.caption,
                                HorizontalTextAlignment = TextAlignment.Center

                            }));
                            index++;
                        }

                    }
                }

                knowledgeEntryView.Children.Insert(index, (new Label
                {
                    Text = "\n\n\nPassende Glossareinträge",
                    HorizontalTextAlignment = TextAlignment.Start
                }));

                GlossaryList.Header = knowledgeEntryView;
            }
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
                    Navigation.PushAsync(new PicturePage((KnowledgeEntryImageElement)imageElem));
                }

            };

            Image image = (Image)imageElem.element;

            image.GestureRecognizers.Add(tapGesture);
        }
    }
}
