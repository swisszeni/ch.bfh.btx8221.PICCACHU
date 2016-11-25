using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Views;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels
{
    public class KnowledgeEntriesViewModel : ViewModelBase
    {
        public KnowledgeEntriesViewModel()
        {
            KnowledgeEntriesList = KnowledgeEntries.getEntries();
        }

        private List<KnowledgeEntryTypeGroup> _knowledgeEntriesList;
        public List<KnowledgeEntryTypeGroup> KnowledgeEntriesList
        {
            get { return _knowledgeEntriesList; }
            set
            {
                Set(ref _knowledgeEntriesList, value);
            }
        }

        private KnowledgeEntry _selectedKnowledgeEntry;
        public KnowledgeEntry SelectedKnowledgeEntry
        {
            get { return _selectedKnowledgeEntry; }
            set
            {
                if (Set(ref _selectedKnowledgeEntry, value) & _selectedKnowledgeEntry != null)
                {
                    ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(KnowledgeEntryDetailPage), new List<object> { value }));
                }
            }
        }
    }
}
