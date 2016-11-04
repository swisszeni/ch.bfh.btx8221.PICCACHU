using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
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

            SalutationPicker.Items.Insert(0, " ");
            SalutationPicker.Items.Insert(1, "Herr");
            SalutationPicker.Items.Insert(2, "Frau");


            if (UserMasterData.MasterData != null)
            {
                enableUserInput(false);

            }
            else
            {
                enableUserInput(true);
            }

            BindingContext = UserMasterData.MasterData;

        }

        void EditButtonClicked(object o, EventArgs e)
        {
            enableUserInput(true);
            
        }

        async void DeleteAllMasterDataButtonClicked(object o, EventArgs e)
        {
            var deleteInput = await DisplayAlert("Warnung", "Wollen Sie wirklich alle persönlichen Angaben löschen?", "Ja", "Nein");
            if (deleteInput)
            {
                BindingContext = null;
                enableUserInput(false);
                checkIfBirthdateSet();
            }

        }

        void SaveButtonClicked(object o, EventArgs e)
        {
            //var userMasterData = UserMasterData.MasterData;
            //userMasterData.Salutation = (Sex)SalutationPicker.SelectedIndex;
            //userMasterData.Surname = Surname.Text;
            //userMasterData.Name = Name.Text;
            //userMasterData.Street = Street.Text;
            //userMasterData.Zip = Zip.Text;
            //userMasterData.Place = Place.Text;
            //userMasterData.Email = Email.Text;
            //userMasterData.Phone = Phone.Text;
            //userMasterData.Mobile = Mobile.Text;
            //userMasterData.Birthdate = BirthdatePicker.Date;

            //BindingContext = userMasterData;

            enableUserInput(false);
            checkIfBirthdateSet();


        }

        void CancelButtonClicked(object o, EventArgs e)
        {
            enableUserInput(false);
            //FIXME: Add proper cancel behaviour (currentlly, press the cancel button does not return to the previous state.

        }

        private void enableUserInput(bool yesOrNo)
        {
            SalutationPicker.IsEnabled = yesOrNo;
            Surname.IsEnabled = yesOrNo;
            Name.IsEnabled = yesOrNo;
            Street.IsEnabled = yesOrNo;
            Zip.IsEnabled = yesOrNo;
            Place.IsEnabled = yesOrNo;
            Email.IsEnabled = yesOrNo;
            Phone.IsEnabled = yesOrNo;
            Mobile.IsEnabled = yesOrNo;
            BirthdatePicker.IsEnabled = yesOrNo;
            BirthdatePicker.IsVisible = yesOrNo;

            SaveAndCancelStackLayout.IsVisible = yesOrNo;
            EditAndDeleteStackLayout.IsVisible = !yesOrNo;
        }

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
