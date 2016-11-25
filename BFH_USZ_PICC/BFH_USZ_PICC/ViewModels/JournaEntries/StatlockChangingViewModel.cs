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
    class StatlockChangingViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Adds a list with all "GlossaryEntry" objects to the "ListOfGlossaryEntries" variable.
        /// </summary>
        public StatlockChangingViewModel(StatlockChangingEntry entry)
        {
            // AddHealthInstitutionsToPicker();

            SaveButtonCommand = new Command(SaveButtonClicked);
            CancelButtonCommand = new Command(CancelButtonClicked);
            DeleteButtonCommand = new Command(DeleteButtonClicked);

            StatlockChangingEntry statlockChangingEntry = (StatlockChangingEntry)entry;
            if (statlockChangingEntry == null)
            {
                IsEnabledOrVisible = true;
                _statlockChangingEntry = new StatlockChangingEntry(DateTime.Now, DateTime.Now, JournalEntry.HealthInstitution.NoInformation, JournalEntry.HealthPerson.NoInformation, StatLockChangementReason.NoInformation);
            }
            else
            {
                _statlockChangingEntry = statlockChangingEntry;
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


        private StatlockChangingEntry _statlockChangingEntry;
        public StatlockChangingEntry StatlockChangingEntry
        {
            get { return _statlockChangingEntry; }
            set
            {
                if (_statlockChangingEntry != value)
                {
                    _statlockChangingEntry = value;
                    OnPropertyChanged("StatlockChangingEntry");
                }
            }
        }

        public ICommand SaveButtonCommand { protected set; get; }
        public ICommand CancelButtonCommand { protected set; get; }
        public ICommand DeleteButtonCommand { protected set; get; }

        async void SaveButtonClicked()
        {
            // create a new PICCAppliedDrugEntry with the user entered information
            StatlockChangingEntry statlockClaveEntry = new StatlockChangingEntry(DateTime.Now, _statlockChangingEntry.ProcedureDateTime, _statlockChangingEntry.Institution, _statlockChangingEntry.Person, _statlockChangingEntry.Reason);
            //Add the object to the collection of JournalEntries
            JournalEntry.AllEnteredJournalEntries.Add(statlockClaveEntry);
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
                JournalEntry.AllEnteredJournalEntries.Remove(_statlockChangingEntry);
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }

    }
}
