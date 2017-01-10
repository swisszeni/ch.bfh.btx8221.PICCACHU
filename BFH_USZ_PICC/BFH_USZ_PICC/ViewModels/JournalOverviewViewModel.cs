using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.Views;
using BFH_USZ_PICC.Views.JournalEntries;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using static BFH_USZ_PICC.Models.JournalEntry;

namespace BFH_USZ_PICC.ViewModels
{
    class JournalOverviewViewModel : ViewModelBase
    {
        public JournalOverviewViewModel()
        {
            JournalEntriesList = JournalEntry.AllEnteredJournalEntries;
        }

        /// <summary>
        /// Binds all the glossary entries to a the "GlossaryList" ListView
        /// </summary>
        private ObservableCollection<JournalEntry> _journalEntriesList;
        public ObservableCollection<JournalEntry> JournalEntriesList
        {
            get { return _journalEntriesList; }
            set { Set(ref _journalEntriesList, value); }
        }

        private JournalEntry _selectedEntry;
        public JournalEntry SelectedEntry
        {
            get { return _selectedEntry; }
            set
            {
                if (Set(() => SelectedEntry, ref _selectedEntry, value) & _selectedEntry != null)
                {
                    AllPossibleJournalEntries selectedEntryType = value.Entry;
                    // TODO: FIX
                    //switch (selectedEntryType)
                    //{
                    //    case AllPossibleJournalEntries.AdministeredDrugEntry:
                    //        ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(AdministeredDrugEntryPage), new List<object> { value }));
                    //        return;
                    //    case AllPossibleJournalEntries.MicroClaveEntry:
                    //        ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(MicroClaveChangingEntryPage), new List<object> { value }));
                    //        return;
                    //    case AllPossibleJournalEntries.StatlockEntry:
                    //        ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(StatlockChangingEntryPage), new List<object> { value }));
                    //        return;
                    //    case AllPossibleJournalEntries.BloodWithdrawalEntry:
                    //        ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(BloodWithdrawalEntryPage), new List<object> { value }));
                    //        return;
                    //    case AllPossibleJournalEntries.BandagesChangingEntry:
                    //        ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(BandageChangingEntryPage), new List<object> { value }));
                    //        return;
                    //    case AllPossibleJournalEntries.InfusionEntry:
                    //        ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(InfusionEntryPage), new List<object> { value }));
                    //        return;
                    //    case AllPossibleJournalEntries.CatheterFlushEntry:
                    //        ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(CatheterFlushEntryPage), new List<object> { value }));
                    //        return;
                    //    default:
                    //        return;
                    //}
                }

            }
        }

        // ICommand implementations
        private RelayCommand _entryButtonCommand;
        public RelayCommand EntryButtonCommand => _entryButtonCommand ?? (_entryButtonCommand = new RelayCommand(async () =>
        {
            var selectedEntry = await Xamarin.Forms.Application.Current.MainPage.DisplayActionSheet(AppResources.JournalOverviewViewModelWhichJournalEntryText, AppResources.CancelButtonText, null,
              AppResources.JournalOverviewPageCatheterFlushEntry, AppResources.JournalOverviewPageInfusionEntry, AppResources.JournalOverviewPageAdministeredDrugEntry, AppResources.JournalOverviewPageBloodWithdrawalEntry,
              AppResources.JournalOverviewPageBandagesChangingEntry, AppResources.JournalOverviewPageMicroClaveChangingEntry, AppResources.JournalOverviewPageStatlockChangingEntry);

            if (selectedEntry != null && selectedEntry != AppResources.CancelButtonText)

            {
                if (selectedEntry == AppResources.JournalOverviewPageAdministeredDrugEntry)
                {
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(AdministeredDrugEntryPage)));
                    return;
                }
                else if (selectedEntry == AppResources.JournalOverviewPageMicroClaveChangingEntry)
                {
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(MicroClaveChangingEntryPage)));
                    return;
                }
                else if (selectedEntry == AppResources.JournalOverviewPageStatlockChangingEntry)
                {
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(StatlockChangingEntryPage)));
                    return;
                }
                else if (selectedEntry == AppResources.JournalOverviewPageBloodWithdrawalEntry)
                {
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(BloodWithdrawalEntryPage)));
                    return;
                }
                else if (selectedEntry == AppResources.JournalOverviewPageBandagesChangingEntry)
                {
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(BandageChangingEntryPage)));
                    return;
                }
                else if (selectedEntry == AppResources.JournalOverviewPageInfusionEntry)
                {
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(InfusionEntryPage)));
                    return;
                }
                else if (selectedEntry == AppResources.JournalOverviewPageCatheterFlushEntry)
                {
                    await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(CatheterFlushEntryPage)));
                    return;
                }
            }
        }));
    }
}
