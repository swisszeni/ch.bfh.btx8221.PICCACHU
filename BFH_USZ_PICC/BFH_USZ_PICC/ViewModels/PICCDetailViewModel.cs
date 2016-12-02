using BFH_USZ_PICC.Models;
using GalaSoft.MvvmLight;
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
                    // Update all bindings
                    RaisePropertyChanged("");
                }
            }
        }

        /// <summary>
        /// Returns the binded name or sets a new name to the related object
        /// </summary>
        private string _piccName;
        public string PiccName
        {
            get { return _piccName; }
            set
            {
                Set(ref _piccName, value);
            }

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
                Set(ref _imageSource, value);
            }

        }

        /// <summary>
        /// Returns the binded size or sets a new size to the related object
        /// </summary>
        private double _frenchDiameter;
        public double FrenchDiameter
        {
            get { return _frenchDiameter; }
            set
            {
                Set(ref _frenchDiameter, value);
            }

        }

        private int _lumen;
        public int Lumen
        {
            get { return _lumen; }
            set
            {
                Set(ref _lumen, value);
            }
        }

        /// <summary>
        /// Returns the binded date or sets a new date to the related object
        /// </summary>

        private DateTime _insertDate;
        public DateTime InsertDate
        {
            get
            { return _insertDate; }

            set
            {
                Set(ref _insertDate, value);
            }
        }

        /// <summary>
        /// Returns the binded expiration date or sets a new date to the related object
        /// </summary>

        private DateTime _removalDate;
        public DateTime RemovalDate
        {
            get
            {
                return _removalDate;
            }


            set
            {
                Set(ref _removalDate, value);
            }
        }


        private bool _isRemovalDateSet;
        public bool IsRemovalDateSet
        {
            get { return _isRemovalDateSet; }
            set
            {
                Set(ref _isRemovalDateSet, value);
            }
        }

        /// <summary>
        /// Returns the binded picc position or sets a new picc position to the related object
        /// </summary>
        private PICCInsertPosition _piccPosition;
        public PICCInsertPosition PiccPosition
        {
            get { return _piccPosition; }
            set
            {
                Set(ref _piccPosition, value);
            }
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
                Set(ref _insertCountry, value);

                if (value == PICCInsertCountry.Undefined)
                {
                    City = null;
                }
            }

        }

        /// <summary>
        /// Returns the binded city if "Ausland" or "Switzerland" is selected as country. Sets a new city to the related object.
        /// </summary>

        private string _city;
        public string City
        {
            get
            {
                if (DisplayingEntry.InsertCountry != PICCInsertCountry.Undefined)
                {
                    return _city;
                }
                return null;
            }

            set
            {

                Set(ref _city, value);
            }
        }
    }
}
