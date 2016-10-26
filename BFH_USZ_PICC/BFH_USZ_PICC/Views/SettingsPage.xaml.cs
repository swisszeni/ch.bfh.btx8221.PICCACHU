using BFH_USZ_PICC.Interfaces;
using System;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public sealed partial class SettingsPage : BaseContentPage
    {
        public int MaintenanceReminderRepetition { get; set; }
        public DateTime MaintenanceReminderStartDate { get; set; }
        public TimeSpan MaintenanceReminderDailyTime { get; set; }
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

            MaintenanceReminderStartDate = ReminderStartDate.Date;
            MaintenanceReminderDailyTime = ReminderDailyTime.Time;
            MaintenanceReminderRepetition = Repetition.SelectedIndex;
            
            var notifier = DependencyService.Get<IReminderNotification>();
            notifier.AddNotification(MaintenanceReminderStartDate, MaintenanceReminderDailyTime, MaintenanceReminderRepetition);

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
                    var notifier = DependencyService.Get<IReminderNotification>();
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
