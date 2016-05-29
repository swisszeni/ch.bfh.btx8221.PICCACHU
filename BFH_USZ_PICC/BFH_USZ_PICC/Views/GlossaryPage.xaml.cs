using BFH_USZ_PICC.Controls;
using BFH_USZ_PICC.Models;
using System;
using Xamarin.Forms;


// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class GlossaryPage : BaseContentPage
    {
        public GlossaryPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            Title = "Glossar";

            //Adds all glossary entries form the singleton class "GlossaryEntries" to the glossary ListView 
            GlossaryList.ItemsSource = GlossaryEntries.getEntries();
        }

        // This method checks whitch glossary entry has been selected and displays the related information in a pop up.
        void OnSelect(object sender, EventArgs e)
        {
            if (GlossaryList.SelectedItem != null)
            {
                GlossaryEntry selectedEntry = (GlossaryEntry)GlossaryList.SelectedItem;
                showGlossaryEntry(selectedEntry);

            }
            GlossaryList.SelectedItem = null;
        }

        //displays a glossary entry. The word is the header, the explanation the body
        private void showGlossaryEntry(GlossaryEntry entry)
        {
            DisplayAlert(entry.word, entry.explanation, "ok");
        }
    }
}
