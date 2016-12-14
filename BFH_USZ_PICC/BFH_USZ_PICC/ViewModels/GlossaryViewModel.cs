using BFH_USZ_PICC.Models;
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
    class GlossaryViewModel : ViewModelBase
    {
        /// <summary>
        /// Binds all the glossary entries to a the "GlossaryList" ListView
        /// </summary>
        private List<GlossaryEntry> _glossaryEntriesList = GlossaryEntries.getEntries();
        public List<GlossaryEntry> GlossaryEntriesList
        {
            get { return _glossaryEntriesList; }
            set
            {
                Set(() => GlossaryEntriesList, ref _glossaryEntriesList, value);
            }
        }

        /// <summary>
        /// Binds a glossary entry to the "SelectedItem" property of the "GlossaryList" ListView.
        /// If the user selects a glossary entry, a display alert will show him/her the explanation for the selected word.
        /// </summary>
        private GlossaryEntry _selectedEntry;
        public GlossaryEntry SelectedEntry
        {
            get { return _selectedEntry; }
            set
            {
                Set(() => SelectedEntry, ref _selectedEntry, value);

                //Checks if _selectedEntry is not null (this can be if the user leaves the app on the device back button)
                if (_selectedEntry != null)
                {
                    Task alertShowing = Application.Current.MainPage.DisplayAlert(value.Word, value.Explanation, "Ok");
                }
            }
        }
    }
}
