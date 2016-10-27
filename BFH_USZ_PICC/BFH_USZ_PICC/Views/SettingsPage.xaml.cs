using BFH_USZ_PICC.Interfaces;
using System;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public sealed partial class SettingsPage : BaseContentPage
    {       
        IReminderNotification notifier = DependencyService.Get<IReminderNotification>();
        
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
            
            DateTime reminderStartDate = ReminderStartDate.Date;
            DateTime maintenanceReminderStartDateTime = reminderStartDate.Add(ReminderDailyTime.Time);

            int MaintenanceReminderRepetition = Repetition.SelectedIndex;
          
            notifier.AddNotification(maintenanceReminderStartDateTime, MaintenanceReminderRepetition);

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
                    EditWeeklyReminder.IsVisible = false;
                   
                    enableInputForNotifications(true);
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
