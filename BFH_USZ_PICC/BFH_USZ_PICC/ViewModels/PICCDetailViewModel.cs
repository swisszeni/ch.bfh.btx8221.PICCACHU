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
        private PICC picc;

        public PICCDetailViewModel(PICC picc)
        {
            this.picc = picc;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Checks if a binded property has been changed and fires the event
        /// </summary>
        /// <param name="propertyname"></param>
        protected internal void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        /// <summary>
        /// Returns the binded name or sets a new name to the related object
        /// </summary>
        public string PiccName
        {
            get { return picc.PICCModel.PICCName; }
            set
            {
                if (picc.PICCModel.PICCName != value)
                {
                    picc.PICCModel.PICCName = value;
                    OnPropertyChanged("PiccName");
                }
            }
        }

        /// <summary>
        /// Returns the image string for the current picc or sets a new image string to the related object
        /// </summary>
        public string ImageSource
        {
            get { return picc.PICCModel.PictureUri; }
            set
            {
                if (picc.PICCModel.PictureUri != value)
                {
                    picc.PICCModel.PictureUri = value;
                    OnPropertyChanged("ImageSource");
                }
            }
        }

        /// <summary>
        /// Returns the binded size or sets a new size to the related object
        /// </summary>
        public double FrenchSize
        {
            get { return picc.PICCModel.FrenchSize; }
            set
            {
                if (picc.PICCModel.FrenchSize != value)
                {
                    picc.PICCModel.FrenchSize = value;
                    OnPropertyChanged("FrenchSize");
                }
            }
        }

        /// <summary>
        /// Returns the binded date or sets a new date to the related object
        /// </summary>
        public DateTime InsertDate
        {
            get { return picc.InsertDate; }
            set
            {
                if (picc.InsertDate != value)
                {
                    picc.InsertDate = value;
                    OnPropertyChanged("InsertDate");
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
                if (picc.RemovalDate != null)
                {
                    return picc.RemovalDate;
                }

                return DateTime.Today;
            }
            set
            {
                if (picc.RemovalDate != value)
                {
                    picc.RemovalDate = value;
                    OnPropertyChanged("RemovalDate");
                }
            }
        }

        public bool IsRemovalDateSet
        {
            get { return picc.IsNotActiveAnymore; }
            set
            {
                if (picc.IsNotActiveAnymore != value)
                {
                    picc.IsNotActiveAnymore = value;
                    OnPropertyChanged("IsRemovalDateSet");
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
                return picc.InsertPosition;
            }

            set
            {
                if (picc.InsertPosition != value)
                {
                    picc.InsertPosition = value;
                    OnPropertyChanged("PiccPosition");
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
                return picc.InsertSide;
            }

            set
            {
                if (picc.InsertSide != value)
                {
                    picc.InsertSide = value;
                    OnPropertyChanged("PiccSide");
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
                return picc.InsertCountry;
            }

            set
            {
                if (picc.InsertCountry != value)
                {
                    picc.InsertCountry = value;
                    OnPropertyChanged("InsertCountry");
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
                if (picc.InsertCountry != PICCInsertCountry.Undefined)
                {
                    return picc.InsertCity;
                }
                return " ";
            }

            set
            {
                if (picc.InsertCity != value && picc.InsertCountry != PICCInsertCountry.Undefined)
                {
                    picc.InsertCity = value;
                    OnPropertyChanged("City");
                }
            }
        }
    }
}
