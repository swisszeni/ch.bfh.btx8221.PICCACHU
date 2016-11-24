using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Views;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.ViewModels
{
    class DisorderViewModel : ViewModelBase
    {
        /// <summary>
        /// Adds a list with all "Disorder" objects to the "ListOfDisorderEntries" variable.
        /// </summary>
        public DisorderViewModel()
        {
            DisorderEntriesList = DisorderEntries.getEntries();
        }

        /// <summary>
        /// Binds all the disorder entries to a the "Disorder" ListView
        /// </summary>
        private List<DisorderEntry> _disorderEntriesList;
        public List<DisorderEntry> DisorderEntriesList
        {
            get { return _disorderEntriesList; }
            set
            {
                Set(ref _disorderEntriesList, value);
            }
        }

        /// <summary>
        /// Binds a disorder entry to the "SelectedSymptom" property of the "DisorderList" ListView.
        /// If the user selects a disorder entry, a new page will show the reason and action for the symptom.
        /// </summary>
        private DisorderEntry _selectedSymptom;
        public DisorderEntry SelectedSymptom
        {
            get { return _selectedSymptom; }
            set
            {
                if (Set(() => SelectedSymptom, ref _selectedSymptom, value) & _selectedSymptom != null)
                {
                    ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(DisorderDetailPage), new List<object> { value }));
                }
            }
        }
    }
}
