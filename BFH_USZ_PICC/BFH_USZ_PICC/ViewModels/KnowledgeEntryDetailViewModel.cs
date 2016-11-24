using BFH_USZ_PICC.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels
{
    public class KnowledgeEntryDetailViewModel : ViewModelBase
    {
        public KnowledgeEntryDetailViewModel()
        {
            RelatedGlossaryEntries = new List<GlossaryEntry>();
        }

        private KnowledgeEntry _displayingEntry;
        public KnowledgeEntry DisplayingEntry
        {
            get { return _displayingEntry; }
            set { Set(ref _displayingEntry, value); }
        }

        private List<GlossaryEntry> _relatedGlossaryEntries;
        public List<GlossaryEntry> RelatedGlossaryEntries
        {
            get { return _relatedGlossaryEntries; }
            set { Set(ref _relatedGlossaryEntries, value); }
        }

        private GlossaryEntry _selectedGlossaryEntry;
        public GlossaryEntry SelectedGlossaryEntry
        {
            get { return _selectedGlossaryEntry; }
            set {
                if (Set(ref _selectedGlossaryEntry, value) & _selectedGlossaryEntry != null)
                {
                    Task alertShowing = Application.Current.MainPage.DisplayAlert(value.Word, value.Explanation, "Ok");
                }
            }
        }
    }
}
