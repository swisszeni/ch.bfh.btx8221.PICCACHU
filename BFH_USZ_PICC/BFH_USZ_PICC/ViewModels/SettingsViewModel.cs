using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
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
    public class SettingsViewModel : ViewModelBase
    {
        private IReminderNotification _notifier = DependencyService.Get<IReminderNotification>();
       
        private DateTimeOffset _reminderStartDate;
        public DateTimeOffset ReminderStartDate
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
                Set(ref _isReminderSet, value);
                CheckReminderToggleCommand.Execute(null);
            }

        }

        private bool _isReminderEditable = true;
        public bool IsReminderEditable
        {
            get { return _isReminderEditable; }
            set { Set(ref _isReminderEditable, value); }

        }

        private RelayCommand _addNotificationsCommand;
        public RelayCommand AddNotificationsCommand => _addNotificationsCommand ?? (_addNotificationsCommand = new RelayCommand(() =>
        {
            IsReminderEditable = false;

            DateTimeOffset reminderStartDate = ReminderStartDate.Date;
            DateTimeOffset maintenanceReminderStartDateTime = reminderStartDate.Add(ReminderDayTime);
            maintenanceReminderStartDateTime.ToUniversalTime();

            if(ReminderRepetition != 0)
            {
                _notifier.AddNotification(maintenanceReminderStartDateTime, ReminderFrequency + 1, ReminderRepetition, AppResources.InformationText, AppResources.SettingsPageMaintenanceReminderInformationText, false);

            }
            else
            {
                _notifier.AddNotification(maintenanceReminderStartDateTime, ReminderFrequency + 1, ReminderRepetition, AppResources.InformationText, AppResources.SettingsPageMaintenanceReminderInformationText, true);

            }
        }));


        private RelayCommand _moveToMasterDataPageCommand;
        public RelayCommand MoveToMasterDataPageCommand => _moveToMasterDataPageCommand ?? (_moveToMasterDataPageCommand = new RelayCommand(() =>
        {
            ((Shell)Application.Current.MainPage).Detail.Navigation.PushAsync(new BasePage(typeof(UserMasterDataPage), new List<object> { false }));

        }));

        private RelayCommand _checkReminderToggleCommand;
        public RelayCommand CheckReminderToggleCommand => _checkReminderToggleCommand ?? (_checkReminderToggleCommand = new RelayCommand(async () =>
        {
            if (!IsReminderEditable && !IsReminderSet)
            {
                if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.SettingsPageDelteScheduledRemindersText, AppResources.YesButtonText, AppResources.NoButtonText))
                {
                    IsReminderEditable = true;
                    _notifier.RemoveAllNotifications();
                }
                else
                {
                    IsReminderSet = true;
                }


            }

        }));
    }
}
