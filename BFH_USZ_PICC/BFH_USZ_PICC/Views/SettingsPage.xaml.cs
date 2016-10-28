using Acr.Notifications;
using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{

    public sealed partial class SettingsPage : BaseContentPage
    {
        IReminderNotification notifier = DependencyService.Get<IReminderNotification>();
        private List<string> plannedNotifications = new List<string>();

        public SettingsPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();

            int temp = 0;
            while (temp < 20)
            {
                Repetition.Items.Insert(temp, temp.ToString());
                temp++;
            }
            Repetition.SelectedIndex = 0;

        }

        void AddNotificationButtonClicked(object o, EventArgs e)
        {
            EditWeeklyReminder.IsEnabled = false;

            DateTimeOffset reminderStartDate = ReminderStartDate.Date;
            DateTimeOffset maintenanceReminderStartDateTime = reminderStartDate.Add(ReminderDailyTime.Time);
            maintenanceReminderStartDateTime.ToUniversalTime();
            int maintenanceReminderRepetition = Repetition.SelectedIndex;

           
            notifier.AddNotification(maintenanceReminderStartDateTime, maintenanceReminderRepetition);

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

            enableInputForNotifications(false);

        }

        async void WeeklyMaintenanceReminderToggled(object o, EventArgs e)
        {
            if (WeeklyMaintenanceReminder.IsToggled)
            {
                EditWeeklyReminder.IsVisible = true;
            }
            else
            {
                bool deleteReminders = await DisplayAlert("Information", "Wollen Sie alle geplanten Wartungserinnerungen löschen?", "Ja", "Nein");
                if (deleteReminders)
                {
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
                        notifier.RemoveAllNotifications();
                }
                else
                {
                    WeeklyMaintenanceReminder.IsToggled = true;
                }
            }
        }

        private void enableInputForNotifications(bool yesOrNo)
        {
            AddNotificationButton.IsEnabled = yesOrNo;
            ReminderStartDate.IsEnabled = yesOrNo;
            ReminderDailyTime.IsEnabled = yesOrNo;
            Repetition.IsEnabled = yesOrNo;
        }
    }
}
