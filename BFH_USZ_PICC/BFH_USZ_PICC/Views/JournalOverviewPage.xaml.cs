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
    public sealed partial class JournalOverviewPage : BaseContentPage
    {
        List<KnowledgeEntryTypeGroup> allEntries = new List<KnowledgeEntryTypeGroup>();

        public JournalOverviewPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            Title = "Journal";

            //Get all the knowledge entries and add them to  the ListView
            List<JournalEntry> test = new List<JournalEntry>();

            int temp = 0;
            while (temp < 25)
            {
                test.Add(new BloodWithdrawalEntry(DateTime.Today, DateTime.Today, JournalEntry.HealthInstitution.HomeCare, JournalEntry.HealthPerson.FamilyDoctor, true, BloodFlow.Speedy));
                            
                temp++;
            }

            JournalList.ItemsSource = test;

        }
    }
}
