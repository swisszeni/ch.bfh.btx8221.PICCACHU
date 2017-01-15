using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels
{
    public class KnowledgeEntriesViewModel : ViewModelBase
    {
        #region public properties

        private List<KnowledgeEntryTypeGroup> _knowledgeEntriesList = KnowledgeEntries.getEntries();
        public List<KnowledgeEntryTypeGroup> KnowledgeEntriesList
        {
            get { return _knowledgeEntriesList; }
            set
            {
                Set(ref _knowledgeEntriesList, value);
            }
        }

        #endregion

        #region relay commands

        private RelayCommand<IKnowledgeBaseEntry> _itemSelectedCommand;
        public RelayCommand<IKnowledgeBaseEntry> ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<IKnowledgeBaseEntry>((IKnowledgeBaseEntry selectedItem) =>
        {
            // Item selected, handle navigation
            var type = selectedItem.GetType();
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
        }));

        #endregion

    }
}
