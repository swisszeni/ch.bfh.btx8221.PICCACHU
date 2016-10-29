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
using HockeyApp.Android;
using HockeyApp.Android.Metrics;

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
            CrashManager.Register(this, "244728446c94483cb57c2620f12c9982");
            MetricsManager.Register(Application, "244728446c94483cb57c2620f12c9982");

            // check for updates of the app
            CheckForUpdates();
        }

        void CheckForUpdates()
        {
            UpdateManager.Register(this, "244728446c94483cb57c2620f12c9982");
        }

        void UnregisterManagers()
        {
            UpdateManager.Unregister();
        }

        protected override void OnPause()
        {
            base.OnPause();
            UnregisterManagers();
        }

        protected override void OnDestroy()
        {   
            //FIXME Workaround to make sure the app does not crash after user has clicked on the notification
            try
            {
                base.OnDestroy();
                UnregisterManagers();

            }
            catch
            {

            }
        }
    }
}

