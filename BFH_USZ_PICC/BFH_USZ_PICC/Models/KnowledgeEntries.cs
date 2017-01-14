using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Models
{
    public class KnowledgeEntries
    {
        //private static List<KnowledgeEntry> knowledgeEntryList;

        //test with page type groups
        private static List<KnowledgeEntryTypeGroup> knowledgeEntryList;
        

        private KnowledgeEntries() { }

        public static List<KnowledgeEntryTypeGroup> getEntries()
        {
         
            if (knowledgeEntryList == null)
            {
                //KnowledgeEntryTypeGroup generalGroup = new KnowledgeEntryTypeGroup("Allgemein", "Allgemein");
                //KnowledgeEntryTypeGroup homeGroup = new KnowledgeEntryTypeGroup("Zuhause", "Zuhause");
                //KnowledgeEntryTypeGroup maintenanceInstructionsGroup = new KnowledgeEntryTypeGroup("Wartungsanleitungen", "Wartungsanleitungen");
                //knowledgeEntryList = new List<KnowledgeEntryTypeGroup> { generalGroup, homeGroup, maintenanceInstructionsGroup };

                //// "Was ist ein PICC?" page information
                //List<IKnowledgeEntryElement> whatIsAPiccEntry = new List<IKnowledgeEntryElement>();
                //whatIsAPiccEntry.Add(new KnowledgeEntryTextElement("Ihr zentraler PICC Venenkatheter besteht aus weichem, flexiblem Material (Silikon oder Polyurethan). Der lange, schmale Katheter ist mit einem breiteren, verstärkten Ansatz aus Kunststoff, sowie je nach Ausführung mit einer Kunststoffklemme und mit «Flügeln» ausgestattet. Durch diese Flügel kann der Katheter besser auf der Haut ﬁxiert werden. Am äusseren Ende ist eine Schutzkappe angebracht. Diese verhindert, dass Blut zurück in den Katheter fliesst (siehe MicroClave).\n\nManchmal verschreibt der Arzt einen Katheter mit zwei separaten Kanälen (doppellumiger Katheter). Diese zwei Kanäle ermöglichen die Verabreichung unterschiedlicher Substanzen."));
                //whatIsAPiccEntry.Add(new KnowledgeEntryImageElement(new Image { Source = "DoppellumigerPICC.png" }, "Doppellumiger PICC: Kunststoffklemme zum Verschliessen des Katheters"));

                //List<GlossaryEntry> glossaryWordsForWhatIsAPiccEntry = new List<GlossaryEntry>();
                //glossaryWordsForWhatIsAPiccEntry.Add(new GlossaryEntry("Ansatz", "Ein Zwischenstück aus Kunststoff am Katheter. Am Ansatzende des Katheters wird die Schutzkappe (MicroClave) des nadellosen Injektionssystems aufgeschraubt."));
                //glossaryWordsForWhatIsAPiccEntry.Add(new GlossaryEntry("Katheter", "Ein weicher Schlauch, der in den Körper eingeführt wird. In diesem Fall handelt es sich um einen peripher eingeführten zentralen Venenkatheter (PICC: Peripherally inserted central venous catheter), der in eine Armvene eingeführt wird. Die Spitze des Katheters beﬁndet sich in einem Bereich mit grosser Blutzirkulation in der Nähe des Herzens. Durch den Katheter können verschiedene Medikamente und Flüssigkeiten verabreicht werden. Dadurch ist es nicht nötig, eine Nadel (Kanüle) direkt in die Vene einzuführen."));
                //glossaryWordsForWhatIsAPiccEntry.Add(new GlossaryEntry("PICC (peripher eingeführter zentraler Venenkatheter oder peripherally inserted central venous catheter)", "Ein Katheter, der in eine der Armvenen eingeführt wird und bis in die Nähe des Herzens führt. Medikamente, die durch den Katheter verabreicht werden, können sich gut mit dem Blut vermischen. Dieser Katheter kann mit optimaler Pflege bis zu mehreren Monaten im Körper verbleiben."));
                //glossaryWordsForWhatIsAPiccEntry.Add(new GlossaryEntry("Schutzkappe des nadellosen Injektionssystems (MicroClave)", "Die Schutzkappe des nadellosen Injektionssystems sorgt dafür, dass kein Blut zurück in den Katheter fliesst. Ausserdem kann die Verabreichung von Flüssigkeiten und Medikamenten in den Blutkreislauf direkt über diese Schutzkappe erfolgen. Sie muss vor jeder Verwendung genauestens desinfiziert werden."));

                //KnowledgeEntry whatIsAPicc = new KnowledgeEntry("Was ist ein PICC?", whatIsAPiccEntry, glossaryWordsForWhatIsAPiccEntry);
                //generalGroup.Add(whatIsAPicc);

                //// "Wozu wird ein PICC verwendet?" page information
                //List<IKnowledgeEntryElement> whyUseAPiccEntry = new List<IKnowledgeEntryElement>();
                //whyUseAPiccEntry.Add(new KnowledgeEntryTextElement("Ein PICC ist für die Verabreichung von Flüssigkeiten, von Blutprodukten, Medikamenten und intravenösen Nährlösungen bestimmt. Er kann auch zur Abnahme von Blutproben verwendet werden. Ein PICC kann je nach Therapie mehrere Wochen oder Monate in einer Vene verbleiben.\n\nDer PICC ist insbesondere dann sinnvoll, wenn Ihnen im Rahmen einer Therapie zahlreiche Infusionen verabreicht werden müssen. Dank dem Venenzugang über den PICC müssen die Fachleute nicht für jede Infusion eine neue Einstichstelle schaffen. Der PICC verhindert somit, dass Ihre Venen an Hand und Arm durch diverse Einstiche belastet werden.\n\nDie Verabreichung Ihrer Therapie wird durch den PICC zuverlässiger, komfortabler und einfacher."));
                //whyUseAPiccEntry.Add(new KnowledgeEntryImageElement(new Image { Source = "EinlumigerPICC.png" }, "Einlumiger PICC: Weiches, flexibles Kathetermaterial"));

                //List<GlossaryEntry> glossaryWordsForWhyUseAPiccEntry = new List<GlossaryEntry>();
                //glossaryWordsForWhyUseAPiccEntry.Add(new GlossaryEntry("Intravenöse Therapie (IV-Therapie)", "Ein Medikamenten oder eine Flüssigkeit wird durch eine Vene verabreicht."));
                //glossaryWordsForWhyUseAPiccEntry.Add(new GlossaryEntry("Katheter", "Ein weicher Schlauch, der in den Körper eingeführt wird. In diesem Fall handelt es sich um einen peripher eingeführten zentralen Venenkatheter (PICC: Peripherally inserted central venous catheter), der in eine Armvene eingeführt wird. Die Spitze des Katheters beﬁndet sich in einem Bereich mit grosser Blutzirkulation in der Nähe des Herzens. Durch den Katheter können verschiedene Medikamente und Flüssigkeiten verabreicht werden. Dadurch ist es nicht nötig, eine Nadel (Kanüle) direkt in die Vene einzuführen."));
                //glossaryWordsForWhyUseAPiccEntry.Add(new GlossaryEntry("PICC (peripher eingeführter zentraler Venenkatheter oder peripherally inserted central venous catheter)", "Ein Katheter, der in eine der Armvenen eingeführt wird und bis in die Nähe des Herzens führt. Medikamente, die durch den Katheter verabreicht werden, können sich gut mit dem Blut vermischen. Dieser Katheter kann mit optimaler Pflege bis zu mehreren Monaten im Körper verbleiben."));

                //KnowledgeEntry whyUseAPicc = new KnowledgeEntry("Wozu wird ein PICC verwendet?", whyUseAPiccEntry, glossaryWordsForWhyUseAPiccEntry);
                //generalGroup.Add(whyUseAPicc);

                //// "Wie wird ein PICC platziert?" page information
                //List<IKnowledgeEntryElement> howToPlaceAPicc = new List<IKnowledgeEntryElement>();
                //howToPlaceAPicc.Add(new KnowledgeEntryTextElement("Die Platzierung eines PICC erfolgt durch einen minimal invasiven Eingriff in der Radiologie. Zuerst machen die Fachleute die Haut mit einem Lokalanästhetikum unempﬁndlich. Dann führen sie den PICC in eine Vene in Ihrer Armbeuge oder am Oberarm ein. Die Spitze des Katheters ist in einem Bereich mit hoher Blutzirkulation in der Nähe des Herzens positioniert, um ein möglichst gutes Vermischen Ihrer intravenös verabreichten Medikamente zu ermöglichen. Unmittelbar nach der Platzierung des PICC spülen die Spezialisten den PICC mit Kochsalzlösung oder verdünntem Heparin, um zu verhindern, dass der Katheter verstopft. Anschliessend wird der Katheter mit der MicroClave Schutzkappe verschlossen."));
                //howToPlaceAPicc.Add(new KnowledgeEntryImageElement(new Image { Source = "PiccPlatzierung.png" }));
                //howToPlaceAPicc.Add(new KnowledgeEntryTextElement("Ob der PICC richtig platziert ist, überprüfen die Fachleute anhand einer Röntgenaufnahme oder mit einem anderen Abbildungsverfahren. Danach ﬁxieren sie den aus dem Körper herausführenden Abschnitt des Katheters mit einer eigens dafür entwickelten Haftplatte (StatLock) auf der Haut. Den Bereich um die Austrittsstelle des Katheters bedecken sie mit einem sterilen Verband. Lässt die Wirkung des Lokalanästhetikums nach dem Einlegen des Katheters nach, können während ein oder zwei Tagen leichte Schmerzen auftreten."));

                //List<GlossaryEntry> glossaryWordsForHowToPlaceAPiccEntry = new List<GlossaryEntry>();
                //glossaryWordsForHowToPlaceAPiccEntry.Add(new GlossaryEntry("Austrittsstelle", "Stelle, an welcher der Katheter aus Ihrem Körper herausführt und sichtbar wird - im Fall eines PICC in der Regel am Arm."));
                //glossaryWordsForHowToPlaceAPiccEntry.Add(new GlossaryEntry("Heparin", "Medikament, das die Bildung eines Blutgerinnsels verhindern kann."));
                //glossaryWordsForHowToPlaceAPiccEntry.Add(new GlossaryEntry("Intravenöse Therapie (IV-Therapie)", "Ein Medikamenten oder eine Flüssigkeit wird durch eine Vene verabreicht."));
                //glossaryWordsForHowToPlaceAPiccEntry.Add(new GlossaryEntry("Katheter", "Ein weicher Schlauch, der in den Körper eingeführt wird. In diesem Fall handelt es sich um einen peripher eingeführten zentralen Venenkatheter (PICC: Peripherally inserted central venous catheter), der in eine Armvene eingeführt wird. Die Spitze des Katheters beﬁndet sich in einem Bereich mit grosser Blutzirkulation in der Nähe des Herzens. Durch den Katheter können verschiedene Medikamente und Flüssigkeiten verabreicht werden. Dadurch ist es nicht nötig, eine Nadel (Kanüle) direkt in die Vene einzuführen."));
                //glossaryWordsForHowToPlaceAPiccEntry.Add(new GlossaryEntry("Kochsalzlösung", "Eine Lösung aus Salz und Wasser."));
                //glossaryWordsForHowToPlaceAPiccEntry.Add(new GlossaryEntry("PICC (peripher eingeführter zentraler Venenkatheter oder peripherally inserted central venous catheter)", "Ein Katheter, der in eine der Armvenen eingeführt wird und bis in die Nähe des Herzens führt. Medikamente, die durch den Katheter verabreicht werden, können sich gut mit dem Blut vermischen. Dieser Katheter kann mit optimaler Pflege bis zu mehreren Monaten im Körper verbleiben."));
                //glossaryWordsForHowToPlaceAPiccEntry.Add(new GlossaryEntry("Schutzkappe des nadellosen Injektionssystems (MicroClave)", "Die Schutzkappe des nadellosen Injektionssystems sorgt dafür, dass kein Blut zurück in den Katheter fliesst. Ausserdem kann die Verabreichung von Flüssigkeiten und Medikamenten in den Blutkreislauf direkt über diese Schutzkappe erfolgen. Sie muss vor jeder Verwendung genauestens desinfiziert werden."));
                //glossaryWordsForHowToPlaceAPiccEntry.Add(new GlossaryEntry("Spülung mit Kochsalzlösung", "Zum Spülen des Katheters nach der Verabreichung einer Infusion wird sterile Kochsalzlösung verwendet."));
                //glossaryWordsForHowToPlaceAPiccEntry.Add(new GlossaryEntry("Verstopfter Katheter", "Ein Katheter mit einem blockierten Hauptkanal. In diesem Fall sind keine Infusionen oder Abnahmen durch den Katheter möglich."));

                //KnowledgeEntry howToUseAPicc = new KnowledgeEntry("Wie wird ein PICC platziert?", howToPlaceAPicc, glossaryWordsForHowToPlaceAPiccEntry);
                //generalGroup.Add(howToUseAPicc);

                //// "Komfort und Bewegung" page information
                //List<IKnowledgeEntryElement> comfortEntry = new List<IKnowledgeEntryElement>();
                //comfortEntry.Add(new KnowledgeEntryTextElement("Der PICC Katheter schränkt aufgrund seiner Lage am Oberarm Ihre Bewegung nur wenig ein.\n\nAchten Sie darauf, dass keine Zugkräfte auf den PICC Katheter einwirken.\n\nHeben Sie im Alltag keine Gewichte von mehr als 10 Kilogramm.\n\nSport ist grundsätzlich möglich. Es sollte jedoch kein ausgeprägter Kraftaufwand stattﬁnden. Verzichten Sie auf Kontaktsportarten (z.B. Judo, Karate)."));
               
                //List<GlossaryEntry> glossaryWordsForComfortEntry = new List<GlossaryEntry>();
                //glossaryWordsForComfortEntry.Add(new GlossaryEntry("PICC (peripher eingeführter zentraler Venenkatheter oder peripherally inserted central venous catheter)", "Ein Katheter, der in eine der Armvenen eingeführt wird und bis in die Nähe des Herzens führt. Medikamente, die durch den Katheter verabreicht werden, können sich gut mit dem Blut vermischen. Dieser Katheter kann mit optimaler Pflege bis zu mehreren Monaten im Körper verbleiben."));
                
                //KnowledgeEntry comfort = new KnowledgeEntry("Komfort und Bewegung", comfortEntry, glossaryWordsForComfortEntry);
                //homeGroup.Add(comfort);

                //// "Körperpflege" page information
                //List<IKnowledgeEntryElement> bodyCareEntry = new List<IKnowledgeEntryElement>();
                //bodyCareEntry.Add(new KnowledgeEntryTextElement("Duschen ist mit dem wasserabweisenden Folienpflaster problemlos möglich.\n\nBaden und Schwimmen mit einem PICC Katheter sind NICHT erlaubt."));

                //List<GlossaryEntry> glossaryWordsForBodyCareEntry = new List<GlossaryEntry>();
                //glossaryWordsForBodyCareEntry.Add(new GlossaryEntry("PICC (peripher eingeführter zentraler Venenkatheter oder peripherally inserted central venous catheter)", "Ein Katheter, der in eine der Armvenen eingeführt wird und bis in die Nähe des Herzens führt. Medikamente, die durch den Katheter verabreicht werden, können sich gut mit dem Blut vermischen. Dieser Katheter kann mit optimaler Pflege bis zu mehreren Monaten im Körper verbleiben."));

                //KnowledgeEntry body  = new KnowledgeEntry("Körperpflege", bodyCareEntry, glossaryWordsForBodyCareEntry);
                //homeGroup.Add(body);

                //// "PflegeEinstichstelle" page information
                //List<IKnowledgeEntryElement>piccPunctureEntry = new List<IKnowledgeEntryElement>();
                //piccPunctureEntry.Add(new KnowledgeEntryTextElement("Die Pflege des PICC Katheters nach dem Spitalaufenthalt muss durch Fachpersonen (Hausarzt, Pflegefachpersonen oder geschulte Angehörige) erfolgen.\n\nWichtig: Bitte desinﬁzieren Sie vor jeder Handlung am Katheter die Hände."));

                //List<GlossaryEntry> glossaryWordsForPiccPunctureEntry = new List<GlossaryEntry>();
                //glossaryWordsForPiccPunctureEntry.Add(new GlossaryEntry("PICC (peripher eingeführter zentraler Venenkatheter oder peripherally inserted central venous catheter)", "Ein Katheter, der in eine der Armvenen eingeführt wird und bis in die Nähe des Herzens führt. Medikamente, die durch den Katheter verabreicht werden, können sich gut mit dem Blut vermischen. Dieser Katheter kann mit optimaler Pflege bis zu mehreren Monaten im Körper verbleiben."));

                //KnowledgeEntry puncture = new KnowledgeEntry("Pflege PICC-Katheter/Einstichstelle/Verband", piccPunctureEntry, glossaryWordsForPiccPunctureEntry);
                //homeGroup.Add(puncture);

                //// "Vorsichtsmassnahmen" page information
                //List<IKnowledgeEntryElement> preventiveMeasuresEntry = new List<IKnowledgeEntryElement>();
                //preventiveMeasuresEntry.Add(new KnowledgeEntryTextElement("Der Bereich, in dem der PICC Katheter aus der Haut austritt, muss stets sauber und trocken sein.\n\nVermeiden Sie den Gebrauch von Scheren oder anderen scharfen Schneideinstrumenten in der Nähe des PICC Katheters."));

                //List<GlossaryEntry> glossaryWordsForPreventiveMeasuresEntry = new List<GlossaryEntry>();
                //glossaryWordsForPreventiveMeasuresEntry.Add(new GlossaryEntry("PICC (peripher eingeführter zentraler Venenkatheter oder peripherally inserted central venous catheter)", "Ein Katheter, der in eine der Armvenen eingeführt wird und bis in die Nähe des Herzens führt. Medikamente, die durch den Katheter verabreicht werden, können sich gut mit dem Blut vermischen. Dieser Katheter kann mit optimaler Pflege bis zu mehreren Monaten im Körper verbleiben."));
                //glossaryWordsForPreventiveMeasuresEntry.Add(new GlossaryEntry("Austrittsstelle", "Stelle, an welcher der Katheter aus Ihrem Körper herausführt und sichtbar wird - im Fall eines PICC in der Regel am Arm."));
                
                //KnowledgeEntry preventiveMeasures = new KnowledgeEntry("Vorsichtsmassnahmen", preventiveMeasuresEntry, glossaryWordsForPreventiveMeasuresEntry);
                //homeGroup.Add(preventiveMeasures);

                ////Add all maintenance instructions to the related group
                //maintenanceInstructionsGroup.Add(MainentanceInstructions.getBandageChangingInstruction());
                //maintenanceInstructionsGroup.Add(MainentanceInstructions.getMicroClaveInstruction());
                //maintenanceInstructionsGroup.Add(MainentanceInstructions.getStatLockInstruction());


            }
            return knowledgeEntryList;
        }
    }
}
