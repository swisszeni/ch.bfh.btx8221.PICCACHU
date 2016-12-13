using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Resx;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static BFH_USZ_PICC.Views.UserMasterDataPage;

namespace BFH_USZ_PICC.Views
{

    public sealed partial class SettingsPage : BaseContentPage
    {
        IReminderNotification notifier; 
        private List<string> plannedNotifications;

        public SettingsPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();

            notifier = DependencyService.Get<IReminderNotification>();
            plannedNotifications = new List<string>();

            int temp = 0;
            while (temp < 20)
            {
                Repetition.Items.Insert(temp, temp.ToString());
                //Frequency needs to start at 1!
                Frequency.Items.Insert(temp, (temp + 1).ToString());
                temp++;
            }
            Repetition.SelectedIndex = 0;
            Frequency.SelectedIndex = 6;

        }

        void AddNotificationButtonClicked(object o, EventArgs e)
        {
            EditWeeklyReminder.IsEnabled = false;
            EnableInputForNotifications(false);

            DateTimeOffset reminderStartDate = ReminderStartDate.Date;
            DateTimeOffset maintenanceReminderStartDateTime = reminderStartDate.Add(ReminderDailyTime.Time);
            maintenanceReminderStartDateTime.ToUniversalTime();
            int maintenanceReminderRepetition = Repetition.SelectedIndex;
            int dailyInterval = Frequency.SelectedIndex + 1;

            notifier.AddNotification(maintenanceReminderStartDateTime, dailyInterval, maintenanceReminderRepetition, AppResources.InformationText, AppResources.SettingsPageMaintenanceReminderInformationText);

        }

        void PersonalMasterDataClicked(object o, EventArgs e)
        {
            Navigation.PushAsync(new BasePage(typeof(UserMasterDataPage), new List<object> { false }));
        }

        async void WeeklyMaintenanceReminderToggled(object o, EventArgs e)
        {
            if (WeeklyMaintenanceReminder.IsToggled)
            {
                EditWeeklyReminder.IsVisible = true;
                
            }
            else
            {
                bool deleteReminders = await DisplayAlert(AppResources.WarningText , AppResources.SettingsPageDelteScheduledRemindersText, AppResources.YesButtonText, AppResources.NoButtonText);
                if (deleteReminders)
                {
                    EditWeeklyReminder.IsVisible = false;
                    EnableInputForNotifications(true);
                    notifier.RemoveAllNotifications();                    
                }
                else
                {
                    WeeklyMaintenanceReminder.IsToggled = true;
                }
            }
        }

        private void EnableInputForNotifications(bool yesOrNo)
        {
            AddNotificationButton.IsEnabled = yesOrNo;
            ReminderStartDate.IsEnabled = yesOrNo;
            ReminderDailyTime.IsEnabled = yesOrNo;
            Repetition.IsEnabled = yesOrNo;
            Frequency.IsEnabled = yesOrNo;
        }
    }
}

//    try
//    {
//        Notifications.Instance.CancelAll();

//    }
//    catch
//    {
//        foreach (var noti in plannedNotifications)
//        {
//            Notifications.Instance.Cancel(noti);
//        }
//    }

//    EditWeeklyReminder.IsVisible = false;
//    enableInputForNotifications(true);

// int reminderRepetition = 0;
//TimeSpan firstReminder = maintenanceReminderStartDateTime - DateTimeOffset.UtcNow;
//int reminderFrequencyinDays = 7;
//Notification not = new Notification();
//not.Title = "Wartung fällig!";
//not.Message = "Ihr PICC Katheter sollte gewartet werden.";            

////this loop checks how many reminder repetation the user wants to plan
//while (reminderRepetition <= Repetition.SelectedIndex)
//{
//    //Checks if the notification date time is in the future. If not, the notification can not be planned.
//   // not.When = firstReminder + (new TimeSpan(0, 0, 0, reminderRepetition * reminderFrequencyinDays));
//    not.SetSchedule(firstReminder + (new TimeSpan(0, 0, 0, reminderRepetition * reminderFrequencyinDays)));

//    try
//    {
//        var notificationId = Notifications.Instance.Send(not);
//        plannedNotifications.Add(notificationId);
//    }
//    catch
//    {
//       //not.SetSchedule(not.When);
//       Notifications.Instance.Send(not);
//    }

//    reminderRepetition++;
//}