using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.UWP.DependencyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly:Dependency(typeof(HockeyEventService_UWP))]

namespace BFH_USZ_PICC.UWP.DependencyServices
{
    public class HockeyEventService_UWP : IHockeyEventService
    {
        public void TrackEvent(string eventName)
        {
            Microsoft.HockeyApp.HockeyClient.Current.TrackEvent(eventName);
        }
    }
}
