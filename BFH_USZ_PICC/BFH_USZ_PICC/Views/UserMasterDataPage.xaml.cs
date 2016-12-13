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
            ((MasterDataViewModel)BindingContext).EnableUserInput = isEnabled;           

        }

        void AddPickers()
        {   
            SalutationPicker.Items.Insert(0, string.Empty);
            SalutationPicker.Items.Insert(1, AppResources.UserMasterDataPageMisterText);
            SalutationPicker.Items.Insert(2, AppResources.UserMasterDataPageMissText);
        }
    }
}
