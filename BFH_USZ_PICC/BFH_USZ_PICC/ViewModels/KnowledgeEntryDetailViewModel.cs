using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels
{
    public class KnowledgeEntryDetailViewModel : ViewModelBase
    {
        #region public properties

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

        #endregion

        #region relay commands

        private RelayCommand<GlossaryEntry> _itemSelectedCommand;
        public RelayCommand<GlossaryEntry> ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<GlossaryEntry>((GlossaryEntry selectedItem) =>
        {
            // Item selected, display alertview
            Task alertShowing = Application.Current.MainPage.DisplayAlert(selectedItem.Word, selectedItem.Explanation, AppResources.OkButtonText);
        }));

        #endregion
    }
}
