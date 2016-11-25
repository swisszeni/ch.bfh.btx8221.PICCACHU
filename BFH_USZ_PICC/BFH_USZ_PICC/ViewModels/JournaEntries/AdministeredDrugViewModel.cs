using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static BFH_USZ_PICC.Models.JournalEntry;

namespace BFH_USZ_PICC.ViewModels.JournalEntries
{
    class AdministeredDrugViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Adds a list with all "GlossaryEntry" objects to the "ListOfGlossaryEntries" variable.
        /// </summary>
        public AdministeredDrugViewModel(AdministeredDrugEntry entry)
        {
            // AddHealthInstitutionsToPicker();

            SaveButtonCommand = new Command(SaveButtonClicked);
            CancelButtonCommand = new Command(CancelButtonClicked);
            DeleteButtonCommand = new Command(DeleteButtonClicked);

            AdministeredDrugEntry piccAppliedDrugEntry = (AdministeredDrugEntry)entry;
            if (piccAppliedDrugEntry == null)
            {
                IsEnabledOrVisible = true;
                _administeredDrugEntry = new AdministeredDrugEntry(DateTime.Now, DateTime.Now, JournalEntry.HealthInstitution.NoInformation, JournalEntry.HealthPerson.NoInformation, " ");
            }
            else
            {
                _administeredDrugEntry = piccAppliedDrugEntry;
                IsEnabledOrVisible = false;
            }
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

        private bool _isEnabledOrVisible;
        public bool IsEnabledOrVisible
        {
            get { return _isEnabledOrVisible; }
            set
            {
                _isEnabledOrVisible = value;
                OnPropertyChanged("IsEnabledOrVisible");
            }
        }


        private AdministeredDrugEntry _administeredDrugEntry;
        public AdministeredDrugEntry AdministeredDrugEntry
        {
            get { return _administeredDrugEntry; }
            set
            {
                if (_administeredDrugEntry != value)
                {
                    _administeredDrugEntry = value;
                    OnPropertyChanged("AdministeredDrugEntry");
                }
            }
        }

        public ICommand SaveButtonCommand { protected set; get; }
        public ICommand CancelButtonCommand { protected set; get; }
        public ICommand DeleteButtonCommand { protected set; get; }

        async void SaveButtonClicked()
        {
            // create a new PICCAppliedDrugEntry with the user entered information
            AdministeredDrugEntry drugEntry = new AdministeredDrugEntry(DateTime.Now, _administeredDrugEntry.ProcedureDateTime, _administeredDrugEntry.Institution, _administeredDrugEntry.Person, _administeredDrugEntry.Drug);
            //Add the object to the collection of JournalEntries
            JournalEntry.AllEnteredJournalEntries.Add(drugEntry);
            //close the page
            await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();

        }

        async void CancelButtonClicked()
        {
            //Check if the user really wants to leave the page
            if (await Application.Current.MainPage.DisplayAlert("Warnung!", "Wollen Sie die Eingabe wirklich abbrechen?", "Ja", "Nein"))
            {
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }

        }

        async void DeleteButtonClicked()
        {
            if (await Application.Current.MainPage.DisplayAlert("Warnung!", "Wollen Sie den Eintrag wirklich löschen?", "Ja", "Nein"))
            {   
                JournalEntry.AllEnteredJournalEntries.Remove(_administeredDrugEntry);
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }

    }
}
