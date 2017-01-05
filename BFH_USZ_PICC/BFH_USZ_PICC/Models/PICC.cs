using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
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

    public class PICC
    {
        public static PICC CurrentPICC;

        public static ObservableCollection<PICC> PreviousPICC = new ObservableCollection<PICC>();


        [SQLite.PrimaryKey]
        public string ID { get; set; }
        public PICCModel PICCModel { get; set; }
        public DateTimeOffset InsertDate { get; set; }
        public DateTimeOffset? RemovalDate { get; set; }
        public PICCInsertCountry InsertCountry { get; set; }
        public string InsertCity { get; set; }
        public PICCInsertSide InsertSide { get; set; }
        public PICCInsertPosition InsertPosition { get; set; }

        public PICC() { }

        public PICC(PICCRO realmObject)
        {
            ID = realmObject.ID;
            PICCModel = new PICCModel(realmObject.PICCModelRO);
            InsertDate = realmObject.InsertDate;
            RemovalDate = realmObject.RemovalDate;
            InsertCountry = (PICCInsertCountry)realmObject.InsertCountry;
            InsertCity = realmObject.InsertCity;
            InsertSide = (PICCInsertSide)realmObject.InsertSide;
            InsertPosition = (PICCInsertPosition)realmObject.InsertPosition;

            foreach (var existingPICCMOdel in PICCModel.AllAvailablePICCModels())
            {
                if (PICCModel.Barcode == existingPICCMOdel.Barcode)
                {
                    PICCModel = existingPICCMOdel;
                }
            }
        }
    }

    public class PICCRO : RealmObject
    {
        [Realms.PrimaryKey]
        public string ID { get; set; }
        public PICCModelRO PICCModelRO { get; set; }
        public DateTimeOffset InsertDate { get; set; }
        public DateTimeOffset? RemovalDate { get; set; }
        public int InsertCountry { get; set; }
        public string InsertCity { get; set; }
        public int InsertSide { get; set; }
        public int InsertPosition { get; set; }

        public void LoadDataFromModelObject(PICC modelObject)
        {
            ID = modelObject.ID;
            InsertDate = modelObject.InsertDate;
            RemovalDate = modelObject.RemovalDate;
            InsertCountry = (int)modelObject.InsertCountry;
            InsertCity = modelObject.InsertCity;
            InsertSide = (int)modelObject.InsertSide;
            InsertPosition = (int)modelObject.InsertPosition;
            PICCModelRO = new PICCModelRO();
            PICCModelRO.LoadDataFromModelObject(modelObject.PICCModel);

        }
    }
}
