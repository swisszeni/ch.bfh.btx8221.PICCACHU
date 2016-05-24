using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;


// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BFH_USZ_PICC.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class KnowledgeEntrysPage : BasePage
    {
        List<KnowledgeEntryTypeGroup> allEntries = new List<KnowledgeEntryTypeGroup>();

        public KnowledgeEntrysPage() : base()
        {
            InitializeComponent();
            //Get all the knowledge entries and add them to  the ListView

            KnowledgeList.ItemsSource = KnowledgeEntries.getEntries();

        }

        //Checks which ListView Element has been selected and moves forward to the KnowledgeEntryPage with the related information 
        void OnSelect(object sender, EventArgs e)
        {
            //Checks if the KnowledgeEntries.SelectedItem value is null (value will be null after the following "if" statement).
            if (KnowledgeList.SelectedItem != null)
            {
                //Casts the selected object to a Knowledge entry object and moves it forward to the glossary page.
                KnowledgeEntry selectedEntry = (KnowledgeEntry)KnowledgeList.SelectedItem;

                Navigation.PushAsync(new KnowledgeEntryDetailPage(selectedEntry)
                {
                    //Sets the title for the new created KnowledgeEntryPage
                    Title = selectedEntry.title
                }
                    );
                KnowledgeList.SelectedItem = null;
            }

        }
    }
}
