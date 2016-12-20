using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static BFH_USZ_PICC.Views.UserMasterDataPage;

namespace BFH_USZ_PICC.Views
{

    public sealed partial class SettingsPage : BaseContentPage
    {
        public SettingsPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();

            //Loads the current reminder settings to the page
            ((SettingsViewModel)BindingContext).Reminder = MaintenanceReminder.Reminder;

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
            
            //If no reminder is set, add the current date and the current time to the pickers, in order to simplify the input for the user           
            if (!((SettingsViewModel)BindingContext).IsReminderSet)
            {
                //Set the start parameters for the pickers
                ((SettingsViewModel)BindingContext).ReminderStartDate = DateTimeOffset.Now.Date;
                ((SettingsViewModel)BindingContext).ReminderDayTime = DateTimeOffset.Now.TimeOfDay;
                ((SettingsViewModel)BindingContext).ReminderRepetition = 0;
                ((SettingsViewModel)BindingContext).ReminderFrequency = 6;
            }             
        }
    }
}