using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.iOS.DependencyServices;
using CoreTelephony;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using UserNotifications;
using Xamarin.Forms;


[assembly: Dependency(typeof(IReminderNotification))]

namespace BFH_USZ_PICC.iOS.DependencyServices
{
    public class ReminderNotification : Interfaces.IReminderNotification
    {
        public void AddNotification(DateTime maintenanceReminderStartDate, TimeSpan maintenanceReminderDailyTime, int maintenanceReminderRepetition)
        {
            return;
        }

        public void RemoveAllNotifications()
        {
            return;// throw new NotImplementedException();
        }
    }
}
