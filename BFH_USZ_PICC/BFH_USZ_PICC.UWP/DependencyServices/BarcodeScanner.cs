using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.UWP.DependencyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Mobile;

[assembly: Xamarin.Forms.Dependency(typeof(BarcodeScanner))]

namespace BFH_USZ_PICC.UWP.DependencyServices
{
    class BarcodeScanner : IBarcodeScanner
    {
        public async Task<string> StringFromBarcode()
        {   //FIXME: Implement proper back navigation stack handling. (So back button dismisses scanner view)

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
