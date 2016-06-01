using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.UWP.DependencyServices;
using Xamarin.Forms;
using Windows.ApplicationModel.Calls;
using Windows.Foundation.Metadata;
using System;

[assembly: Dependency(typeof(Caller))]

namespace BFH_USZ_PICC.UWP.DependencyServices
{
    public class Caller : ICaller
    {
        public bool CanMakePhonecall()
        {
            if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.Calls.CallsPhoneContract", 1, 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Dial(string number)
        {
            PhoneCallManager.ShowPhoneCallUI("0795860247", "USZ Telemedizin");
            return true;
        }
    }
}
