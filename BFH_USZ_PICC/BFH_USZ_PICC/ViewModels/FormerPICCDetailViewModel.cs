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
using BFH_USZ_PICC.Utilitys;

namespace BFH_USZ_PICC.ViewModels
{
    public class FormerPICCDetailViewModel : ViewModelBase
    {
        private ILocalUserDataService _dataService;
        private PICC _displayingPICC;

        public FormerPICCDetailViewModel()
        {
            // Getting the dataservice
            _dataService = ServiceLocator.Current.GetInstance<ILocalUserDataService>();
        }

        #region navigation events

        public async override Task OnNavigatedToAsync(NavigationMode mode)
        {
            // TODO: FIX
            //if (parameter is List<object> && ((List<object>)parameter).Count > 0)
            //{
            //    var param = ((List<object>)parameter).First();
            //    _displayingPICC = await _dataService.GetPICCAsync((string)param);

            //}

            LoadFromModel();
        }
        
        #endregion

        #region private methods

        private void LoadFromModel()
        {
            if (_displayingPICC != null)
            {
                PiccName = _displayingPICC.PICCModel.PICCName;
                FrenchDiameter = _displayingPICC.PICCModel.FrenchDiameter;
                Lumen = _displayingPICC.PICCModel.Lumen;
                ImageSource = _displayingPICC.PICCModel.PictureUri;
                InsertDate = (_displayingPICC.InsertDate).Date;
                InsertCity = _displayingPICC.InsertCity;
                
                SetCountry(_displayingPICC.InsertCountry);
                SetSide(_displayingPICC.InsertSide);
                SetPosition(_displayingPICC.InsertPosition);        
                
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

        private void SetCountry(PICCInsertCountry country)
        {
            switch (country)
            {
                case PICCInsertCountry.Undefined:
                    InsertCountry = AppResources.PICCDetailPagePickerNotDefinedText;
                    return;
                case PICCInsertCountry.Switzerland:
                    InsertCountry = AppResources.PICCDetailPagePickerCountrySwitzerlandText;
                    return;
                case PICCInsertCountry.Abroad:
                    InsertCountry = AppResources.PICCDetailPagePickerCountryAbroadText;
                    return;
            }
        }

        private void SetSide(PICCInsertSide side)
        {
            switch (side)
            {
                case PICCInsertSide.Undefined:
                    PiccSide = AppResources.PICCDetailPagePickerNotDefinedText;
                    return;
                case PICCInsertSide.Left:
                    PiccSide = AppResources.PICCDetailPagePickerSideLeftText;
                    return;
                case PICCInsertSide.Right:
                    PiccSide = AppResources.PICCDetailPagePickerSideRightText;
                    return;
            }

        }

        private void SetPosition(PICCInsertPosition pos)
        {
            switch (pos)
            {
                case PICCInsertPosition.Undefined:
                    PiccPosition = AppResources.PICCDetailPagePickerNotDefinedText;
                    return;
                case PICCInsertPosition.BelowElbow:
                    PiccPosition = AppResources.PICCDetailPagePickerPositionBelowElbowText;
                    return;
                case PICCInsertPosition.AboveElbow:
                    PiccPosition = AppResources.PICCDetailPagePickerPositionAboveElbowText;
                    return;
            }

        }
        #endregion

        #region public properties
        
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
                if (Set(ref _imageSource, value))
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

        private string _piccPosition;
        public string PiccPosition
        {
            get { return _piccPosition; }
            set { Set(ref _piccPosition, value); }
        }

        private string _piccSide;
        public string PiccSide
        {
            get { return _piccSide; }
            set
            {
                Set(ref _piccSide, value);
            }
        }

        public bool IsCountrySet { get { return InsertCountry != AppResources.PICCDetailPagePickerNotDefinedText; } }
        private string _insertCountry;
        public string InsertCountry
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

        #region relay commands

        private RelayCommand _deleteButtonCommand;
        public RelayCommand DeleteButtonCommand => _deleteButtonCommand ?? (_deleteButtonCommand = new RelayCommand(async () =>
        {
            if (await DisplayAlert(AppResources.WarningText, AppResources.MyPICCPageDeletePICCWarningText, AppResources.YesButtonText, AppResources.NoButtonText))
            {
                await _dataService.DeltePICCAsync(_displayingPICC);
                await NavigationService.NavigateBackToRootAsync();
            }
        }));

        #endregion

    }
}

