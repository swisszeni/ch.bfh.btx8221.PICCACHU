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
        /// Adds a list with all "GlossaryEntry" objects to the "ListOfGlossaryEntries" variable.
        /// </summary>
        public GlossaryViewModel()
        {
            GlossaryEntriesList = GlossaryEntries.getEntries();
        }

        /// <summary>
        /// Binds all the glossary entries to a the "GlossaryList" ListView
        /// </summary>
        private List<GlossaryEntry> _glossaryEntriesList;
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
                if(Set(() => SelectedEntry, ref _selectedEntry, value) & _selectedEntry != null)
                {
                    Task alertShowing = Application.Current.MainPage.DisplayAlert(value.word, value.explanation, "Ok");
                }
            }
        }
    }
}
