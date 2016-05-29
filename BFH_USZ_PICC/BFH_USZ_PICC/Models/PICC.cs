using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public class PICC
    {
        public enum PICCInsertPosition
        {
            Undefined,
            BelowElbow,
            AboveElbow
        }

        public enum PICCInsertSide
        {
            Undefined,
            Left,
            Right
        }

        public enum PICCInsertCountry
        {
            Undefined,
            Switzerland,
            Abroad
        }

        public PICCModel PICCModel { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? RemovalDate { get; set; }
        public bool IsNotActiveAnymore { get; set; }
        public PICCInsertCountry InsertCountry { get; set; }
        public string InsertCity { get; set; }
        public PICCInsertSide InsertSide { get; set; }
        public PICCInsertPosition InsertPosition { get; set; }

        public PICC(PICCModel model, DateTime insertDate, PICCInsertCountry insertCountry, string insertCity, PICCInsertSide piccSide, PICCInsertPosition piccPosition)

        {
            this.PICCModel = model;
            this.InsertDate = insertDate;
            this.InsertCity = insertCity;
            this.InsertCountry = insertCountry;
            this.InsertSide = piccSide;
            this.InsertPosition = piccPosition;
        }
    }
}
