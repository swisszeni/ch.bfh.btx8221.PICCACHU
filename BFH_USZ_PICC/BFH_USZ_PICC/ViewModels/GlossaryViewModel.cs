using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels
{
    class GlossaryViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Adds a list with all "GlossaryEntry" objects to the "ListOfGlossaryEntries" variable.
        /// </summary>
        public GlossaryViewModel()
        {
            ListOfGlossaryEntries = GlossaryEntries.getEntries();
        }

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
        private List<GlossaryEntry> _listOfGlossaryEntries;
        public List<GlossaryEntry> ListOfGlossaryEntries
        {
            get { return _listOfGlossaryEntries; }
            set
            {
                if (_listOfGlossaryEntries != value)
                {
                    _listOfGlossaryEntries = value;
                    OnPropertyChanged("ListOfGlossaryEntries");
                }
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
                if (_selectedEntry != value)
                {
                    if (value != null)
                    {
                        Application.Current.MainPage.DisplayAlert(value.Word, value.Explanation, "Ok");
                    }
                    _selectedEntry = value;
                    OnPropertyChanged("SelectedEntry");
                }
            }
        }
    }
}
