using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.Services;
using BFH_USZ_PICC.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.ViewModels
{
    public class MaintenanceReminderViewModel : ViewModelBase
    {
        private IReminderNotification _notifier = DependencyService.Get<IReminderNotification>();


        #region navigation events
        public async override Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            LoadFromModel();
        }

        public override Task OnNavigatedFromAsync()
        {
            SaveToSettings();

            // Return "fake task" since Task.CompletedTask is not supported in this PCL
            return Task.FromResult(false);
        }

        #endregion

        #region private methods
        private void CreateNotifications()
        {
            //Get the start date first, afterwards add the daily time
            DateTimeOffset maintenanceReminderStartDateTime = SettingsService.ReminderStartDateTime;
            maintenanceReminderStartDateTime.ToUniversalTime();

            //Check if the user want to set a repetition limit or if the repetition should be planned without a a limit
            if (ReminderRepetition != 0)
            {
                _notifier.AddNotification(maintenanceReminderStartDateTime, SettingsService.ReminderFrequency + 1, SettingsService.ReminderRepetition, AppResources.InformationText, AppResources.SettingsPageMaintenanceReminderInformationText, false);

            }
            else
            {
                _notifier.AddNotification(maintenanceReminderStartDateTime, SettingsService.ReminderFrequency + 1, SettingsService.ReminderRepetition, AppResources.InformationText, AppResources.SettingsPageMaintenanceReminderInformationText, true);

            }
        }

        private void LoadFromModel()
        {
            var reminderStartDateTimeLocalTime = SettingsService.ReminderStartDateTime.ToLocalTime();
            ReminderDayTime = reminderStartDateTimeLocalTime.TimeOfDay;
            ReminderStartDate = reminderStartDateTimeLocalTime.Date;

            ReminderFrequency = SettingsService.ReminderFrequency;
            ReminderRepetition = SettingsService.ReminderRepetition;
            IsReminderSet = SettingsService.IsReminderSet;

            RaisePropertyChanged("");

        }

        private void SaveToSettings()
        {
            if (IsReminderSet)
            {
                var reminderStartDate = ReminderStartDate.Date;
                var reminderTime = new TimeSpan(ReminderDayTime.Hours, ReminderDayTime.Minutes, 0);
                var reminderStartDateTimeUTC = reminderStartDate.Add(reminderTime).ToUniversalTime();

                if (!SettingsService.ReminderStartDateTime.Equals(reminderStartDateTimeUTC) || SettingsService.ReminderFrequency != ReminderFrequency
                    || SettingsService.ReminderRepetition != ReminderRepetition)
                {
                    _notifier.RemoveAllNotifications();

                    SettingsService.ReminderStartDateTime = reminderStartDate.Add(reminderTime).ToUniversalTime();
                    SettingsService.ReminderFrequency = ReminderFrequency;
                    SettingsService.ReminderRepetition = ReminderRepetition;
                    SettingsService.IsReminderSet = IsReminderSet;

                    CreateNotifications();
                }
            }
            else
            {
                SettingsService.ReminderStartDateTime = DateTime.Now;
                SettingsService.ReminderFrequency = 0;
                SettingsService.ReminderRepetition = 6;
                SettingsService.IsReminderSet = IsReminderSet;

                _notifier.RemoveAllNotifications();
            }

        }

        private async void CheckReminderToggle()
        {
            {
                if (SettingsService.IsReminderSet)
                {
                    if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.SettingsPageDelteScheduledRemindersText, AppResources.YesButtonText, AppResources.NoButtonText))
                    {
                        SaveToSettings();
                    }
                    else
                    {
                        IsReminderSet = true;
                    }
                }
            }
        }
        #endregion

        #region public properties
        private DateTime _reminderStartDate;
        public DateTime ReminderStartDate
        {
            get { return _reminderStartDate; }
            set { Set(ref _reminderStartDate, value); }
        }

        private TimeSpan _reminderDayTime;
        public TimeSpan ReminderDayTime
        {
            get { return _reminderDayTime; }
            set { Set(ref _reminderDayTime, value); }
        }

        private int _reminderFrequency;
        public int ReminderFrequency
        {
            get { return _reminderFrequency; }
            set { Set(ref _reminderFrequency, value); }
        }

        private int _reminderRepetition;
        public int ReminderRepetition
        {
            get { return _reminderRepetition; }
            set { Set(ref _reminderRepetition, value); }
        }

        private bool _isReminderSet;
        public bool IsReminderSet
        {
            get { return _isReminderSet; }
            set
            {
                if (!value && _isReminderSet)
                {
                    CheckReminderToggle();
                }
                Set(ref _isReminderSet, value);

            }
        }

        #endregion
    }
}