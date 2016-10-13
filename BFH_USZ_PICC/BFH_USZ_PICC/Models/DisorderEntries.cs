using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public class DisorderEntries
    {
        private static List<DisorderEntry> disorderList;

        private DisorderEntries() { }

        public static List<DisorderEntry> getEntries()
        {


            if (disorderList == null)
            {
                disorderList = new List<DisorderEntry>();
                disorderList.Add(new DisorderEntry("Rötung","Kleiner geröteter Bereich um die Austrittsstelle mit Schwellung. Dies tritt mit grösserer Wahrscheinlichkeit innerhalb der ersten 10 Tage nach der Platzierung auf", "Phlebitis (Entzündung der Druckschmerz und Venenwände)", "Rufen Sie Ihre Pflegefachperson oder Ihren Arzt an. Eine Phlebitis lässt sich sehr erfolgreich behandeln, wenn sie frühzeitig erkannt wird."));
                disorderList.Add(new DisorderEntry("Schwellung","Schwellung von Hand, Arm oder Hals (Venenthrombose)", "Möglicherweise ein Blutgerinnsel in der Vene", "Rufen Sie sofort Ihre Pflegefachperson oder Ihren Arzt an. In der Vene und im Bereich des Katheters kann sich ein Blutgerinnsel gebildet haben. Ihr Arzt kann ein Medikament einführen, das die Auflösung des Gerinnsels bewirkt oder er kann allenfalls den Katheter entfernen."));
                disorderList.Add(new DisorderEntry("Fieber / Ausfluss","Fieber, ausgeprägte Schmerzen, Rötung, Schwellung und Ausfluss an der Austrittsstelle", "Infektion", "Rufen Sie sofort Ihre Pflegefachperson oder Ihren Arzt an. Befolgen Sie zum Schutz vor Infektionen stets die empfohlenen Richtlinien: Waschen Sie sich grundsätzlich die Hände, bevor Sie den Katheter berühren. Sorgen Sie dafür, dass der Katheter trocken bleibt und nicht mit Wasser in Berührung kommt."));
                disorderList.Add(new DisorderEntry("Beschädigung","Der Katheter ist beschädigt oder es tritt Blut aus", "Der Katheter riss oder wurde versehentlich durchgeschnitten.", "Verständigen Sie bitte umgehend Ihr Behandlungsteam. Der PICC Katheter muss sofort zwischen Eintrittsstelle und Beschädigung abgeklemmt werden. Falls keine Klemme vorhanden ist, muss der Katheter nach oben umgeknickt und mit Pflaster befestigt werden."));
                disorderList.Add(new DisorderEntry("Blut in Schutzkappe", "Auf der Innenseite der Schutzkappe ist Blut vorhanden oder es tritt Blut aus dem Ansatzbereich des Katheters aus", "Die Schutzkappe des Injektionssystems löste sich  versehentlich", "Verschliessen Sie den Katheter sofort mit der Klemme und rufen Sie Ihre Pflegefachperson oder Ihren Arzt an."));
                disorderList.Add(new DisorderEntry("Atemprobleme","Kurzatmigkeit, Husten oder Brustschmerz", "Luft gelangte in die Blutbahn", "Rufen Sie bitte sofort den Notarzt. Klemmen Sie den Katheter ab."));
                disorderList.Add(new DisorderEntry("Widerstand","Bei der Verabreichung von Medikamenten in den Katheter ist ein Widerstand spürbar", "Verstopfter (blockierter) Katheter (z.B. durch ein Blutgerinnsel, das im Inneren oder an der Spitze des Katheters den Durchfluss behindert oder verunmöglicht)", "Ihr Arzt kann ein Medikament infundieren, das die Auflösung des Gerinnsels bewirkt, oder den Katheter entfernen. Eine Infusion mit übermässigem Kraftaufwand durch einen verstopften Katheter kann den Katheter beschädigen."));
                disorderList.Add(new DisorderEntry("Loser Katheter","Der Katheter ist an der Austrittsstelle nicht mehr korrekt angebracht; ein Zurückfliessendes Blutes ist nicht mehr feststellbar", "Der Katheter verschob sich", "Verständigen Sie Ihren Arzt oder Ihre Pflegefachperson. Die Position der Katheterspitze muss mit Hilfe einer Röntgenaufnahme überprüft und die Spitze neu positioniert werden."));

            }

            return disorderList;

        }
    }
}
