using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.Views;
using BFH_USZ_PICC.Views.JournalEntries;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using static BFH_USZ_PICC.Models.JournalEntry;
using System.Threading.Tasks;
using System.Linq;

namespace BFH_USZ_PICC.ViewModels
{
    class JournalOverviewViewModel : ViewModelBase
    {
        private ILocalUserDataService _dataService;

        public JournalOverviewViewModel()
        {
            //JournalEntriesList = JournalEntry.AllEnteredJournalEntries;
            // Getting the dataservice
            _dataService = ServiceLocator.Current.GetInstance<ILocalUserDataService>();

            // TODO: Remove, only till final navigation structure calls OnNavigatedToAsync also for root pages
            TempLoad();
        }

        #region navigation events

        public async void TempLoad()
        {
            var entryList = await _dataService.GetJournalEntriesAsync();
            JournalEntriesList = entryList.OrderByDescending((x) => x.ExecutionDate).ThenByDescending((x) => x.CreateDate).ToList();
        }

        public async override Task OnNavigatedToAsync(NavigationMode mode)
        {
            // TODO: FIX/MOVE
            var entryList = await _dataService.GetJournalEntriesAsync();
            JournalEntriesList = entryList.OrderByDescending((x) => x.ExecutionDate).ThenByDescending((x) => x.CreateDate).ToList();

            await base.OnNavigatedToAsync(mode);
        }

        #endregion

        #region public properties

        /// <summary>
        /// List of all existing JournalEntry objects to display.
        /// </summary>
        private List<JournalEntry> _journalEntriesList;
        public List<JournalEntry> JournalEntriesList
        {
            get { return _journalEntriesList; }
            set { Set(ref _journalEntriesList, value); }
        }

        #endregion

        #region relay commands

        private RelayCommand _addEntryCommand;
        public RelayCommand AddEntryCommand => _addEntryCommand ?? (_addEntryCommand = new RelayCommand(async () =>
        {
            var selectedEntry = await Xamarin.Forms.Application.Current.MainPage.DisplayActionSheet(AppResources.JournalOverviewViewModelWhichJournalEntryText, AppResources.CancelButtonText, null,
              AppResources.JournalOverviewPageCatheterFlushEntry, AppResources.JournalOverviewPageInfusionEntry, AppResources.JournalOverviewPageAdministeredDrugEntry, AppResources.JournalOverviewPageBloodWithdrawalEntry,
              AppResources.JournalOverviewPageBandagesChangingEntry, AppResources.JournalOverviewPageMicroClaveChangingEntry, AppResources.JournalOverviewPageStatlockChangingEntry);

            if (selectedEntry != null && selectedEntry != AppResources.CancelButtonText)

            {
                Type targetPageType = null;
                if (selectedEntry == AppResources.JournalOverviewPageAdministeredDrugEntry)
                {
                    targetPageType = typeof(AdministeredDrugEntryPage);
                }
                else if (selectedEntry == AppResources.JournalOverviewPageMicroClaveChangingEntry)
                {
                    targetPageType = typeof(MicroClaveChangingEntryPage);
                }
                else if (selectedEntry == AppResources.JournalOverviewPageStatlockChangingEntry)
                {
                    targetPageType = typeof(StatlockChangingEntryPage);
                }
                else if (selectedEntry == AppResources.JournalOverviewPageBloodWithdrawalEntry)
                {
                    targetPageType = typeof(BloodWithdrawalEntryPage);
                }
                else if (selectedEntry == AppResources.JournalOverviewPageBandagesChangingEntry)
                {
                    targetPageType = typeof(BandageChangingEntryPage);
                }
                else if (selectedEntry == AppResources.JournalOverviewPageInfusionEntry)
                {
                    targetPageType = typeof(InfusionEntryPage);
                }
                else if (selectedEntry == AppResources.JournalOverviewPageCatheterFlushEntry)
                {
                    targetPageType = typeof(CatheterFlushEntryPage);
                }

                if (targetPageType != null)
                {
                    // TODO: FIX
                    // await ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(targetPageType));
                }
            }
        }));

        private RelayCommand<JournalEntry> _itemSelectedCommand;
        public RelayCommand<JournalEntry> ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<JournalEntry>((JournalEntry selectedItem) =>
        {
            // Item selected, handle navigation
            // We have to use a fucking if-elseif because C# 6 can't switch over types yet. FML
            Type entryType = selectedItem.GetType();
            Type targetPageType = null;
            if (entryType == typeof(AdministeredDrugEntry))
            {
                targetPageType = typeof(AdministeredDrugEntryPage);
            }
            else if (entryType == typeof(MicroClaveChangingEntry))
            {
                targetPageType = typeof(MicroClaveChangingEntryPage);
            }
            else if (entryType == typeof(StatlockChangingEntry))
            {
                targetPageType = typeof(StatlockChangingEntryPage);
            }
            else if (entryType == typeof(BloodWithdrawalEntry))
            {
                targetPageType = typeof(BloodWithdrawalEntryPage);
            }
            else if (entryType == typeof(BandageChangingEntry))
            {
                targetPageType = typeof(BandageChangingEntryPage);
            }
            else if (entryType == typeof(InfusionEntry))
            {
                targetPageType = typeof(InfusionEntryPage);
            }
            else if (entryType == typeof(CatheterFlushEntry))
            {
                targetPageType = typeof(CatheterFlushEntryPage);
            }

            if (targetPageType != null)
            {
                // TODO: FIX
                //((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(targetPageType, new List<object> { value.ID }));
            }
        }));

        #endregion

    }
}
