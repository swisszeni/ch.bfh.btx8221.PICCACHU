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

namespace BFH_USZ_PICC.Droid
{
    [Activity(Label = "USZ PICC", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity  // was FormsApplicationActivity
    {
        //protected override void OnCreate(Bundle bundle)
        //{
        //    base.OnCreate(bundle);

        //    global::Xamarin.Forms.Forms.Init(this, bundle);
        //    LoadApplication(new App());

        //    if ((int)Android.OS.Build.VERSION.SdkInt >= 21)
        //    {
        //        ActionBar.SetIcon(
        //          new ColorDrawable(Resources.GetColor(Android.Resource.Color.Transparent)));
        //    }
        //}

        protected override void OnCreate(Bundle bundle)
        {
            //FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
            //FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;
            base.OnCreate(bundle);
            Forms.Init(this, bundle);
            LoadApplication(new App());


        }
    }
}

