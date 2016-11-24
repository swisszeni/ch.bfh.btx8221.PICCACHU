using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.Views;
using BFH_USZ_PICC.Views.JournalEntryViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static BFH_USZ_PICC.Models.JournalEntry;

namespace BFH_USZ_PICC.ViewModels
{
    class JournalOverviewViewModel : INotifyPropertyChanged
    {
        ///// <summary>
        ///// Adds a list with all "GlossaryEntry" objects to the "ListOfGlossaryEntries" variable.
        ///// </summary>
        public JournalOverviewViewModel()
        {
            ListOfJournalEntries = JournalEntry.AllEnteredJournalEntries;
            EntryButtonCommand = new Command(NewEntryButtonClicked);
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

        /// <summary>
        /// Binds all the glossary entries to a the "GlossaryList" ListView
        /// </summary>
        private ObservableCollection<JournalEntry> _listOfJournalEntries;
        public ObservableCollection<JournalEntry> ListOfJournalEntries
        {
            get { return _listOfJournalEntries; }
            set
            {
                if (_listOfJournalEntries != value)
                {
                    _listOfJournalEntries = value;
                    OnPropertyChanged("ListOfJournalEntries");
                }
            }
        }

        private JournalEntry _selectedEntry;
        public JournalEntry SelectedEntry
        {
            get { return _selectedEntry; }
            set
            {
                if (_selectedEntry != value)
                {
                    if (value != null)
                    {
                        ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(AdministeredDrugEntryPage), new List<object> { value }));
                        
                    }
                    _selectedEntry = value;
                    OnPropertyChanged("SelectedEntry");
                }

            }
        }

        // ICommand implementations
        public ICommand EntryButtonCommand { protected set; get; }

        async void NewEntryButtonClicked()
        {
            var selectedEntry = await Xamarin.Forms.Application.Current.MainPage.DisplayActionSheet("Was wollen Sie hinzufügen?", "Abbrechen", null,
              AppResources.JournalOverviewPageCatheterFlushEntry, AppResources.JournalOverviewPageInfusionEntry, AppResources.JournalOverviewPageAdministeredDrugEntry, AppResources.JournalOverviewPageBloodWithdrawalEntry,
              AppResources.JournalOverviewPageBandagesChangingEntry, AppResources.JournalOverviewPageMicroClaveChangingEntry, AppResources.JournalOverviewPageMicroClaveChangingEntry);

            if (selectedEntry != null && selectedEntry != "Abbrechen")
            {
                if (selectedEntry == AppResources.JournalOverviewPageAdministeredDrugEntry)
                {

                    if (await Application.Current.MainPage.DisplayAlert("Information", "Wollen Sie die für dieesen Schritt eine Anleitung ansehen?", "Ja", "Nein"))
                    {
                        await Application.Current.MainPage.Navigation.PushModalAsync(new BasePage(typeof(MaintenanceInstructionPage), null));
                        return;
                    }
                    //await Application.Current.MainPage.Navigation.PushModalAsync(new BasePage(typeof(AdministeredDrugEntryPage), null));
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(AdministeredDrugEntryPage), null));

                    return;
                }

            }
            await Application.Current.MainPage.DisplayAlert("Information", "Nun würde ein neuer " + selectedEntry + " Eintrag eröffnet", "Ok");
        }

    }

}
