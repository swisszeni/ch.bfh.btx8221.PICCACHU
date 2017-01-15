using System;
using Xamarin.Forms;
using UIKit;
using Foundation;
using System.Collections.Generic;

[assembly: Dependency(typeof(BFH_USZ_PICC.iOS.DependencyServices.ReminderNotification_iOS))]

namespace BFH_USZ_PICC.iOS.DependencyServices
{
    public class ReminderNotification_iOS : Interfaces.IReminderNotification
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

            // Checks if the user wants a to set a repetition limit or if he wants an unlimited reminder. In this case, 200 notifications will be generated.
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
            DateTimeOffset referenceDate = new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTimeOffset requestedDate = date.ToUniversalTime();

            return NSDate.FromTimeIntervalSinceReferenceDate(
                requestedDate.Subtract(referenceDate).TotalSeconds);
        }
    }
}