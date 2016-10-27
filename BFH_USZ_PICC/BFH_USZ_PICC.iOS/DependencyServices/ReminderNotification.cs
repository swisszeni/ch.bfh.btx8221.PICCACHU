using System;
using Xamarin.Forms;
using BFH_USZ_PICC.Interfaces;
using UIKit;
using UserNotifications;
using Foundation;

[assembly: Dependency(typeof(BFH_USZ_PICC.iOS.DependencyServices.ReminderNotification))]

namespace BFH_USZ_PICC.iOS.DependencyServices
{
    public class ReminderNotification : Interfaces.IReminderNotification
    {
        public void AddNotification(DateTime maintenanceReminderStartDateAndTime, int maintenanceReminderRepetition)
        {
            //Initialize the registration
            UIApplication.SharedApplication.RegisterForRemoteNotifications();

            var content = new UNMutableNotificationContent();
            content.Title = "Information";
            content.Body = "Ihr PICC Katheter sollte gewartet werden.";
            content.Badge = 1;

            var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(5, false);

            var requestID = "test";
            var request = UNNotificationRequest.FromIdentifier(requestID, content, trigger);

            UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) =>
            {
                if (err != null)
                {
                    return;
                }
            });

        }

        public void RemoveAllNotifications()
        {
            return;

        }

        //private NSDateComponents DateTimeToNSDateComponents(DateTime date)
        //{
        //    DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(
        //        new DateTime(2001, 1, 1, 0, 0, 0));
        //    return NSDateComponents.FromTimeIntervalSinceReferenceDate(
        //        (date - reference).TotalSeconds);
        //}
    }
}
