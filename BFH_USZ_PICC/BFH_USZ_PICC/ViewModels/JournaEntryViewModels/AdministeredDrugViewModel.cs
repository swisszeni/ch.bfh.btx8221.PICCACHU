using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BFH_USZ_PICC.ViewModels.JournalEntryViews
{
    class AdministeredDrugViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Adds a list with all "GlossaryEntry" objects to the "ListOfGlossaryEntries" variable.
        /// </summary>
        public AdministeredDrugViewModel(PICCAppliedDrugEntry entry)
        {
            SaveButtonCommand = new Command(SaveButtonClicked);
            CancelButtonCommand = new Command(CancelButtonClicked);

            PICCAppliedDrugEntry piccAppliedDrugEntry = (PICCAppliedDrugEntry)entry;
            if (piccAppliedDrugEntry == null)
            {
                IsEnabledOrVisible = true;
                _piccAppliedDrugEntry = new PICCAppliedDrugEntry(DateTime.Now, DateTime.Now, JournalEntry.HealthInstitution.None, JournalEntry.HealthPerson.None, " ");
            }
            else
            {
                _piccAppliedDrugEntry = piccAppliedDrugEntry;
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


        private PICCAppliedDrugEntry _piccAppliedDrugEntry;
        public PICCAppliedDrugEntry PiccAppliedDrugEntry
        {
            get { return _piccAppliedDrugEntry; }
            set
            {
                if (_piccAppliedDrugEntry != value)
                {
                    _piccAppliedDrugEntry = value;
                    OnPropertyChanged("PiccAppliedDrugEntry");
                }
            }
        }

        public ICommand SaveButtonCommand { protected set; get; }
        public ICommand CancelButtonCommand { protected set; get; }

        async void SaveButtonClicked()
        {
            // create a new PICCAppliedDrugEntry with the user entered information
            PICCAppliedDrugEntry drugEntry = new PICCAppliedDrugEntry(DateTime.Now, _piccAppliedDrugEntry.ProcedureDateTime, _piccAppliedDrugEntry.Institution, _piccAppliedDrugEntry.Person, _piccAppliedDrugEntry.Drug);
            //Add the object to the collection of JournalEntries
            JournalEntry.AllEnteredJournalEntries.Add(drugEntry);
            //close the modal page
            await Application.Current.MainPage.Navigation.PopModalAsync();

        }

        async void CancelButtonClicked()
        {
            //Check if the user really wants to leave the page
            if (await Application.Current.MainPage.DisplayAlert("Warnung!", "Wollen Sie die Eingabe wirklich abbrechen?", "Ja", "Nein"))
            {

                await Application.Current.MainPage.Navigation.PopModalAsync();
            }

        }
    }
}
