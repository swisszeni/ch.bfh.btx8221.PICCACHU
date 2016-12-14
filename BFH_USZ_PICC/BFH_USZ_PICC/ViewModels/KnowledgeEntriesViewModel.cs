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
        private List<KnowledgeEntryTypeGroup> _knowledgeEntriesList = KnowledgeEntries.getEntries();
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
                Set(ref _selectedKnowledgeEntry, value);

                //Checks if _selectedEntry is not null (this can be if the user leaves the app on the device back button)
                if (_selectedKnowledgeEntry != null)
                {
                    ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(KnowledgeEntryDetailPage), new List<object> { value }));
                }
            }
        }
    }
}
