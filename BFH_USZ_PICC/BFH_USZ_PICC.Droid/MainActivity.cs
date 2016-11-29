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
using BFH_USZ_PICC.Utilitys;

[assembly:MetaData("net.hockeyapp.android.appIdentifier", Value=HockeyAppHelper.AppIds.HockeyAppId_Droid)]

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
            InitializeHockeyApp();
            Forms.Init(this, bundle);
            LoadApplication(new Application());

            // check for updates of the app
            CheckForUpdates();
        }

        /// <summary>
        /// Registering the platform specific parts of HockeyApp to track events and crashes.
        /// </summary>
        private void InitializeHockeyApp()
        {
            CrashManager.Register(this);
            MetricsManager.Register(Application);
        }

        void CheckForUpdates()
        {
            UpdateManager.Register(this);
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

