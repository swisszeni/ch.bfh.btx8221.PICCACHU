using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Models
{  
    public class MainentanceInstructions
    {
        private static List<MaintenanceInstruction> _statLockInstrution;
        private static List<MaintenanceInstruction> _microClaveInstruction;
        private static List<MaintenanceInstruction> _bandageChangingInstruction;

        private MainentanceInstructions() { }

        public static List<MaintenanceInstruction> getBandageChangingInstruction()
        {


            if (_bandageChangingInstruction == null)
            {
                _bandageChangingInstruction = new List<MaintenanceInstruction>();
                _bandageChangingInstruction.Add(new MaintenanceInstruction("Verbandswechsel1.jpg", "Der PICC Katheter ist mit einem speziellen Pflaster verbunden. Der Verbandwechsel kann nicht nur im Spital durchgeführt werden, sondern auch vom Hausarzt, der Spitex oder von Ihren Angehörigen. \n\nWas ist das für ein Verband?\nFür die Abdeckung Ihres PICC Katheters wird ein Folienverband mit einem CHG - Gelkissen in der Mitte angewandt. CHG (Chlorhexidin) ist ein sehr wirkungsvolles Mittel gegen Bakterien und andere Keime, das Entzündungen durch den PICC verhindert."));
                _bandageChangingInstruction.Add(new MaintenanceInstruction("Verbandswechsel2.jpg", "Was braucht man für den Verbandwechsel?\nFür die Durchführung des Verbandwechsels brauchen Sie folgende Materialien: \n– Händedesinfektionsmittel \n– Sterile Wattestäbchen \n– Desinfektionsmittel \n– Folienverband mit CHG (Chlorhexidin) \n\nWie häufig muss der Verband gewechselt werden? \nWenn keine Probleme auftreten, muss der Verband alle sieben Tage gewechselt werden. Wenn eines der folgenden Symptome auftritt, muss der Verband auch schon früher gewechselt werden: \n– Die Einstichstelle nicht vollständig abgedeckt ist \n– Der Verband nicht sicher auf der Haut klebt / ﬁxiert ist \n– Es nachblutet \n– Der Verband feucht ist \n– Der Katheter unter dem Verband einer Zugbelastung ausgesetzt ist \n– Die Einstichstelle schmerzt \n\nWichtig: \nWenn Sie Schmerzen an der Einstichstelle oder am Arm haben, die Einstichstelle stark gerötet ist oder sogar eitert, melden Sie sich bei Ihren Fachpersonen oder über die Telemedizinische Beratung des UniversitätsSpitals. Möglicherweise ist der Katheter entzündet und muss entfernt werden."));
                _bandageChangingInstruction.Add(new MaintenanceInstruction("Verbandswechsel3.jpg", "Wie wechselt man den Verband? \nZunächst werden die Hände gut desinﬁziert. Der alte Verband muss vorsichtig abgelöst werden. Dabei ist es wichtig, dass kein Zug auf den Katheter ausgeübt wird."));
                _bandageChangingInstruction.Add(new MaintenanceInstruction("Verbandswechsel4.jpg", "Anschliessend wird die Einstichstelle mit den sterilen Wattestäbchen, die mit Desinfektionsmittel getränkt wurden, gereinigt."));
                _bandageChangingInstruction.Add(new MaintenanceInstruction("Verbandswechsel5.jpg", "Dies kann mit oder ohne liegenden StatLock erfolgen."));
                _bandageChangingInstruction.Add(new MaintenanceInstruction("Verbandswechsel6.jpg", "Den Verband mit dem Gelkissen so platzieren, dass die Einstichstelle in der Mitte des Gelkissens liegt."));
                _bandageChangingInstruction.Add(new MaintenanceInstruction("Verbandswechsel7.jpg", "Dabei ist es möglich, dass ein Teil des Gelkissens den StatLock verdeckt, was aber toleriert wird."));
                _bandageChangingInstruction.Add(new MaintenanceInstruction("Verbandswechsel8.jpg", "Der Verband muss anschliessend gut anmodelliert werden, dabei wird der Verstärkungsrand vorsichtig entfernt."));
                _bandageChangingInstruction.Add(new MaintenanceInstruction("Verbandswechsel9.jpg", "Sinnvoll ist es, den PICC Katheter gut zu schützen. Dafür eigenen sich eine Gaze, um Druckstellen zu vermeiden und ein Schlauchverband als Schutz."));
                _bandageChangingInstruction.Add(new MaintenanceInstruction("Verbandswechsel10.jpg", "Wenn die Haut empﬁndlich auf das Tegaderm - Pflaster oder den Statlock reagiert, kann sie mit Cavilon - Stäbchen oder Skin Prep vorbehandelt werden."));
                _bandageChangingInstruction.Add(new MaintenanceInstruction("Verbandswechsel11.jpg", "Wichtig: \nFeuchtigkeit vor dem Anbringen des Verbandes bzw. des StatLocks gut trockenen lassen!"));
                _bandageChangingInstruction.Add(new MaintenanceInstruction("Verbandswechsel12.jpg", "Kann man mit dem Verband duschen und baden? Der Folienverband ist luftdurchlässig aber wasserdicht. Duschen ist problemlos möglich, auf Baden oder einen Schwimmbadbesuch ist in dieser Zeit zu verzichten, da das Infektionsrisiko zu hoch ist."));

            }
            return _bandageChangingInstruction;

        }

        public static List<MaintenanceInstruction> getStatLockInstruction()
        {


            if (_statLockInstrution == null)
            {
                _statLockInstrution = new List<MaintenanceInstruction>();
                _statLockInstrution.Add(new MaintenanceInstruction("StatLock1.jpg", "Damit der PICC Katheter sicher ﬁxiert ist, wurde ein sogenannter StatLock angebracht. \n\nWas ist ein StatLock? \nEin StatLock ist eine Sicherheitsbefestigung für den PICC Katheter und wird direkt auf die Haut geklebt. \n\nWie oft muss der StatLock gewechselt werden? \nDer StatLock muss nur gewechselt werden, wenn er sich löst oder verschmutzt ist. Sonst kann er bis zu mehreren Wochen belassen werden. \n\nWie wird das StatLock-Set angewendet? \nIm StatLock - Set sind alle Materialen enthalten, die Sie für das Anbringen bzw. den Wechsel des StatLock brauchen. Sie benötigen zusätzlich nur noch ein Händedesinfektionsmittel."));
                _statLockInstrution.Add(new MaintenanceInstruction("StatLock2.jpg", "Komplettes Set enthält: \n– Hautschutzmittel \n– StatLock (Befestigungsclip) \n– Alternative Befestigungsvorrichtung für die einzelnen Lumen (wird nicht gebraucht) \n– Klebestreifen (meist nicht gebraucht)"));
                _statLockInstrution.Add(new MaintenanceInstruction("StatLock3.jpg", "Vor dem Anbringen bzw. dem Wechsel des StatLock unbedingt die Hände desinﬁzieren! Hautschutzmittel dort auftragen, wo der StatLock angebracht werden soll. Das Hautschutzmittel schützt die Haut und entfernt Schweiss und Talgabsonderungen sowie mögliche Klebereste. Gut trocknen lassen (30 Sek – 1 Minute)."));
                _statLockInstrution.Add(new MaintenanceInstruction("StatLock4.jpg", "Die Flügel des PICC Katheters zuerst in den StatLock einlegen."));
                _statLockInstrution.Add(new MaintenanceInstruction("StatLock5.jpg", "Anschliessend die Klappen des StatLock schliessen."));
                _statLockInstrution.Add(new MaintenanceInstruction("StatLock6.jpg", "Nun die Schutzfolie entfernen."));
                _statLockInstrution.Add(new MaintenanceInstruction("StatLock7.jpg", "Erst jetzt den StatLock auf das vorbereitete Hautfeld so aufkleben, dass möglichst keine Zugbelastung auf dem Katheter entsteht!"));

            }
            return _statLockInstrution;

        }

        public static List<MaintenanceInstruction> getMicroClaveInstruction()
        {


            if (_microClaveInstruction == null)
            {
                _microClaveInstruction = new List<MaintenanceInstruction>();
                _microClaveInstruction.Add(new MaintenanceInstruction("MicroClave1.jpg", "Was ist ein MicroClave? \nDer PICC - Katheter wird mit einem sogenannten MicroClave verschlossen. Das ist ein Verschlussstopfen mit einer Silikonmembran. Er schliesst den Katheter nach aussen ab und sorgt dafür, dass im Schlauchsystem ein positiver Druck besteht. So wird ein Nachlaufen von Blut verhindert, das den Katheter verstopfen könnte. Wird der Katheter mit einem MicroClave verschlossen, muss die Verschlussklemme des PICC - Katheters offen bleiben."));
                _microClaveInstruction.Add(new MaintenanceInstruction("MicroClave2.jpg", "Wie oft muss der MicroClave gewechselt werden? \nDer MicroClave muss alle sieben Tage gewechselt werden. Bei starker Verschmutzung, beispielsweise durch Blutentnahmen, wird er auch früher gewechselt."));
                _microClaveInstruction.Add(new MaintenanceInstruction("MicroClave3.jpg", "Wie arbeitet man mit dem MicroClave? \nBevor der Katheter über den MicroClave verwendet werden kann, muss eine gute Händehygiene erfolgen. Anschliessend wird die Silikonmembran des MicroClave gut desinﬁziert. Das Desinfektionsmittel muss zwingend mindestens 30 Sekunden einwirken!"));
                _microClaveInstruction.Add(new MaintenanceInstruction("MicroClave4.jpg", "Wichtig: \nDie Membran des MicroClave darf nach dem Desinﬁzieren nicht mehr berührt werden!"));
                _microClaveInstruction.Add(new MaintenanceInstruction("MicroClave5.jpg", "Anschliessend kann der Katheter über den MicroClave mit den verschiedenen Anschlussystemen – sowohl mit LuerLock als auch mit SlipLock – verwendet werden."));
                _microClaveInstruction.Add(new MaintenanceInstruction("MicroClave6.jpg", "Den LuerLock-Verschluss mit leichtem Druck und einer Drehbewegung an den MicroClave anschrauben. Mit Infusionen gleich verfahren."));
                _microClaveInstruction.Add(new MaintenanceInstruction("MicroClave7.jpg", "Beim SlipLock den Konus der Spritze exakt in die Silikonmembran drücken, mit einer ¼-Drehung festschrauben und die Flüssigkeit injizieren. Mit einer weiteren ¼-Drehung wird die Spritze aus der Silikonmembran gelöst."));
                _microClaveInstruction.Add(new MaintenanceInstruction("MicroClave8.jpg", "Wichtig: \nNach jeder Nutzung des MicroClave muss der PICC - Katheter einmal gespült werden, um den positiven Druck aufzubauen und um allfällige Medikamentenreste zu entfernen.Dies erfolgt mit 20ml steriler Kochsalzlösung (NaCl 0.9 %) mit der Stopp - Push - Technik (Spülen – Stoppen – Spülen – Stoppen). Die Katheterklemme danach offen lassen."));
                _microClaveInstruction.Add(new MaintenanceInstruction("MicroClave9.jpg", "Wie wechselt man den MicroClave? \nZum Wechseln des MicroClave wird zuerst die Klemme am Katheter geschlossen. Anschliessend wird der alte MicroClave abgeschraubt und entfernt. Nun wird der neue MicroClave steril aufgeschraubt."));
                _microClaveInstruction.Add(new MaintenanceInstruction("MicroClave10.jpg", "Wichtig: \nAuch nach dem Anbringen des neuen MicroClave muss das System einmal gespült werden, um den positiven Druck aufzubauen. Dies erfolgt mit 20ml steriler Kochsalzlösung(NaCl 0.9 %) mit der Stopp - Push - Technik (Spülen – Stoppen – Spülen – Stoppen). Die Katheterklemme danach unbedingt offen lassen."));
            }
            return _microClaveInstruction;

        }
    }
}
