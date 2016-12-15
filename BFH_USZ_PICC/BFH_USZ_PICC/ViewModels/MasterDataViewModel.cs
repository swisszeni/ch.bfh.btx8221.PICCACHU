using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.ViewModels
{
    public class MasterDataViewModel : ViewModelBase
    {
        public MasterDataViewModel()
        {

        }

        private UserMasterData _masterData;
        public UserMasterData MasterData
        {
            get { return _masterData; }
            set
            {
                if (Set(ref _masterData, value))
                {
                    Gender = value.Gender;
                    Name = value.Name;
                    Surname = value.Surname;
                    Street = value.Street;
                    ZIP = value.Zip;
                    City = value.City;
                    Email = value.Email;
                    Phone = value.Phone;
                    Mobile = value.Mobile;

                    if (value.Birthdate != null)
                    {
                        Birthdate = (DateTimeOffset)value.Birthdate;
                    }
                }

                // Update bindings
                RaisePropertyChanged("");
            }
        }

        private Gender _gender;
        public Gender Gender
        {
            get { return _gender; }
            set { Set(ref _gender, value); }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set { Set(ref _surname, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private string _street;
        public string Street
        {
            get { return _street; }
            set { Set(ref _street, value); }
        }

        private string _zip;
        public string ZIP
        {
            get { return _zip; }
            set { Set(ref _zip, value); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { Set(ref _city, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { Set(ref _email, value); }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { Set(ref _phone, value); }
        }

        private string _mobile;
        public string Mobile
        {
            get { return _mobile; }
            set { Set(ref _mobile, value); }
        }

        private DateTimeOffset _birthdate;
        public DateTimeOffset Birthdate
        {
            get { return (!IsBirthdateSet || _birthdate.Year >= DateTimeOffset.Now.Year) ? DateTimeOffset.Now : _birthdate; }
            set
            {
                if (value.Year >= DateTimeOffset.Now.Year)
                {
                    IsBirthdateSet = false;
                    Set(ref _birthdate, value);
                    return;
                }

                IsBirthdateSet = true;
                Set(ref _birthdate, value);
            }
        }

        public bool IsBirthdateDisplayed
        {
            get { return IsBirthdateSet || IsUserInputEnabled; }
        }

        private bool _isUserInputEnabled;
        public bool IsUserInputEnabled
        {
            get { return _isUserInputEnabled; }
            set {
                Set(ref _isUserInputEnabled, value);
                RaisePropertyChanged(() => IsBirthdateDisplayed);
            }
        }

        private bool _isBirthdateSet;
        public bool IsBirthdateSet
        {
            get { return _isBirthdateSet; }
            set {
                Set(ref _isBirthdateSet, value);
                RaisePropertyChanged(() => IsBirthdateDisplayed);
            }
        }

        private RelayCommand _editButtonCommand;
        public RelayCommand EditButtonCommand => _editButtonCommand ?? (_editButtonCommand = new RelayCommand(() =>
        {
            MasterData = UserMasterData.MasterData;
            IsUserInputEnabled = true;

        }));

        private RelayCommand _cancelButtonCommand;
        public RelayCommand CancelButtonCommand => _cancelButtonCommand ?? (_cancelButtonCommand = new RelayCommand(async () =>
        {
            if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.CancelButtonPressedConfirmationText, AppResources.YesButtonText, AppResources.NoButtonText))
            {
                IsUserInputEnabled = false;
                UserMasterData.MasterData = MasterData;
            }

        }));

        private RelayCommand _saveButtonCommand;
        public RelayCommand SaveButtonCommand => _saveButtonCommand ?? (_saveButtonCommand = new RelayCommand(async () =>
        {
            bool saveInput = true;

            if (Birthdate.Year >= DateTime.Now.Year)
            {   
                if (!await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.MasterDataViewModelBirthdateNotValidText, AppResources.YesButtonText, AppResources.NoButtonText))
                {
                    saveInput = false;
                    IsBirthdateSet = true;
                };
            }
            if (saveInput) {
                IsUserInputEnabled = false;
                RaisePropertyChanged("");
            }
            

        }));

        private RelayCommand _userMasterDataPageDeleteAllMasterDataButtonCommand;
        public RelayCommand UserMasterDataPageDeleteAllMasterDataButtonCommand => _userMasterDataPageDeleteAllMasterDataButtonCommand ?? (_userMasterDataPageDeleteAllMasterDataButtonCommand = new RelayCommand(async () =>
        {
            if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.UserMasterDataPageDelteAllPersonalDataText, AppResources.YesButtonText, AppResources.NoButtonText))
            {
                Gender = Gender.GenderFree;
                Name = null;
                Surname = null;
                Street = null;
                ZIP = null;
                City = null;
                Email = null;
                Phone = null;
                Mobile = null;
                Birthdate = DateTime.Now;

            }
            RaisePropertyChanged("");

        }));

    }
}
