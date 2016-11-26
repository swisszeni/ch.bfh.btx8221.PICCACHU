using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.Views;
using BFH_USZ_PICC.Views.JournalEntries;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
                        AllPossibleJournalEntries selectedEntryType = value.Entry;
                        switch (selectedEntryType)
                        {
                            case AllPossibleJournalEntries.AdministeredDrugEntry:
                                ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(AdministeredDrugEntryPage), new List<object> { value }));
                                return;
                            case AllPossibleJournalEntries.MicroClaveEntry:
                                ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(MicroClaveChangingEntryPage), new List<object> { value }));
                                return;
                            case AllPossibleJournalEntries.StatlockEntry:
                                ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(StatlockChangingEntryPage), new List<object> { value }));
                                return;
                            case AllPossibleJournalEntries.BloodWithdrawalEntry:
                                ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(BloodWithdrawalEntryPage), new List<object> { value }));
                                return;
                            case AllPossibleJournalEntries.BandagesChangingEntry:
                                ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(BandageChangingEntryPage), new List<object> { value }));
                                return;
                            case AllPossibleJournalEntries.InfusionEntry:
                                ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(InfusionEntryPage), new List<object> { value }));
                                return;
                            case AllPossibleJournalEntries.CatheterFlushEntry:
                                ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(CatheterFlushEntryPage), new List<object> { value }));
                                return;
                        }

                        return;
                    }
                    _selectedEntry = value;
                    OnPropertyChanged("SelectedEntry");
                }

            }
        }

        // ICommand implementations
        private ICommand _entryButtonCommand;
        public ICommand EntryButtonCommand => _entryButtonCommand ?? (_entryButtonCommand = new Command(async () =>
        {
            var selectedEntry = await Xamarin.Forms.Application.Current.MainPage.DisplayActionSheet("Was wollen Sie hinzufügen?", "Abbrechen", null,
              AppResources.JournalOverviewPageCatheterFlushEntry, AppResources.JournalOverviewPageInfusionEntry, AppResources.JournalOverviewPageAdministeredDrugEntry, AppResources.JournalOverviewPageBloodWithdrawalEntry,
              AppResources.JournalOverviewPageBandagesChangingEntry, AppResources.JournalOverviewPageMicroClaveChangingEntry, AppResources.JournalOverviewPageStatlockChangingEntry);

            if (selectedEntry != null && selectedEntry != "Abbrechen")

            {
                if (selectedEntry == AppResources.JournalOverviewPageAdministeredDrugEntry)
                {
                    //if (await Application.Current.MainPage.DisplayAlert("Information", "Wollen Sie die für dieesen Schritt eine Anleitung ansehen?", "Ja", "Nein"))
                    //{
                    //    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(MaintenanceInstructionPage), null));
                    //    return;
                    //}
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(AdministeredDrugEntryPage), null));
                    return;
                }
                else if (selectedEntry == AppResources.JournalOverviewPageMicroClaveChangingEntry)
                {
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(MicroClaveChangingEntryPage), null));
                    return;
                }
                else if (selectedEntry == AppResources.JournalOverviewPageStatlockChangingEntry)
                {
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(StatlockChangingEntryPage), null));
                    return;
                }
                else if (selectedEntry == AppResources.JournalOverviewPageBloodWithdrawalEntry)
                {
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(BloodWithdrawalEntryPage), null));
                    return;
                }
                else if (selectedEntry == AppResources.JournalOverviewPageBandagesChangingEntry)
                {
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(BandageChangingEntryPage), null));
                    return;
                }
                else if (selectedEntry == AppResources.JournalOverviewPageInfusionEntry)
                {
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(InfusionEntryPage), null));
                    return;
                }
                else if (selectedEntry == AppResources.JournalOverviewPageCatheterFlushEntry)
                {
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(CatheterFlushEntryPage), null));
                    return;
                }
            }
        }));
    }
}
