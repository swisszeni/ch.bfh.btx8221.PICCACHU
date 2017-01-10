using BFH_USZ_PICC.Interfaces;
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

        private IKnowledgeBaseEntry _selectedKnowledgeEntry;
        public IKnowledgeBaseEntry SelectedKnowledgeEntry
        {
            get { return _selectedKnowledgeEntry; }
            set
            {
                Set(ref _selectedKnowledgeEntry, value);

                //Checks if _selectedEntry is not null (this can be if the user leaves the app on the device back button)
                if (value != null)
                {
                    var type = value.GetType();
                    // Checks if the selected values type is KnowledgeEntry. If yes, navigate forward to KnowledgeEntryDetailPage
                    if (type.Equals(typeof(KnowledgeEntry)))
                    {
                        // TODO: FIX
                        // ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(KnowledgeEntryDetailPage), new List<object> { value }));

                    }// Checks if the selected values type is MaintenanceInstruction. If yes, navigate forward to the related MaintenanceInstruction
                    else if (type.Equals(typeof(MaintenanceInstruction)))
                    {
                        // TODO: FIX
                        // ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(MaintenanceInstructionPage), new List<object> { value }));

                    }
                }
            }
        }
    }
}
