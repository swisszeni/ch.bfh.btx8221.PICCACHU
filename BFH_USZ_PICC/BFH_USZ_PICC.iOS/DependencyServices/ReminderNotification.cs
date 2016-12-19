using System;
using Xamarin.Forms;
using UIKit;
using Foundation;
using System.Collections.Generic;

[assembly: Dependency(typeof(BFH_USZ_PICC.iOS.DependencyServices.ReminderNotification))]

namespace BFH_USZ_PICC.iOS.DependencyServices
{
    public class ReminderNotification : Interfaces.IReminderNotification
    {
        string Body;
        readonly double DAILYSECONDS = 84400;

        public void AddNotification(DateTimeOffset maintenanceReminderStartDateTime, int intervalInDays, int maintenanceReminderRepetition, string title, string body, bool isUnlimited)
        {   
            UILocalNotification noti = new UILocalNotification();                      
            noti.AlertTitle = title;
            noti.AlertBody = body;
            noti.AlertLaunchImage = "Icon.png";

            NSDate startDateTime = DateTimeToNSDate(maintenanceReminderStartDateTime);
            
            double reminderIntervalInSeconds = DAILYSECONDS * intervalInDays;

            // Checks if the user wants a to set a repetition limit or if he wants an unlimited reminder. In this case, the 500 notifications will be generated.
            if (isUnlimited)
            {
                int repetitionFor200Times = 200;
                addNotificationsToScheduler(startDateTime, repetitionFor200Times, reminderIntervalInSeconds, noti);

            }
            else
            {
                addNotificationsToScheduler(startDateTime, maintenanceReminderRepetition, reminderIntervalInSeconds, noti);
            }

            //Saves the reminder body in order to detect future scheduled notifications for deleting
            Body = body;

        }
                
        public void RemoveAllNotifications()
        {
            UILocalNotification[] futureNotifications = UIApplication.SharedApplication.ScheduledLocalNotifications;

            foreach(var noti in futureNotifications)
            {
                if(noti.AlertBody == Body)
                {
                    UIApplication.SharedApplication.CancelLocalNotification(noti);
                }               
            }          

        }

        private void addNotificationsToScheduler(NSDate startDateTime, int maintenanceReminderRepetition, double reminderIntervalInSeconds, UILocalNotification noti) {
            int countReminderRepetitions = 0;

            while (countReminderRepetitions < maintenanceReminderRepetition)
            {
                noti.FireDate = startDateTime.AddSeconds(countReminderRepetitions * reminderIntervalInSeconds);
                UIApplication.SharedApplication.ScheduleLocalNotification(noti);

                countReminderRepetitions++;
            }
        }

        private NSDate DateTimeToNSDate(DateTimeOffset date)
        {
            DateTimeOffset reference = TimeZone.CurrentTimeZone.ToLocalTime(
                new DateTime(2001, 1, 1, 0, 0, 0));
            return NSDate.FromTimeIntervalSinceReferenceDate(
                (date - reference).TotalSeconds);
        }
    }
}


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


//private NSDateComponents DateTimeToNSDateComponents(DateTime date)
//{
//    DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(
//        new DateTime(2001, 1, 1, 0, 0, 0));
//    return NSDateComponents.FromTimeIntervalSinceReferenceDate(
//        (date - reference).TotalSeconds);
//}