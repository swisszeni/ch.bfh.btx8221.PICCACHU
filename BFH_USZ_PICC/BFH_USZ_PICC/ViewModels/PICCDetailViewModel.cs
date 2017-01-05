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

            PopulatePICCAsync();
        }

        private async void PopulatePICCAsync()
        {
            var currentPICC = await _dataService.GetCurrentPICCAsync();

            if (currentPICC != null)
            {
                _displayingPICC = currentPICC;
            }

            LoadFromModel();
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode)
        {
            if (parameter is List<object> && ((List<object>)parameter).Count > 0)
            {
                var param = ((List<object>)parameter).First();
                if (param.GetType() == typeof(PICCModel))
                {
                    _displayingPICC = new PICC() { PICCModel = (PICCModel)param, InsertDate = DateTimeOffset.Now.Date.ToLocalTime() };
                    IsUserInputEnabled = true;
                }
                else if (param.GetType() == typeof(PICC))
                {
                    _displayingPICC = (PICC)param;
                    IsUserInputEnabled = false;
                }
            }           

            LoadFromModel();

            // Return "fake task" since Task.CompletedTask is not supported in this PCL
            return Task.FromResult(false);
        }



        /// <summary>
        // Returns the binded name or sets a new name to the related object
        /// </summary>
        private string _piccName;
        public string PiccName
        {
            get { return _piccName; }
            set { Set(ref _piccName, value); }

        }

        /// <summary>
        /// Returns the image string for the current picc or sets a new image string to the related object
        /// </summary>
        public string _imageSource;
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                if (value == null)
                {
                    IsImageSet = false;
                }
                else { IsImageSet = true; }

                Set(ref _imageSource, value);

            }
        }

        public bool _isImageSet;
        public bool IsImageSet
        {
            get { return _isImageSet; }
            set { Set(ref _isImageSet, value); }

        }

        /// <summary>
        /// Returns the binded size or sets a new size to the related object
        /// </summary>
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

        /// <summary>
        /// Returns the binded date or sets a new date to the related object
        /// </summary>

        private DateTime _insertDate;
        public DateTime InsertDate
        {
            get
            { return _insertDate; }

            set { Set(ref _insertDate, value); }
        }

        /// <summary>
        /// Returns the binded expiration date or sets a new date to the related object
        /// </summary>

        private DateTimeOffset _removalDate;
        public DateTimeOffset RemovalDate
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

        /// <summary>
        /// Returns the binded picc position or sets a new picc position to the related object
        /// </summary>
        private PICCInsertPosition _piccPosition;
        public PICCInsertPosition PiccPosition
        {
            get { return _piccPosition; }
            set { Set(ref _piccPosition, value); }
        }

        /// <summary>
        /// Returns the binded picc side or sets a new picc side to the related object
        /// </summary>
        private PICCInsertSide _piccSide;
        public PICCInsertSide PiccSide
        {
            get { return _piccSide; }
            set
            {
                Set(ref _piccSide, value);
            }
        }

        /// <summary>
        /// Returns the binded country or sets a new country to the related object
        /// </summary>

        private PICCInsertCountry _insertCountry;
        public PICCInsertCountry InsertCountry
        {

            get { return _insertCountry; }
            set
            {
                if (value == PICCInsertCountry.Undefined)
                {
                    IsCountrySet = false;
                }
                else { IsCountrySet = true; }
                Set(ref _insertCountry, value);
            }
        }

        /// <summary>
        /// Returns the binded city if "Ausland" or "Switzerland" is selected as country. Sets a new city to the related object.
        /// </summary>

        private string _insertCity;
        public string InsertCity
        {
            get { return _insertCity; }
            set { Set(ref _insertCity, value); }
        }

        private bool _isCountrySet;
        public bool IsCountrySet
        {
            get { return _isCountrySet; }
            set
            {
                if (!value)
                {
                    InsertCity = null;
                }
                Set(ref _isCountrySet, value);
            }
        }

        /// <summary>
        /// Checks if parameters should be editable or not
        /// </summary>
        private bool _isUserInputEnabled;
        public bool IsUserInputEnabled
        {
            get { return _isUserInputEnabled; }
            set { Set(ref _isUserInputEnabled, value); }
        }

              private RelayCommand _editButtonCommand;
        public RelayCommand EditButtonCommand => _editButtonCommand ?? (_editButtonCommand = new RelayCommand(() =>
        {
            IsUserInputEnabled = true;
        }));

        private RelayCommand _saveButtonCommand;
        public RelayCommand SaveButtonCommand => _saveButtonCommand ?? (_saveButtonCommand = new RelayCommand(async () =>
        {
            //if (IsUserAddingANewPICC && _displayingPICC != null)
            //{
            //    CurrentPICC.RemovalDate = DateTime.Now;            

            //}
            SaveToModel();
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
                _displayingPICC.RemovalDate = DateTime.Now.Date.ToLocalTime();
                SaveToModel();
            
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }));

        private void SaveToModel()
        {
            PICCModel model = new PICCModel(PiccName, _displayingPICC.PICCModel.GuideWireLenght, Lumen, FrenchDiameter, _displayingPICC.PICCModel.Gauge, _displayingPICC.PICCModel.GNDMCode, _displayingPICC.PICCModel.Barcode, _displayingPICC.PICCModel.PictureUri);
            _displayingPICC.PICCModel = model;
            _displayingPICC.InsertDate = InsertDate;
            _displayingPICC.InsertCountry = InsertCountry;
            _displayingPICC.InsertCity = InsertCity;
            _displayingPICC.InsertSide = PiccSide;
            _displayingPICC.InsertPosition = PiccPosition;

            // Save to DB
            _dataService.SaveCurrentPICCAsync(_displayingPICC);

        }

        private void LoadFromModel()
        {
            if(_displayingPICC != null)
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
                    RemovalDate = DateTimeOffset.Now;
                    IsRemovalDateSet = false;
                }
                else
                {
                    RemovalDate = (DateTimeOffset)_displayingPICC.RemovalDate;
                    IsRemovalDateSet = true;
                }
            }

            RaisePropertyChanged("");
        }

    }
}

