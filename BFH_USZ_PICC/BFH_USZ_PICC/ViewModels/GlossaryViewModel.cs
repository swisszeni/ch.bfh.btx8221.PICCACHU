using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels
{
    public class GlossaryViewModel : ViewModelBase
    {
        #region public properties

        private List<GlossaryEntry> _glossaryEntriesList = GlossaryEntries.getEntries();
        /// <summary>
        /// List of all GlossaryEntry objects to display
        /// </summary>
        public List<GlossaryEntry> GlossaryEntriesList
        {
            get { return _glossaryEntriesList; }
            set
            {
                Set(() => GlossaryEntriesList, ref _glossaryEntriesList, value);
            }
        }

        #endregion

        #region relay commands

        private RelayCommand<GlossaryEntry> _itemSelectedCommand;
        /// <summary>
        /// If the user selects a glossary entry, a display alert will show him/her the explanation for the selected word.
        /// </summary>
        public RelayCommand<GlossaryEntry> ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<GlossaryEntry>((GlossaryEntry selectedItem) =>
        {
            // Item selected, display alertview
            Task alertShowing = Application.Current.MainPage.DisplayAlert(selectedItem.Word, selectedItem.Explanation, AppResources.OkButtonText);
        }));

        #endregion

    }
}
