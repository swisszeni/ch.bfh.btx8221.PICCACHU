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
        private List<DisorderEntry> _disorderEntriesList =  DisorderEntries.getEntries();
        public List<DisorderEntry> DisorderEntriesList
        {
            get { return _disorderEntriesList; }
            set
            {
                Set(ref _disorderEntriesList, value);
            }
        }

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
