using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public sealed partial class MaintenanceReminderPage : BaseContentPage
    {
        public MaintenanceReminderPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();

            // FIXME: move to ViewModel
            //Loads the current reminder settings to the page
            ((MaintenanceReminderViewModel)BindingContext).Reminder = MaintenanceReminder.Reminder;

            //Initialize the pickers
            int temp = 1;
            Repetition.Items.Insert(0, AppResources.SettingsPageRepetitionPickerUnlimitedRepetitionText);
            while (temp < 50)
            {
                Repetition.Items.Insert(temp, temp.ToString());
                //Frequency needs to start at 1!
                Frequency.Items.Insert(temp - 1, temp.ToString());
                temp++;
            }

        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            // FIXME: move to ViewModel
            //If no reminder is set, add the current date and the current time to the pickers, in order to simplify the input for the user           
            if (!((MaintenanceReminderViewModel)BindingContext).IsReminderSet)
            {
                //Set the start parameters for the pickers
                ((MaintenanceReminderViewModel)BindingContext).ReminderStartDate = DateTimeOffset.Now.Date;
                ((MaintenanceReminderViewModel)BindingContext).ReminderDayTime = DateTimeOffset.Now.TimeOfDay;
                ((MaintenanceReminderViewModel)BindingContext).ReminderRepetition = 0;
                ((MaintenanceReminderViewModel)BindingContext).ReminderFrequency = 6;
            }
        }

    }
}
