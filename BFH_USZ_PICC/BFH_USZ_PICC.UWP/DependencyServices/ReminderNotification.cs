using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.UWP.DependencyServices;
using Xamarin.Forms;
using Windows.ApplicationModel.Calls;
using Windows.Foundation.Metadata;
using System;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using System.Collections.Generic;

[assembly: Dependency(typeof(ReminderNotification))]

namespace BFH_USZ_PICC.UWP.DependencyServices
{
    public class ReminderNotification : IReminderNotification
    {
        // Readonly property to extend the Notification for another week
        private readonly int WEEKLY = 7;

        //Property to handle the planned notifications
        private ToastNotifier toastnotifier = ToastNotificationManager.CreateToastNotifier();

        //List with all planned notifications
        private List<ScheduledToastNotification> plannedNotifications = new List<ScheduledToastNotification>();

        /// <summary>
        /// This function removes all scheduled notifications in the future 
        /// </summary>
        void IReminderNotification.RemoveAllNotifications()
        {
            if (plannedNotifications != null)
                foreach (var rem in plannedNotifications)
                {
                    toastnotifier.RemoveFromSchedule(rem);
                }
            plannedNotifications.Clear();
        }


        void IReminderNotification.AddNotification(DateTimeOffset maintenanceReminderStartDateTime, int maintenanceReminderRepetition)
        {
            ToastNotifier ToastNotifier = ToastNotificationManager.CreateToastNotifier();
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
            toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode("Wartung fällig!"));
            toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode("Ihr PICC Katheter sollte gewartet werden."));
            Windows.Data.Xml.Dom.IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");

            //local variable to check for how many weeks the user wants a notifications 
            int reminderRepetition = 0;

            //this loop checks how many reminder repetation the user wants to plan
            while (reminderRepetition <= maintenanceReminderRepetition)
            {
                DateTimeOffset notificationDateTime = maintenanceReminderStartDateTime.AddDays(reminderRepetition * WEEKLY);

                //Checks if the notification date time is in the future. If not, the notification can not be planned.
                if (notificationDateTime > DateTimeOffset.Now)
                {
                    var stn = new ScheduledToastNotification(toastXml, notificationDateTime);
                    plannedNotifications.Add(stn);
                }

                reminderRepetition++;
            }

            addAllNotificationsToScheduler();
        }

        /// <summary>
        /// Add all notifications from the list plannedNotifications to the scheduler
        /// </summary>
        private void addAllNotificationsToScheduler()
        {
            if (plannedNotifications != null)
                foreach (var rem in plannedNotifications)
                {
                    toastnotifier.AddToSchedule(rem);
                }

        }
    }
}

