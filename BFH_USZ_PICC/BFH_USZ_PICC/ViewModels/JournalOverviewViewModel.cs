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
using BFH_USZ_PICC.ViewModels.JournalEntries;

namespace BFH_USZ_PICC.ViewModels
{
    class JournalOverviewViewModel : ViewModelBase
    {
        private ILocalUserDataService _dataService;

        public JournalOverviewViewModel()
        {
            // Getting the dataservice
            _dataService = ServiceLocator.Current.GetInstance<ILocalUserDataService>();
        }

        #region navigation events

        public override Task InitializeAsync(List<object> navigationData)
        {
            PopulateEntriesAsync();

            return base.InitializeAsync(navigationData);
        }

        public override Task OnNavigatedToAsync(NavigationMode mode)
        {
            PopulateEntriesAsync();

            return base.OnNavigatedToAsync(mode);
        }

        #endregion

        #region private methods

        private async void PopulateEntriesAsync()
        {
            var entryList = await _dataService.GetJournalEntriesAsync();
            JournalEntriesList = entryList.OrderByDescending((x) => x.ExecutionDate).ThenByDescending((x) => x.CreateDate).ToList();
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
                Type targetPageVMType = null;
                if (selectedEntry == AppResources.JournalOverviewPageAdministeredDrugEntry)
                {
                    targetPageVMType = typeof(AdministeredDrugViewModel);
                }
                else if (selectedEntry == AppResources.JournalOverviewPageMicroClaveChangingEntry)
                {
                    targetPageVMType = typeof(MicroClaveChangingViewModel);
                }
                else if (selectedEntry == AppResources.JournalOverviewPageStatlockChangingEntry)
                {
                    targetPageVMType = typeof(StatlockChangingViewModel);
                }
                else if (selectedEntry == AppResources.JournalOverviewPageBloodWithdrawalEntry)
                {
                    targetPageVMType = typeof(BloodWithdrawalViewModel);
                }
                else if (selectedEntry == AppResources.JournalOverviewPageBandagesChangingEntry)
                {
                    targetPageVMType = typeof(BandageChangingViewModel);
                }
                else if (selectedEntry == AppResources.JournalOverviewPageInfusionEntry)
                {
                    targetPageVMType = typeof(InfusionViewModel);
                }
                else if (selectedEntry == AppResources.JournalOverviewPageCatheterFlushEntry)
                {
                    targetPageVMType = typeof(CatheterFlushViewModel);
                }

                if (targetPageVMType != null)
                {
                    await NavigationService.NavigateToAsync(targetPageVMType);
                }
            }
        }));

        private RelayCommand<JournalEntry> _itemSelectedCommand;
        public RelayCommand<JournalEntry> ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<JournalEntry>((JournalEntry selectedItem) =>
        {
            // Item selected, handle navigation
            // We have to use a fucking if-elseif because C# 6 can't switch over types yet. FML
            Type entryType = selectedItem.GetType();
            Type targetVMType = null;
            if (entryType == typeof(AdministeredDrugEntry))
            {
                targetVMType = typeof(AdministeredDrugViewModel);
            }
            else if (entryType == typeof(MicroClaveChangingEntry))
            {
                targetVMType = typeof(MicroClaveChangingViewModel);
            }
            else if (entryType == typeof(StatlockChangingEntry))
            {
                targetVMType = typeof(StatlockChangingViewModel);
            }
            else if (entryType == typeof(BloodWithdrawalEntry))
            {
                targetVMType = typeof(BloodWithdrawalViewModel);
            }
            else if (entryType == typeof(BandageChangingEntry))
            {
                targetVMType = typeof(BandageChangingViewModel);
            }
            else if (entryType == typeof(InfusionEntry))
            {
                targetVMType = typeof(InfusionViewModel);
            }
            else if (entryType == typeof(CatheterFlushEntry))
            {
                targetVMType = typeof(CatheterFlushViewModel);
            }

            if (targetVMType != null)
            {
                NavigationService.NavigateToAsync(targetVMType, new List<object> { selectedItem.ID });
            }
        }));

        #endregion

    }
}
