using BFH_USZ_PICC.Models;
using BFH_USZ_PICC.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BFH_USZ_PICC.Models.PICC;

namespace BFH_USZ_PICC.ViewModels
{
    public class PICCDetailViewModel : ViewModelBase
    {

        private PICC _displayingEntry;
        public PICC DisplayingEntry
        {
            get { return _displayingEntry; }
            set
            {
                if (Set(ref _displayingEntry, value))
                {
                    PiccName = value.PICCModel.PICCName;
                    FrenchDiameter = value.PICCModel.FrenchDiameter;
                    Lumen = value.PICCModel.Lumen;
                    ImageSource = value.PICCModel.PictureUri;

                    City = value.InsertCity;
                    InsertCountry = value.InsertCountry;
                    InsertDate = value.InsertDate;
                    IsRemovalDateSet = value.IsNotActiveAnymore;
                    RemovalDate = value.RemovalDate;
                    PiccSide = value.InsertSide;
                    PiccPosition = value.InsertPosition;

                }
                RaisePropertyChanged("");
            }
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

        private DateTime? _removalDate;
        public DateTime? RemovalDate
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

        private string _city;
        public string City
        {
            get { return _city; }
            set { Set(ref _city, value); }
        }

        private bool _isCountrySet;
        public bool IsCountrySet
        {
            get { return _isCountrySet; }
            set
            {
                if (!value)
                {
                    City = null;
                }
                Set(ref _isCountrySet, value);
            }
        }

        private bool _isVisibleOrEnabled;
        public bool IsVisibleOrEnabled
        {
            get { return _isVisibleOrEnabled; }
            set { Set(ref _isVisibleOrEnabled, value); }
        }


        private RelayCommand _editButtonCommand;
        public RelayCommand EditButtonCommand => _editButtonCommand ?? (_editButtonCommand = new RelayCommand(() =>
        {
            IsVisibleOrEnabled = true;
        }));

        private RelayCommand _saveButtonCommand;
        public RelayCommand SaveButtonCommand => _saveButtonCommand ?? (_saveButtonCommand = new RelayCommand(async() =>
        {
            PICCModel model = new PICCModel(PiccName, DisplayingEntry.PICCModel.GuideWireLenght, Lumen, FrenchDiameter, DisplayingEntry.PICCModel.Gauge, DisplayingEntry.PICCModel.GNDMCode, DisplayingEntry.PICCModel.Barcode, DisplayingEntry.PICCModel.PictureUri);
            PICC.CurrentPICC = new PICC(model, InsertDate, InsertCountry, City, PiccSide, PiccPosition);

            await((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
        }));

        private RelayCommand _cancelButtonCommand;
        public RelayCommand CancelButtonCommand => _cancelButtonCommand ?? (_cancelButtonCommand = new RelayCommand(async () =>
        {
            if (await ((Shell)Application.Current.MainPage).DisplayAlert("Warnung!", "Wollen Sie die Eingabe wirklich abbrechen?", "Ja", "Nein"))
            {
                await ((Shell)Application.Current.MainPage).Detail.Navigation.PopAsync();
            }
        }));
    }

}
