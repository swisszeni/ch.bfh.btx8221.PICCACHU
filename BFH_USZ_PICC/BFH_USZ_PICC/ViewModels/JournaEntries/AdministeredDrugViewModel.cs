﻿using BFH_USZ_PICC.Models;
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
        private AdministeredDrugEntry _selectedEntry;
        public AdministeredDrugViewModel(AdministeredDrugEntry entry)
        {
            if (entry == null)
            {
                IsEnabledOrVisible = true;
                ProcedureDate = DateTime.Now;
            }
            else
            {
                Person = entry.Person;
                Institution = entry.Institution;
                ProcedureDate = entry.ProcedureDateTime;
                Drug = entry.Drug;
             
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

        private string _drug;
        public string Drug
        {
            get { return _drug; }
            set
            {
                if (_drug != value)
                {
                    _drug = value;
                    OnPropertyChanged("Drug");
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
        public ICommand SaveButtonCommand => _saveButtonCommand ?? (_saveButtonCommand = new Command(async () => {
            // create a new PICCAppliedDrugEntry with the user entered information
            AdministeredDrugEntry entry = new AdministeredDrugEntry(DateTime.Now, ProcedureDate, Institution, Person, Drug);
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
        public ICommand DeleteButtonCommand => _deleteButtonCommand ?? (_deleteButtonCommand = new Command(async () => {
            if (await Application.Current.MainPage.DisplayAlert("Warnung!", "Wollen Sie den Eintrag wirklich löschen?", "Ja", "Nein"))
            {
                JournalEntry.AllEnteredJournalEntries.Remove(_selectedEntry);
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }));
    }
}