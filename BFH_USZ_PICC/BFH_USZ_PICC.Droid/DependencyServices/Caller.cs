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
using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Droid.DependencyServices;
using Xamarin.Forms;
using Uri = Android.Net.Uri;
using Android.Telephony;

[assembly: Dependency(typeof(Caller))]

namespace BFH_USZ_PICC.Droid.DependencyServices
{
    public class Caller : ICaller
    {
        public bool Dial(string number)
        {
            var context = Forms.Context;
            if (context == null)
                return false;

            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Uri.Parse("tel:" + number));

            if (IsIntentAvailable(context, intent))
            {
                context.StartActivity(intent);
                return true;
            }

            return false;
        }
        public static bool IsIntentAvailable(Context context, Intent intent)
        {
            var packageManager = context.PackageManager;

            var list = packageManager.QueryIntentServices(intent, 0)
                .Union(packageManager.QueryIntentActivities(intent, 0));

            if (list.Any())
                return true;

            var manager = TelephonyManager.FromContext(context);
            return manager.PhoneType != PhoneType.None;
        }

        public bool CanMakePhonecall()
        {
            TelephonyManager manager = (TelephonyManager)Forms.Context.GetSystemService(Android.Content.Context.TelephonyService);

            return !(manager.PhoneType == PhoneType.None);
        }
    }
}