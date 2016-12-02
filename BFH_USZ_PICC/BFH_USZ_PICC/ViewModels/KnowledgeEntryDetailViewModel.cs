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
        private KnowledgeEntry _displayingEntry;
        public KnowledgeEntry DisplayingEntry
        {
            get { return _displayingEntry; }
            set
            {
                if (Set(ref _displayingEntry, value))
                {
                    // Update all bindings
                    RaisePropertyChanged("");
                }
            }
        }

        public List<GlossaryEntry> RelatedGlossaryEntries => DisplayingEntry?.GlossaryEntries;

        private GlossaryEntry _selectedGlossaryEntry;
        public GlossaryEntry SelectedGlossaryEntry
        {
            get { return _selectedGlossaryEntry; }
            set
            {
                if (Set(ref _selectedGlossaryEntry, value) & value != null)
                {
                    Task alertShowing = Application.Current.MainPage.DisplayAlert(value.Word, value.Explanation, "Ok");
                }
            }
        }
    }
}
