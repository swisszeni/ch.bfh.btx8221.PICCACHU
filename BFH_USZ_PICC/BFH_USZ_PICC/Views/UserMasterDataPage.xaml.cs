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
        public UserMasterDataPage(ContentPage contained, bool isEnabled) : base(contained)
        {
            InitializeComponent();
            AddPickers();

            ((MasterDataViewModel)BindingContext).MasterData = UserMasterData.MasterData;
            ((MasterDataViewModel)BindingContext).IsUserInputEnabled = isEnabled;           

        }

        void AddPickers()
        {   
            GenderPicker.Items.Insert(0, string.Empty);
            GenderPicker.Items.Insert(1, AppResources.UserMasterDataPageMisterText);
            GenderPicker.Items.Insert(2, AppResources.UserMasterDataPageMissText);
        }
    }
}
