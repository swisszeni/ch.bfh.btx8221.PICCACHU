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
    class BandageChangingViewModel : INotifyPropertyChanged
    {
        public BandageChangingViewModel(BandageChangingEntry entry)
        {
            SaveButtonCommand = new Command(SaveButtonClicked);
            CancelButtonCommand = new Command(CancelButtonClicked);
            DeleteButtonCommand = new Command(DeleteButtonClicked);

            BandageChangingEntry bandageEntry = entry;
            if (bandageEntry == null)
            {
                IsEnabledOrVisible = true;
                _bandageChangingEntry = new BandageChangingEntry(DateTime.Now, DateTime.Now, JournalEntry.HealthInstitution.NoInformation, JournalEntry.HealthPerson.NoInformation, 
                    BandageChangingReason.NoInformation, BandageChangingArea.NoInformation,BandagePunctureSituation.NoInformation, BandageArmProcessSituation.NoInformation);
            }
            else
            {
                _bandageChangingEntry = bandageEntry;
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


        private BandageChangingEntry _bandageChangingEntry;
        public BandageChangingEntry BandageChangingEntry
        {
            get { return _bandageChangingEntry; }
            set
            {
                if (_bandageChangingEntry != value)
                {
                    _bandageChangingEntry = value;
                    OnPropertyChanged("BandageChangingEntry");
                }
            }
        }

        public ICommand SaveButtonCommand { protected set; get; }
        public ICommand CancelButtonCommand { protected set; get; }
        public ICommand DeleteButtonCommand { protected set; get; }

        async void SaveButtonClicked()
        {
            // create a new PICCAppliedDrugEntry with the user entered information
            BandageChangingEntry bandageEntry = new BandageChangingEntry(DateTime.Now, _bandageChangingEntry.ProcedureDateTime, _bandageChangingEntry.Institution, _bandageChangingEntry.Person,
                _bandageChangingEntry.Reason, _bandageChangingEntry.Area, _bandageChangingEntry.Puncture, _bandageChangingEntry.ArmProcess);
            //Add the object to the collection of JournalEntries
            JournalEntry.AllEnteredJournalEntries.Add(bandageEntry);
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
                JournalEntry.AllEnteredJournalEntries.Remove(_bandageChangingEntry);
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }

    }
}
