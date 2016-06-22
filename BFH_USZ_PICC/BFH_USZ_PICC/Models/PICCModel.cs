using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public class PICCModel
    {
        private static List<PICCModel> modelList;
        public static List<PICCModel> AllModels()
        {
            if (modelList == null)
            {
                modelList = new List<PICCModel>();
                modelList.Add(new PICCModel("Einlumiger Picc", 3.4, "EinlumigerPICC.PNG", ""));
                modelList.Add(new PICCModel("Zweilumiger Picc", 3.9, "DoppellumigerPICC.PNG", "9783468201226"));
                modelList.Add(new PICCModel("Dreilumiger Picc", 4.4, null, ""));

            }

            return modelList;
        }

        public string PICCName { get; set; }
        public double FrenchSize { get; set; }
        public string PictureUri { get; set; }
        public string Barcode { get; set; }

        public PICCModel(string piccName, double frenchSize, string pictureUri, string barcode)
        {
            this.PICCName = piccName;
            this.FrenchSize = frenchSize;
            this.PictureUri = pictureUri;
            this.Barcode = barcode;
        }
    }
}
