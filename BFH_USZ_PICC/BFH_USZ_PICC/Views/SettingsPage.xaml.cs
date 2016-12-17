using BFH_USZ_PICC.Interfaces;
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

            int temp = 1;
            Repetition.Items.Insert(0, AppResources.SettingsPageRepetitionPickerUnlimitedRepetitionText);
            while (temp < 50)
            {
                Repetition.Items.Insert(temp, temp.ToString());
                //Frequency needs to start at 1!
                Frequency.Items.Insert(temp - 1, temp.ToString());
                temp++;
            }
            //Set the start parameters for the pickers
            Repetition.SelectedIndex = 0;
            Frequency.SelectedIndex = 6;

        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            if (!((SettingsViewModel)BindingContext).IsReminderSet) {

                ((SettingsViewModel)BindingContext).ReminderStartDate = DateTimeOffset.Now.Date;
                ((SettingsViewModel)BindingContext).ReminderDayTime = DateTimeOffset.Now.TimeOfDay;
            }
        }

    }
}