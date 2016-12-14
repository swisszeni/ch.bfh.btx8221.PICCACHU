using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

namespace BFH_USZ_PICC.Droid
{
    [Activity(Label = "@string/app_name", MainLauncher = true, NoHistory = true, Theme = "@style/MyTheme.Splash", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}