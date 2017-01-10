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
                Set(() => SelectedSymptom, ref _selectedSymptom, value);

                //Checks if _selectedEntry is not null (this can be if the user leaves the app on the device back button)
                if (_selectedSymptom != null)
                {
                    // TODO: FIX
                    // ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(DisorderDetailPage), new List<object> { value }));
                }
            }
        }
    }
}
