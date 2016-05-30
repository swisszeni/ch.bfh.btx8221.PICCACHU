using BFH_USZ_PICC.iOS.DependencyServices;
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
        public bool Dial(string number)
        {
            return UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + number));
        }
    }
}
