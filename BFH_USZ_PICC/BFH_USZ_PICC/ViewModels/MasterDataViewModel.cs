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
        private UserMasterData _masterData;

        private Salutation _salutation = UserMasterData.MasterData.Salutation;
        public Salutation Salutation
        {
            get { return _salutation; }
            set { Set(ref _salutation, value); }
        }

        private string _surname = UserMasterData.MasterData.Surname;
        public string Surname
        {
            get { return _surname; }
            set { Set(ref _surname, value); }
        }

        private string _name = UserMasterData.MasterData.Name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private string _street = UserMasterData.MasterData.Street;
        public string Street
        {
            get { return _street; }
            set { Set(ref _street, value); }
        }

        private string _zip = UserMasterData.MasterData.Zip;
        public string ZIP
        {
            get { return _zip; }
            set { Set(ref _zip, value); }
        }

        private string _city = UserMasterData.MasterData.City;
        public string City
        {
            get { return _city; }
            set { Set(ref _city, value); }
        }

        private string _email = UserMasterData.MasterData.Email;
        public string Email
        {
            get { return _email; }
            set { Set(ref _email, value); }
        }

        private string _phone = UserMasterData.MasterData.Phone;
        public string Phone
        {
            get { return _phone; }
            set { Set(ref _phone, value); }
        }

        private string _mobile = UserMasterData.MasterData.Mobile;
        public string Mobile
        {
            get { return _mobile; }
            set { Set(ref _mobile, value); }
        }

        private DateTimeOffset? _birthdate = UserMasterData.MasterData.Birthdate;
        public DateTimeOffset? Birthdate
        {
            get
            {
                if (_birthdate == null || _birthdate.Value.Date == DateTimeOffset.Now.Date)
                {
                    IsBirthdateSet = false;
                    return DateTime.Today;
                }
                else
                {
                    IsBirthdateSet = true;
                    return _birthdate;
                }
            }
            set
            {
                if (value == null || value.Value.Date == DateTimeOffset.Now.Date)
                {
                    IsBirthdateSet = false;
                    Set(ref _birthdate, null);
                    return;
                }

                IsBirthdateSet = true;
                Set(ref _birthdate, value);


            }
        }

        private bool _enableUserInput;
        public bool EnableUserInput
        {
            get { return _enableUserInput; }
            set
            {
                if (value)
                {
                    IsBirthdateSet = true;
                }
                Set(ref _enableUserInput, value);
            }

        }

        private bool _isBirthdateSet;
        public bool IsBirthdateSet
        {
            get { return _isBirthdateSet; }
            set { Set(ref _isBirthdateSet, value); }

        }

        private RelayCommand _editButtonCommand;
        public RelayCommand EditButtonCommand => _editButtonCommand ?? (_editButtonCommand = new RelayCommand(() =>
        {
            EnableUserInput = true;
            _masterData = UserMasterData.MasterData;

        }));

        private RelayCommand _cancelButtonCommand;
        public RelayCommand CancelButtonCommand => _cancelButtonCommand ?? (_cancelButtonCommand = new RelayCommand(async () =>
        {
            if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.UserMasterDataPageDelteAllPersonalDataText, AppResources.YesButtonText, AppResources.NoButtonText))
            {
                EnableUserInput = false;
                UserMasterData.MasterData = _masterData;
            }

        }));

        private RelayCommand _saveButtonCommand;
        public RelayCommand SaveButtonCommand => _saveButtonCommand ?? (_saveButtonCommand = new RelayCommand(() =>
        {
            EnableUserInput = false;
            RaisePropertyChanged("");

        }));

        private RelayCommand _userMasterDataPageDeleteAllMasterDataButtonCommand;
        public RelayCommand UserMasterDataPageDeleteAllMasterDataButtonCommand => _userMasterDataPageDeleteAllMasterDataButtonCommand ?? (_userMasterDataPageDeleteAllMasterDataButtonCommand = new RelayCommand(async () =>
        {
            if (await Application.Current.MainPage.DisplayAlert(AppResources.WarningText, AppResources.UserMasterDataPageDelteAllPersonalDataText, AppResources.YesButtonText, AppResources.NoButtonText))
            {
                UserMasterData.MasterData = null;
                RaisePropertyChanged("");
            }

        }));

    }
}
