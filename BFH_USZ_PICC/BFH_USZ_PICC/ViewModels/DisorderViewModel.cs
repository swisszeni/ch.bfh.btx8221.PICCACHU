using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.ViewModels
{
    class DisorderViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Adds a list with all "Disorder" objects to the "ListOfDisorderEntries" variable.
        /// </summary>
        public DisorderViewModel()
        {
            ListOfDisorderEntries = DisorderEntries.getEntries();
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
        /// Binds all the disorder entries to a the "Disorder" ListView
        /// </summary>
        private List<DisorderEntry> _listOfDisorderEntries;
        public List<DisorderEntry> ListOfDisorderEntries
        {
            get { return _listOfDisorderEntries; }
            set
            {
                if (ListOfDisorderEntries != value)
                {
                    _listOfDisorderEntries = value;
                    OnPropertyChanged("ListOfDisorderEntries");
                }
            }
        }

        /// <summary>
        /// Binds a disorder entry to the "SelectedSymptom" property of the "DisorderList" ListView.
        /// If the user selects a disorder entry, a new page will show him/her the reason and action for the symptom.
        /// </summary>
        private DisorderEntry _selectedSymptom;
        public DisorderEntry SelectedSymptom
        {
            get { return _selectedSymptom; }
            set
            {
                if (_selectedSymptom != value)
                {
                    if (value != null)
                    {
                        ((Shell)App.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(DisorderDetailPage), new List<object> { value }));

                    }
                    _selectedSymptom = value;
                    OnPropertyChanged("SelectedSymptom");
                }
            }
        }
    }
}
