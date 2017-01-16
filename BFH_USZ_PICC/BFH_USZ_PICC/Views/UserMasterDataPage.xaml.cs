using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Views
{
    public sealed partial class UserMasterDataPage : BaseContentPage
    {
        public UserMasterDataPage(ContentPage contained) : base(contained)
        {
            InitializeComponent();
            AddPickers();
        }

        void AddPickers()
        {   
            GenderPicker.Items.Insert(0, AppResources.JournalEntryNotSpecifiedText);
            GenderPicker.Items.Insert(1, AppResources.UserMasterDataPageMale);
            GenderPicker.Items.Insert(2, AppResources.UserMasterDataPageFemale);
        }
    }
}
