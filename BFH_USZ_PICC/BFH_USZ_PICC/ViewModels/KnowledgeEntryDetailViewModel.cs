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
        #region navigation events

        public override Task InitializeAsync(List<object> navigationData)
        {
            if (navigationData is List<object> && ((List<object>)navigationData).Count > 0)
            {
                DisplayingEntry = (KnowledgeEntry)((List<object>)navigationData).First();
            }

            return base.InitializeAsync(navigationData);
        }

        #endregion

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

        private RelayCommand<KnowledgeEntryImageElement> _showPictureDetailCommand;
        public RelayCommand<KnowledgeEntryImageElement> ShowPictureDetailCommand => _showPictureDetailCommand ?? (_showPictureDetailCommand = new RelayCommand<KnowledgeEntryImageElement>((KnowledgeEntryImageElement tappedImage) =>
        {
            // Image tapped, display detailview
            NavigationService.NavigateToAsync<PictureViewModel>(new List<object> { tappedImage });
        }));

        #endregion
    }
}
