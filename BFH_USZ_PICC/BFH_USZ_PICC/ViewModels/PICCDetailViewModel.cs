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
        public PICCDetailViewModel(PICC picc)
        {
            DisplayingEntry = picc;
        }

        private PICC _displayingEntry;
        public PICC DisplayingEntry
        {
            get { return _displayingEntry; }
            set
            {
                if(Set(ref _displayingEntry, value))
                {
                    // Update all bindings
                    RaisePropertyChanged("");
                }
            }
        }

        /// <summary>
        /// Returns the binded name or sets a new name to the related object
        /// </summary>
        public string PiccName
        {
            get { return DisplayingEntry.PICCModel.PICCName; }
            set
            {
                if (DisplayingEntry.PICCModel.PICCName != value)
                {
                    DisplayingEntry.PICCModel.PICCName = value;
                    RaisePropertyChanged("PiccName");
                }
            }
        }

        /// <summary>
        /// Returns the image string for the current picc or sets a new image string to the related object
        /// </summary>
        public string ImageSource
        {
            get { return DisplayingEntry.PICCModel.PictureUri; }
            set
            {
                if (DisplayingEntry.PICCModel.PictureUri != value)
                {
                    DisplayingEntry.PICCModel.PictureUri = value;
                    RaisePropertyChanged("ImageSource");
                }
            }
        }

        /// <summary>
        /// Returns the binded size or sets a new size to the related object
        /// </summary>
        public double FrenchSize
        {
            get { return DisplayingEntry.PICCModel.FrenchSize; }
            set
            {
                if (DisplayingEntry.PICCModel.FrenchSize != value)
                {
                    DisplayingEntry.PICCModel.FrenchSize = value;
                    RaisePropertyChanged("FrenchSize");
                }
            }
        }

        /// <summary>
        /// Returns the binded date or sets a new date to the related object
        /// </summary>
        public DateTime InsertDate
        {
            get { return DisplayingEntry.InsertDate; }
            set
            {
                if (DisplayingEntry.InsertDate != value)
                {
                    DisplayingEntry.InsertDate = value;
                    RaisePropertyChanged("InsertDate");
                }
            }
        }

        /// <summary>
        /// Returns the binded expiration date or sets a new date to the related object
        /// </summary>
        public DateTime? RemovalDate
        {
            get
            {
                if (DisplayingEntry.RemovalDate != null)
                {
                    return DisplayingEntry.RemovalDate;
                }

                return DateTime.Today;
            }
            set
            {
                if (DisplayingEntry.RemovalDate != value)
                {
                    DisplayingEntry.RemovalDate = value;
                    RaisePropertyChanged("RemovalDate");
                }
            }
        }

        public bool IsRemovalDateSet
        {
            get { return DisplayingEntry.IsNotActiveAnymore; }
            set
            {
                if (DisplayingEntry.IsNotActiveAnymore != value)
                {
                    DisplayingEntry.IsNotActiveAnymore = value;
                    RaisePropertyChanged("IsRemovalDateSet");
                }
            }
        }

        /// <summary>
        /// Returns the binded picc position or sets a new picc position to the related object
        /// </summary>
        public PICCInsertPosition PiccPosition
        {
            get
            {
                return DisplayingEntry.InsertPosition;
            }

            set
            {
                if (DisplayingEntry.InsertPosition != value)
                {
                    DisplayingEntry.InsertPosition = value;
                    RaisePropertyChanged("PiccPosition");
                }
            }
        }

        /// <summary>
        /// Returns the binded picc side or sets a new picc side to the related object
        /// </summary>
        public PICCInsertSide PiccSide
        {
            get
            {
                return DisplayingEntry.InsertSide;
            }

            set
            {
                if (DisplayingEntry.InsertSide != value)
                {
                    DisplayingEntry.InsertSide = value;
                    RaisePropertyChanged("PiccSide");
                }
            }
        }

        /// <summary>
        /// Returns the binded country or sets a new country to the related object
        /// </summary>
        public PICCInsertCountry InsertCountry
        {
            get
            {
                return DisplayingEntry.InsertCountry;
            }

            set
            {
                if (DisplayingEntry.InsertCountry != value)
                {
                    DisplayingEntry.InsertCountry = value;
                    RaisePropertyChanged("InsertCountry");
                }
            }

        }

        /// <summary>
        /// Returns the binded city if "Ausland" or "Switzerland" is selected as country. Sets a new city to the related object.
        /// </summary>
        public string City
        {
            get
            {
                if (DisplayingEntry.InsertCountry != PICCInsertCountry.Undefined)
                {
                    return DisplayingEntry.InsertCity;
                }
                return " ";
            }

            set
            {
                if (DisplayingEntry.InsertCity != value && DisplayingEntry.InsertCountry != PICCInsertCountry.Undefined)
                {
                    DisplayingEntry.InsertCity = value;
                    RaisePropertyChanged("City");
                }
            }
        }
    }
}
