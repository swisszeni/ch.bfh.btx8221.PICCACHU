using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BFH_USZ_PICC.Models.JournalEntry;

namespace BFH_USZ_PICC.ViewModels
{
    class JournalOverviewViewModel : INotifyPropertyChanged
    {
        ///// <summary>
        ///// Adds a list with all "GlossaryEntry" objects to the "ListOfGlossaryEntries" variable.
        ///// </summary>
        //public JournalOverviewViewModel()
        //{
        //    ListOfJournalEntries = JournalEntry.AllEnteredJournalEntries;
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Checks if a binded property has been changed and fires the event
        /// </summary>
        /// <param name="propertyname"></param>
        protected internal void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        /// <summary>
        /// Binds all the glossary entries to a the "GlossaryList" ListView
        /// </summary>
        private List<JournalEntry>  _listOfJournalEntries = JournalEntry.AllEnteredJournalEntries;
        public List<JournalEntry> ListOfJournalEntries
        {
            get { return _listOfJournalEntries; }
            set
            {
                if (_listOfJournalEntries != value)
                {
                    _listOfJournalEntries = value;
                    OnPropertyChanged("ListOfJournalEntries");
                }
            }
        }


        ///// <summary>
        ///// Binds a glossary entry to the "SelectedItem" property of the "GlossaryList" ListView.
        ///// If the user selects a glossary entry, a display alert will show him/her the explanation for the selected word.
        ///// </summary>
        //private GlossaryEntry _selectedEntry;
        //public GlossaryEntry SelectedEntry
        //{
        //    get { return _selectedEntry; }
        //    set
        //    {
        //        if (_selectedEntry != value)
        //        {
        //            if (value != null)
        //            {
        //                Application.Current.MainPage.DisplayAlert(value.Word, value.Explanation, "Ok");
        //            }
        //            _selectedEntry = value;
        //            OnPropertyChanged("SelectedEntry");
        //        }
        //    }
    }

}
