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
        #region navigation events

        public override Task InitializeAsync(List<object> navigationData)
        {
            return base.InitializeAsync(navigationData);
        }

        #endregion

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
            if (type.Equals(typeof(KnowledgeEntry)))
            {
                NavigationService.NavigateToAsync<KnowledgeEntryDetailViewModel>(new List<object> { selectedItem });
            }
            else if (type.Equals(typeof(MaintenanceInstruction)))
            {
                NavigationService.NavigateToAsync<MaintenanceInstructionViewModel>(new List<object> { selectedItem });
            }
        }));

        #endregion

    }
}
