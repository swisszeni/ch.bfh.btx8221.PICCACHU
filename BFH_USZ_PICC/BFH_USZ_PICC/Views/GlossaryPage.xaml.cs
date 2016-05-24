using BFH_USZ_PICC.Models;
using System;
using Xamarin.Forms;


// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class GlossaryPage : BasePage
    {
        public GlossaryPage() : base()
        {
            InitializeComponent();
            

            //Adds all glossary entries form the singleton class "GlossaryEntries" to the glossary ListView 
            GlossaryList.ItemsSource = GlossaryEntries.getEntries();
        }

        //Constructor with a GlossaryEntry object. The given entry will be displayed
        public GlossaryPage(GlossaryEntry aSelectedEntry) :base()
        {
            InitializeComponent();

            //Adds all glossary entries form the singleton class "GlossaryEntries" to a variable. Afterwards, the list with the entries will be added to the glossary ListView.
            var glossaryWords = GlossaryEntries.getEntries();

            GlossaryList.ItemsSource = glossaryWords;

            showGlossaryEntry(aSelectedEntry);


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
            this.DisplayAlert(entry.word, entry.explanation, "Ok");
        }
    }
}
