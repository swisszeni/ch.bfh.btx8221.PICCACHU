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
                modelList.Add(new PICCModel("POWERPICC 4FR SL FT", 50, 1, 4, "18", "16615", "+H303617410805", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC 4FR SL", 135, 1, 4, "18", "16615", "+H303617433507", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC 4FR SL", 70, 1, 4, "18", "16615", "+H303617435509", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC 5FR SL", 135, 1, 5, "18", "16615", "+H303617533508", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC 5FR SL", 70, 1, 5, "18", "16615", "+H30361753550A", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC 5FR DL FT", 50, 2, 5, "18 / 18", "16615", "+H303627510807", "DoppellumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC 5FR DL", 135, 2, 5, "18 / 18", "16615", "+H303627533509", "DoppellumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC 5FR DL", 70, 2, 5, "18 / 18", "16615", "+H30362753550B", "DoppellumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC 6FR 3L", 50, 3, 6, "17 / 19 / 19", "16615", "+H303627611809", "DreilumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC 6FR TL", 135, 3, 6, "17 / 19 / 19", "16615", "+H30363863350C", "DreilumigerPICC.png"));
                modelList.Add(new PICCModel("PowerPICC Katheter 6F DL Intervent.Set m. 135cm GW", 135, 2, 6, "18 / 18", "16615", "+H30362763350A", "DoppellumigerPICC.png"));
                modelList.Add(new PICCModel("PowerPICC Katheter 6F TL Intervent.Set m. 70cm GW", 70, 3, 6, "17 / 19 / 19", "16615", "+H30363863550E", "DreilumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC 4FR 1L", 50, 1, 4, "18", "16615", "+H303617411806", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC 6FR TL FT", 50, 3, 6, "17 / 19 / 19", "16615", "+H30363861080A", "DreilumigerPICC.png"));
                modelList.Add(new PICCModel("POWERGROSHONG 5F SL BASIC 45CM", 45, 1, 5, "17", "16615", "+H30368185180F", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERGROSHONG 5F SL BASIC 55CM", 55, 1, 5, "17", "16615", "+H30369185180G", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERGROSHONG 5F SL FT 45CM", 45, 1, 5, "17", "16615", "+H30368185080E", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERGROSHONG 5F SL FT 55CM", 55, 1, 5, "17", "16615", "+H30369185080F", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("4FR SL POWERPICC 3CG FULL TRAY", 70, 1, 4, "18", null, null, "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("5FR SL POWERPICC 3CG FULL TRAY", 70, 1, 5, "18", null, null, "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("4FR SL POWERPICC SOLO 3CG FULL", 70, 1, 4, "18", null, null, "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("5FR SL POWERPICC SOLO 3CG FULL", 70, 1, 5, "18", null, null, "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("5FR DL POWERPICC 3CG FULL TRAY", 70, 2, 5, "18 / 18", null, null, "DoppellumigerPICC.png"));
                modelList.Add(new PICCModel("5FR DL POWERPICC SOLO 3CG FULL", 70, 2, 5, "18 / 18", null, null, "DoppellumigerPICC.png"));
                modelList.Add(new PICCModel("6FR TL POWERPICC SOLO 3CG FULL", 70, 3, 6, "17 / 19 / 19", null, null, "DreilumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC SOLO 4FR SL", 50, 1, 4, "18", "16615", "+H303619411808", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC SOLO 4FR SL", 135, 1, 4, "18", "16615", "+H303619433509", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC SOLO 4FR SL", 70, 1, 4, "18", "16615", "+H30361943550B", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC SOLO 5FR SL", 50, 1, 5, "18", "16615", "+H303619511809", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC SOLO 5FR SL", 135, 1, 5, "18", "16615", "+H30361953350A", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC SOLO 5FR SL", 70, 1, 5, "18", "16615", "+H30361953550C", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC SOLO 5FR DL", 50, 2, 5, "18 / 18", "16615", "+H30362951180A", "DoppellumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC SOLO 5FR DL", 135, 2, 5, "18 / 18", "16615", "+H30362953350B", "DoppellumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC SOLO 6FR TL", 50, 3, 6, "17 / 19 / 19", "16615", "+H30363961180C", "DreilumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC SOLO 6FR TL", 135, 3, 6, "17 / 19 / 19", "16615", "+H30363963350D", "DreilumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC SOLO 6FR TL", 70, 3, 6, "17 / 19 / 19", "16615", "+H30363963550F", "DreilumigerPICC.png"));
                modelList.Add(new PICCModel("PowerPICC Solo2 4F SL Komplettset m. 50cm GW", 50, 1, 4, "18", "16615", "+H303619410807", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("PowerPICC Solo2 5F DL Komplettset m. 50cm GW", 50, 2, 5, "18 / 18", "16615", "+H303629510809", "DoppellumigerPICC.png"));
                modelList.Add(new PICCModel("PowerPICC Solo2 6F TL Komplettset m. 50cm GW", 50, 3, 6, "17 / 19 / 19", "16615", "+H30363961080B", "DreilumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC SOLO 5FR DL", 70, 2, 5, "18 / 18", "16615", "+H30362953550D", "DoppellumigerPICC.png"));
                modelList.Add(new PICCModel("Groshong ClearVue PICC 4F SL Basisset", 0, 1, 4, "18", "16615", "+H3037617405CE2", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("Groshong ClearVue PICC 4F SL Basisset RadStic MI", 0, 1, 4, "18", "16615", "+H3037655405CE2", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("Groshong PICC 3F SL Basisset Introcan MI", 0, 1, 3, "20", "16615", "+H303771530506", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("Groshong PICC 3F SL Basisset RadStic MI", 0, 1, 3, "20", "16615", "+H30377553050A", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("Groshong NXT PICC 5F DL 45cm Basisset Excalibur MI", 0, 2, 5, "19 / 19", "16615", "+H30378275050C", "DoppellumigerPICC.png"));
                modelList.Add(new PICCModel("Groshong NXT PICC 5F DL 45cm Basisset RadStic MI", 0, 2, 5, "19 / 19", "16615", "+H3037857505CE20", "DoppellumigerPICC.png"));
                modelList.Add(new PICCModel("Groshong NXT PICC 5F DL 55cm Basisset Excalibur MI", 0, 2, 5, "19 / 19", "16615", "+H30379275050D", "DoppellumigerPICC.png"));
                modelList.Add(new PICCModel("Groshong NXT PICC 5F DL 55cm Basisset RadStic MI", 0, 2, 5, "19 / 19", "16615", "+H3037957505CE21", "DoppellumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC 5FR 1L", 50, 1, 5, "18", "16615", "+H303617511807", "EinlumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC 5FR 2L", 50, 2, 5, "18 / 18", "16615", "+H303627511808", "DoppellumigerPICC.png"));
                modelList.Add(new PICCModel("POWERPICC 6FR 3L", 50, 3, 6, "17 / 19 / 19", "16615", "+H303638610507", "DreilumigerPICC.png"));
            }

            return modelList;
        }

        public string PICCName { get; set; }
        public int Lumen { get; set; }
        public double FrenchDiameter { get; set; }
        public string PictureUri { get; set; }
        public string Barcode { get; set; }

        public double GuideWireLenght { get; set; }
        public string Gauge { get; set; }

        public string GNDMCode { get; set; }


        public PICCModel(string piccName, double guideWireLenght, int lumen, double frenchDiameter, string gauge, string gndmCode, string barcode, string pictureUri)
        {
            PICCName = piccName;
            GuideWireLenght = guideWireLenght;
            Lumen = lumen;
            FrenchDiameter = frenchDiameter;
            Gauge = gauge;
            GNDMCode = gndmCode;
            Barcode = barcode;
            PictureUri = pictureUri;

        }
    }
}
