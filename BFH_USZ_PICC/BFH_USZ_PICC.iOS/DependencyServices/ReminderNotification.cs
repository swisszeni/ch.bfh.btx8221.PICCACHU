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
        public void AddNotification(DateTimeOffset maintenanceReminderStartDateTime, int maintenanceReminderRepetition)
        {
            UILocalNotification noti = new UILocalNotification();
            noti.FireDate = NSDate.FromTimeIntervalSinceNow(10);
            noti.AlertAction = "Information";
            noti.AlertBody = "Ihr PICC Katheter sollte gewartet werden.";
            UIApplication.SharedApplication.ScheduleLocalNotification(noti);
            //var content = new UNMutableNotificationContent();
            //content.Title = "Information";
            //content.Body = "Ihr PICC Katheter sollte gewartet werden.";
            //content.Badge = 1;

            //NSDateComponents notificationTime = new NSDateComponents();
            //notificationTime.TimeZone = NSTimeZone.FromAbbreviation("UTC");
            //notificationTime.Month = maintenanceReminderStartDateTime.Month;
            //notificationTime.Day = maintenanceReminderStartDateTime.Day;
            //notificationTime.Hour = maintenanceReminderStartDateTime.Hour;
            //notificationTime.Minute = maintenanceReminderStartDateTime.Minute;


            //  int epochTimedStartTime = maintenanceReminderStartDateAndTime.ToUniversalTime().Millisecond;

            //var nsDate = DateTimeToNSDate(maintenanceReminderStartDateAndTime);

            //var calendar = new NSCalendar(NSCalendarType.Gregorian);
            //calendar.componen
            //var date = (NSDate)maintenanceReminderStartDateAndTime;
            //var ptr = Messaging.IntPtr_objc_msgSend_UInt32_IntPtr(calendar.Handle, Selector.GetHandle("components:fromDate:"), (uint)(NSCalendarUnit.Year | NSCalendarUnit.Month), date.Handle);
            //var comps = new NSDateComponents(ptr);

            //   date.Date = maintenanceReminderStartDateAndTime;
            ////   date.Year = maon;
            //   date.Month = maintenanceReminderStartDateAndTime.Month;
            //   date.Day = maintenanceReminderStartDateAndTime.Day;
            //   date.Hour = maintenanceReminderStartDateAndTime.Hour;
            //   date.Minute = maintenanceReminderStartDateAndTime.Minute;

            //// var trigger = UNCalendarNotificationTrigger.CreateTrigger(notificationTime, false);
            //var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(5, false);

            //var requestID = "test";
            //var request = UNNotificationRequest.FromIdentifier(requestID, content, trigger);

            // Get current notification settings
            //UNUserNotificationCenter.Current.GetNotificationSettings((settings) => {
            //    var alertsAllowed = (settings.AlertSetting == UNNotificationSetting.Enabled);
            //});

            //UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) =>
            //{
            //    if (err != null)
            //    {
            //        return;
            //    }
            //});

        }

        public void RemoveAllNotifications()
        {
          //  UIApplication.SharedApplication.CancelLocalNotification();

        }

        private NSDate DateTimeToNSDate(DateTime date)
        {
            DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(
                new DateTime(2001, 1, 1, 0, 0, 0));
            return NSDate.FromTimeIntervalSinceReferenceDate(
                (date - reference).TotalSeconds);
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
