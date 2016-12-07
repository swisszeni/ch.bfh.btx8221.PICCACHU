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

            ((MasterDataViewModel)BindingContext).EnableUserInput = isEnabled;

            SalutationPicker.Items.Insert(0, " ");
            SalutationPicker.Items.Insert(1, "Herr");
            SalutationPicker.Items.Insert(2, "Frau");


        }

        //void EditButtonClicked(object o, EventArgs e)
        //{
            
            
        //}

        //async void DeleteAllMasterDataButtonClicked(object o, EventArgs e)
        //{
        //    var deleteInput = await DisplayAlert(AppResources.WarningText, AppResources.UserMasterDataPageDelteAllPersonalDataText, AppResources.YesButtonText, AppResources.NoButtonText);
        //    if (deleteInput)
        //    {
        //        BindingContext = null;
        //        EnableUserInput(false);
        //        checkIfBirthdateSet();
        //    }

        //}

        //void SaveButtonClicked(object o, EventArgs e)
        //{
        //    EnableUserInput(false);
        //    checkIfBirthdateSet();


        //}

        //private void EnableUserInput(bool yesOrNo)
        //{
        //    SalutationPicker.IsEnabled = yesOrNo;
        //    Surname.IsEnabled = yesOrNo;
        //    Name.IsEnabled = yesOrNo;
        //    Street.IsEnabled = yesOrNo;
        //    Zip.IsEnabled = yesOrNo;
        //    Place.IsEnabled = yesOrNo;
        //    Email.IsEnabled = yesOrNo;
        //    Phone.IsEnabled = yesOrNo;
        //    Mobile.IsEnabled = yesOrNo;
        //    BirthdatePicker.IsEnabled = yesOrNo;
        //    BirthdatePicker.IsVisible = yesOrNo;
            
        //}

        private void checkIfBirthdateSet()
        {
            UserMasterData checker = (UserMasterData)BindingContext;
            if (checker == null || checker.Birthdate == null)
            {
                BirthdatePicker.IsVisible = false;
            }
            else { BirthdatePicker.IsVisible = true; }

        }

    }
}
