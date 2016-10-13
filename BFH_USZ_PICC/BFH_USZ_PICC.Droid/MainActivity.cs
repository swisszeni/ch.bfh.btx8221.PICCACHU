using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using HockeyApp;

namespace BFH_USZ_PICC.Droid
{
    [Activity(Label = "USZ PICC", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity  // was FormsApplicationActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;
            base.OnCreate(bundle);
            Forms.Init(this, bundle);
            LoadApplication(new Application());

            // Enable crashlog with HockeyApp
            //FIXME
            //CrashManager.Register(this, "244728446c94483cb57c2620f12c9982");

            // check for updates of the app
            CheckForUpdates();
        }

        void CheckForUpdates()
        {
            //FIXME

            //UpdateManager.Register(this, "244728446c94483cb57c2620f12c9982");
        }

        void UnregisterManagers()
        {
            //FIXME
            //UpdateManager.Unregister();
        }

        protected override void OnPause()
        {
            base.OnPause();

            UnregisterManagers();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            UnregisterManagers();
        }
    }
}

