using BFH_USZ_PICC.iOS.DependencyServices;
using CoreTelephony;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;


[assembly: Dependency(typeof(Caller))]

namespace BFH_USZ_PICC.iOS.DependencyServices
{
    public class Caller : Interfaces.ICaller
    {
        public bool CanMakePhonecall()
        {
            if (UIApplication.SharedApplication.CanOpenUrl(new NSUrl("tel://")))
            {
                CTTelephonyNetworkInfo netInfo = new CTTelephonyNetworkInfo();
                string mnc =  netInfo.SubscriberCellularProvider.MobileNetworkCode;
                return !(mnc.Length == 0 || mnc == "65535");
            }
            else { return false; }
        }

        public bool Dial(string number)
        {
            return UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + number));
        }
    }
}
