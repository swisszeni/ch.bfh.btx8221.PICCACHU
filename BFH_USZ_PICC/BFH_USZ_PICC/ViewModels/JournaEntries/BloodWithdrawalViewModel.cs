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
    class BloodWithdrawalViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Adds a list with all "GlossaryEntry" objects to the "ListOfGlossaryEntries" variable.
        /// </summary>
        public BloodWithdrawalViewModel(BloodWithdrawalEntry entry)
        {
            // AddHealthInstitutionsToPicker();

            SaveButtonCommand = new Command(SaveButtonClicked);
            CancelButtonCommand = new Command(CancelButtonClicked);
            //DeleteButtonCommand = new Command(DeleteButtonClicked);

            BloodWithdrawalEntry bloodEntry = (BloodWithdrawalEntry)entry;
            if (bloodEntry == null)
            {
                IsEnabledOrVisible = true;
                BloodWithdrawalEntry = new BloodWithdrawalEntry(DateTime.Now, DateTime.Now, JournalEntry.HealthInstitution.NoInformation, JournalEntry.HealthPerson.NoInformation, false, BloodFlow.NoInformation);
            }
            else
            {
                BloodWithdrawalEntry = bloodEntry;
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


        private BloodWithdrawalEntry _bloodWithdrawalEntry;
        public BloodWithdrawalEntry BloodWithdrawalEntry
        {
            get { return _bloodWithdrawalEntry; }
            set
            {
                if (_bloodWithdrawalEntry != value)
                {
                    _bloodWithdrawalEntry = value;
                    OnPropertyChanged("BloodWithdrawalEntry");
                }
            }
        }

        public ICommand SaveButtonCommand { protected set; get; }
        public ICommand CancelButtonCommand { protected set; get; }
        

        async void SaveButtonClicked()
        {
            // create a new PICCAppliedDrugEntry with the user entered information
            BloodWithdrawalEntry bloodEntry = new BloodWithdrawalEntry(DateTime.Now, _bloodWithdrawalEntry.ProcedureDateTime, _bloodWithdrawalEntry.Institution, _bloodWithdrawalEntry.Person, _bloodWithdrawalEntry.IsNaCiFlashDone, _bloodWithdrawalEntry.Flow);
            //Add the object to the collection of JournalEntries
            JournalEntry.AllEnteredJournalEntries.Add(bloodEntry);
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

        private ICommand _deleteButtonCommand;
        public ICommand DeleteButtonCommand => _deleteButtonCommand ?? (_deleteButtonCommand = new Command(async () => {
            if (await Application.Current.MainPage.DisplayAlert("Warnung!", "Wollen Sie den Eintrag wirklich löschen?", "Ja", "Nein"))
            {
                JournalEntry.AllEnteredJournalEntries.Remove(_bloodWithdrawalEntry);
                await((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }));

    }
}
