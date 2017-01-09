using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Resx;
using BFH_USZ_PICC.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static BFH_USZ_PICC.Models.PICC;

namespace BFH_USZ_PICC.ViewModels
{
    public class PICCDetailViewModel : ViewModelBase
    {
        private ILocalUserDataService _dataService;
        private PICC _displayingPICC;

        public PICCDetailViewModel()
        {
            // Getting the dataservice
            _dataService = ServiceLocator.Current.GetInstance<ILocalUserDataService>();
        }

        #region navigation events

        public async override Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            if (parameter is List<object> && ((List<object>)parameter).Count > 0)
            {
                var param = ((List<object>)parameter).First();
                if (param.GetType() == typeof(PICCModel))
                {
                    _displayingPICC = new PICC() { PICCModel = (PICCModel)param, InsertDate = DateTimeOffset.Now.Date.ToLocalTime() };
                    StartEditing();
                }
                else if (param.GetType() == typeof(string))
                {
                    _displayingPICC = await _dataService.GetPICCAsync((string)param);
                }
            }

            LoadFromModel();
        }

        public override Task OnNavigatedFromAsync()
        {
            EndEditing();

            // Return "fake task" since Task.CompletedTask is not supported in this PCL
            return Task.FromResult(false);
        }

        #endregion

        #region private methods

        private void StartEditing()
        {
            IsUserInputEnabled = true;
        }

        private void EndEditing()
        {
            IsUserInputEnabled = false;
        }

        private void LoadFromModel()
        {
            if (_displayingPICC != null)
            {
                PiccName = _displayingPICC.PICCModel.PICCName;
                FrenchDiameter = _displayingPICC.PICCModel.FrenchDiameter;
                Lumen = _displayingPICC.PICCModel.Lumen;
                ImageSource = _displayingPICC.PICCModel.PictureUri;
                InsertCity = _displayingPICC.InsertCity;
                InsertCountry = _displayingPICC.InsertCountry;
                InsertDate = (_displayingPICC.InsertDate).Date;
                PiccSide = _displayingPICC.InsertSide;
                PiccPosition = _displayingPICC.InsertPosition;

                if (_displayingPICC?.RemovalDate == null)
                {
                    RemovalDate = DateTime.Now;
                    IsRemovalDateSet = false;
                }
                else
                {
                    RemovalDate = ((DateTimeOffset)_displayingPICC.RemovalDate).Date;
                    IsRemovalDateSet = true;
                }
            }

            // Actually, this shoudln't be needed... but because of some weird timing, it is.
            RaisePropertyChanged("");
        }

        private async Task SaveToModel()
        {
            _displayingPICC.PICCModel.PICCName = PiccName;
            _displayingPICC.PICCModel.Lumen = Lumen;
            _displayingPICC.PICCModel.FrenchDiameter = FrenchDiameter;
            _displayingPICC.InsertDate = InsertDate.Date.ToLocalTime();
            _displayingPICC.InsertCountry = InsertCountry;
            _displayingPICC.InsertCity = InsertCity;
            _displayingPICC.InsertSide = PiccSide;
            _displayingPICC.InsertPosition = PiccPosition;

            // Save to DB
            await _dataService.SaveCurrentPICCAsync(_displayingPICC);
        }

        #endregion

        #region public properties

        /// <summary>
        /// Checks if parameters should be editable or not
        /// </summary>
        private bool _isUserInputEnabled;
        public bool IsUserInputEnabled
        {
            get { return _isUserInputEnabled; }
            set { Set(ref _isUserInputEnabled, value); }
        }

        public string PageTitle
        {
            get { return "TEST"; }
        }

        private string _piccName;
        public string PiccName
        {
            get { return _piccName; }
            set { Set(ref _piccName, value); }

        }

        public bool IsImageSet { get { return ImageSource != null; } }

        public string _imageSource;
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
               if( Set(ref _imageSource, value))
                {
                    RaisePropertyChanged(() => IsImageSet);
                }
            }
        }

        private double _frenchDiameter;
        public double FrenchDiameter
        {
            get { return _frenchDiameter; }
            set { Set(ref _frenchDiameter, value); }

        }

        private int _lumen;
        public int Lumen
        {
            get { return _lumen; }
            set { Set(ref _lumen, value); }
        }

        private DateTime _insertDate;
        public DateTime InsertDate
        {
            get
            { return _insertDate; }

            set { Set(ref _insertDate, value); }
        }
        
        private DateTime _removalDate;
        public DateTime RemovalDate
        {
            get
            {
                if (_removalDate == null)
                {
                    return DateTime.Now;
                }
                return _removalDate;

            }
            set { Set(ref _removalDate, value); }
        }

        private bool _isRemovalDateSet;
        public bool IsRemovalDateSet
        {
            get { return _isRemovalDateSet; }
            set { Set(ref _isRemovalDateSet, value); }
        }

        private PICCInsertPosition _piccPosition;
        public PICCInsertPosition PiccPosition
        {
            get { return _piccPosition; }
            set { Set(ref _piccPosition, value); }
        }

        private PICCInsertSide _piccSide;
        public PICCInsertSide PiccSide
        {
            get { return _piccSide; }
            set
            {
                Set(ref _piccSide, value);
            }
        }

        public bool IsCountrySet { get { return InsertCountry != PICCInsertCountry.Undefined; } }
        private PICCInsertCountry _insertCountry;
        public PICCInsertCountry InsertCountry
        {

            get { return _insertCountry; }
            set
            {
                if (Set(ref _insertCountry, value))
                {
                    RaisePropertyChanged(() => IsCountrySet);
                }
            }
        }

        private string _insertCity;
        public string InsertCity
        {
            get { return _insertCity; }
            set { Set(ref _insertCity, value); }
        }

        #endregion

        #region RelayCommands

        private RelayCommand _editButtonCommand;
        public RelayCommand EditButtonCommand => _editButtonCommand ?? (_editButtonCommand = new RelayCommand(() =>
        {
            IsUserInputEnabled = true;
        }));

        private RelayCommand _saveButtonCommand;
        public RelayCommand SaveButtonCommand => _saveButtonCommand ?? (_saveButtonCommand = new RelayCommand(async () =>
        {
            await SaveToModel();
            await ((Shell)Application.Current.MainPage).Detail.Navigation.PopToRootAsync();
        }));

        private RelayCommand _cancelButtonCommand;
        public RelayCommand CancelButtonCommand => _cancelButtonCommand ?? (_cancelButtonCommand = new RelayCommand(async () =>
        {
            if (await ((Shell)Application.Current.MainPage).DisplayAlert(AppResources.WarningText, AppResources.CancelButtonPressedConfirmationText, AppResources.YesButtonText, AppResources.NoButtonText))
            {
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopToRootAsync();
            }
        }));

        private RelayCommand _piccRemoveButtonCommand;
        public RelayCommand PiccRemoveButtonCommand => _piccRemoveButtonCommand ?? (_piccRemoveButtonCommand = new RelayCommand(async () =>
        {
            if (await ((Shell)Application.Current.MainPage).DisplayAlert(AppResources.WarningText, AppResources.PICCDetailViewModelSetPICCInactiveText, AppResources.YesButtonText, AppResources.NoButtonText))
            {
                // Currently there is no possibilty to show the user a popup where he/she can select a date. 
                // For the moment, in case of removal, todays date will be saved on DB
                _displayingPICC.RemovalDate = DateTimeOffset.Now.Date.ToLocalTime();

                await SaveToModel();

                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }));

        #endregion
    }
}

