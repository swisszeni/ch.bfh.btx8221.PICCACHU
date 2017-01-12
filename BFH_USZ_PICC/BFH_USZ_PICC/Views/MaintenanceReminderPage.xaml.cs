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
    }
}
