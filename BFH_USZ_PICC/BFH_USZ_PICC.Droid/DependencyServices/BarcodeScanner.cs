using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BFH_USZ_PICC.Interfaces;
using ZXing.Mobile;
using BFH_USZ_PICC.Droid.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(BarcodeScanner))]

namespace BFH_USZ_PICC.Droid.DependencyServices
{
    class BarcodeScanner : IBarcodeScanner
    {
        public async Task<string> StringFromBarcode()
        {
            // Creates a new MobileBarcodeScanner variable
            MobileBarcodeScanner scanner = new MobileBarcodeScanner();

            var result = await scanner.Scan();
            if (result != null)
            {
                return result.Text;
            }

            return null;
        }
    }
}