using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace BFH_USZ_PICC.UITests.Droid
{
    [TestFixture]
    public class Tests
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the Android app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            app = ConfigureApp
                .Android
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                //.ApkFile ("../../BFH_USZ_PICC/BFH_USZ_PICC.Droid/bin/Release/ch.bfh.i4mi.picc.apk")
                .StartApp();
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void CreatePICCTest()
        {
            app.Tap(x => x.Text("Neuer PICC erfassen"));
            app.Tap(x => x.Id("search_src_text"));
            app.EnterText(x => x.Id("search_src_text"), "5FR DL f");
            app.Screenshot("PICC search filtered");
            app.TouchAndHold(x => x.Text("Führungsdrahtslänge in cm: 50"));
            app.ScrollDownTo("Nicht definiert");
            app.Tap(x => x.Text("Nicht definiert"));
            app.Tap(x => x.Text("Schweiz"));
            app.ClearText(x => x.Class("EditText").Text("Nicht definiert"));
            app.EnterText(x => x.Class("EditText").Text("Nicht definiert"), "Nicht definier");
            app.ScrollDownTo("Nicht definiert");
            app.Tap(x => x.Text("Nicht definiert"));
            app.Tap(x => x.Text("Rechts"));
            app.ClearText(x => x.Class("EditText").Text("Nicht definiert"));
            app.EnterText(x => x.Class("EditText").Text("Nicht definiert"), "Nicht definier");
            app.Screenshot("PICC details entered");
            app.Tap(x => x.Text("Speichern"));
            app.Screenshot("PICC saved");
        }

        [Test]
        public void CreateJournalEntryTest()
        {
            app.Tap(x => x.Marked("OK"));
            app.TouchAndHold(x => x.Text("Meine Notizen"));
            app.Screenshot("Journal overview empty");
            app.Tap(x => x.Text("Neuer Eintrag"));
            app.Tap(x => x.Text("Verabreichte Medikamente"));
            app.Screenshot("Medicament entry empty");
            app.Tap(x => x.Class("EntryEditText"));
            app.EnterText(x => x.Class("EntryEditText"), "Test");
            app.ScrollDown();
            app.PressEnter();
            app.Tap(x => x.Text("Keine Angabe"));
            app.Tap(x => x.Text("Spitex"));
            app.ClearText(x => x.Class("EditText").Text("Keine Angabe"));
            app.EnterText(x => x.Class("EditText").Text("Keine Angabe"), "Keine Angab");
            app.Tap(x => x.Text("Keine Angabe"));
            app.Tap(x => x.Text("Betroffene Person"));
            app.EnterText(x => x.Class("EditText").Text("Keine Angabe"), "e");
            app.Screenshot("Medicament entry filled");
            app.Tap(x => x.Text("Speichern"));
            app.Screenshot("Entry saved");
        }
    }
}

