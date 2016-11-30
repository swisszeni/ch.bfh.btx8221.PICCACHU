using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.Views;
using System;
using System.Collections;
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
        private StatlockChangingEntry _selectedEntry;
        public StatlockChangingViewModel(StatlockChangingEntry entry)
        {
            if (entry == null)
            {
                CheckForMainentanceInstruction();
                IsEnabledOrVisible = true;
                ProcedureDate = DateTime.Now;
            }
            else
            {
                Person = entry.Person;
                Institution = entry.Institution;
                ProcedureDate = entry.ProcedureDateTime;
                Reason = entry.Reason;

                _selectedEntry = entry;
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

        private HealthPerson _person;
        public HealthPerson Person
        {
            get { return _person; }
            set
            {
                if (_person != value)
                {
                    _person = value;
                    OnPropertyChanged("Person");
                }
            }
        }

        private HealthInstitution _institution;
        public HealthInstitution Institution
        {
            get { return _institution; }
            set
            {
                if (_institution != value)
                {
                    _institution = value;
                    OnPropertyChanged("Institution");
                }
            }
        }

        private DateTime _procedureDate;
        public DateTime ProcedureDate
        {
            get { return _procedureDate; }
            set
            {
                if (_procedureDate != value)
                {
                    _procedureDate = value;
                    OnPropertyChanged("ProcedureDate");
                }
            }
        }

        private StatLockChangementReason _reason;
        public StatLockChangementReason Reason
        {
            get { return _reason; }
            set
            {
                if (_reason != value)
                {
                    _reason = value;
                    OnPropertyChanged("Reason");
                }
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


        private ICommand _saveButtonCommand;
        public ICommand SaveButtonCommand => _saveButtonCommand ?? (_saveButtonCommand = new Command(async () =>
        {
            // create a new PICCAppliedDrugEntry with the user entered information
            StatlockChangingEntry entry = new StatlockChangingEntry(DateTime.Now, ProcedureDate, Institution, Person, Reason);
            //Add the object to the collection of JournalEntries
            JournalEntry.AllEnteredJournalEntries.Add(entry);
            //close the page
            await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
        }));

        private ICommand _cancelButtonCommand;
        public ICommand CancelButtonCommand => _cancelButtonCommand ?? (_cancelButtonCommand = new Command(async () =>
        {
            //Check if the user really wants to leave the page
            if (await Application.Current.MainPage.DisplayAlert("Warnung!", "Wollen Sie die Eingabe wirklich abbrechen?", "Ja", "Nein"))
            {
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }));

        private ICommand _deleteButtonCommand;
        public ICommand DeleteButtonCommand => _deleteButtonCommand ?? (_deleteButtonCommand = new Command(async () =>
        {
            if (await Application.Current.MainPage.DisplayAlert("Warnung!", "Wollen Sie den Eintrag wirklich löschen?", "Ja", "Nein"))
            {
                JournalEntry.AllEnteredJournalEntries.Remove(_selectedEntry);
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }));

        private async void CheckForMainentanceInstruction()
        {
            if (await Application.Current.MainPage.DisplayAlert("Information", "Wollen Sie die für diesen Schritt eine Wartungsanleitung ansehen?", "Ja", "Nein"))
            {
                 await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(MaintenanceInstructionPage), new List<object> { MainentanceInstructions.getStatLockInstruction() }));

            }
        }
    }

}
