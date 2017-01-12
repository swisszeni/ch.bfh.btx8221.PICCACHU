using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{
    public class GlossaryEntries
    {
        private static List<GlossaryEntry> glossaryList;

        private GlossaryEntries() { }

        public static List<GlossaryEntry> getEntries()
        {


            if (glossaryList == null)
            {
                glossaryList = new List<GlossaryEntry>();
                //glossaryList.Add(new GlossaryEntry("Ansatz", "Ein Zwischenstück aus Kunststoff am Katheter. Am Ansatzende des Katheters wird die Schutzkappe (MicroClave) des nadellosen Injektionssystems aufgeschraubt."));
                //glossaryList.Add(new GlossaryEntry("Austrittsstelle", "Stelle, an welcher der Katheter aus Ihrem Körper herausführt und sichtbar wird - im Fall eines PICC in der Regel am Arm."));
                //glossaryList.Add(new GlossaryEntry("Heparin", "Medikament, das die Bildung eines Blutgerinnsels verhindern kann."));
                //glossaryList.Add(new GlossaryEntry("IV-Therapie", "Auch: Intravenöse Therapie\nEin Medikament oder eine Flüssigkeit wird durch eine Vene verabreicht."));
                //glossaryList.Add(new GlossaryEntry("Katheter", "Ein weicher Schlauch, der in den Körper eingeführt wird. In diesem Fall handelt es sich um einen peripher eingeführten zentralen Venenkatheter (PICC: Peripherally inserted central venous catheter), der in eine Armvene eingeführt wird. Die Spitze des Katheters beﬁndet sich in einem Bereich mit grosser Blutzirkulation in der Nähe des Herzens. Durch den Katheter können verschiedene Medikamente und Flüssigkeiten verabreicht werden. Dadurch ist es nicht nötig, eine Nadel (Kanüle) direkt in die Vene einzuführen."));
                //glossaryList.Add(new GlossaryEntry("Katheterblockung", "Die empfohlene Spüllösung füllt den gesamten Hauptkanal des Katheters und beugt so der Bildung eines Blutgerinnsels vor."));
                //glossaryList.Add(new GlossaryEntry("Kochsalzlösung", "Eine Lösung aus Salz und Wasser."));
                //glossaryList.Add(new GlossaryEntry("Lumen", "Der Hauptkanal innerhalb eines Katheters. PICC können über ein, zwei oder drei verschiedene Kanäle verfügen."));
                //glossaryList.Add(new GlossaryEntry("Phlebitis", "Entzündung der Venenwände."));
                //glossaryList.Add(new GlossaryEntry("PICC", "Auch: peripher eingeführter zentraler Venenkatheter\nOder: peripherally inserted central venous catheter\nEin Katheter, der in eine der Armvenen eingeführt wird und bis in die Nähe des Herzens führt. Medikamente, die durch den Katheter verabreicht werden, können sich gut mit dem Blut vermischen. Dieser Katheter kann mit optimaler Pflege bis zu mehreren Monaten im Körper verbleiben."));
                //glossaryList.Add(new GlossaryEntry("MicroClave", "Auch: Schutzkappe des nadellosen Injektionssystems\nDie Schutzkappe des nadellosen Injektionssystems sorgt dafür, dass kein Blut zurück in den Katheter fliesst. Ausserdem kann die Verabreichung von Flüssigkeiten und Medikamenten in den Blutkreislauf direkt über diese Schutzkappe erfolgen. Sie muss vor jeder Verwendung genauestens desinfiziert werden."));
                //glossaryList.Add(new GlossaryEntry("Spülung mit Kochsalzlösung", "Zum Spülen des Katheters nach der Verabreichung einer Infusion wird sterile Kochsalzlösung verwendet."));
                //glossaryList.Add(new GlossaryEntry("Thrombose", "Gerinnung von Blut in einer Vene."));
                //glossaryList.Add(new GlossaryEntry("Thrombose in einer zentralen Vene", "Eine Blockade in einer zum Herzen führenden Vene, die durch ein Blutgerinnsel um den Katheter verursacht wird."));
                //    glossaryList.Add(new GlossaryEntry("Verstopfter Katheter", "Ein Katheter mit einem blockierten Hauptkanal. In diesem Fall sind keine Infusionen oder Abnahmen durch den Katheter möglich."));


            }
            return glossaryList;

        }
    }
}
