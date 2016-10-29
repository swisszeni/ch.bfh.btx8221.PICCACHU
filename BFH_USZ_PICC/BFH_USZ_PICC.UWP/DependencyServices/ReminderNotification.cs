using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.UWP.DependencyServices;
using Xamarin.Forms;
using System;
using Windows.UI.Notifications;
using System.Collections.Generic;
using Windows.Data.Xml.Dom;

[assembly: Dependency(typeof(ReminderNotification))]

namespace BFH_USZ_PICC.UWP.DependencyServices
{
    public class ReminderNotification : IReminderNotification
    {
        //Property to handle the planned notifications
        private ToastNotifier ToastNotifier = ToastNotificationManager.CreateToastNotifier();

        //List with all planned notifications
        private List<ScheduledToastNotification> plannedNotifications = new List<ScheduledToastNotification>();

        void IReminderNotification.AddNotification(DateTimeOffset maintenanceReminderStartDateTime, int dailyInterval, int maintenanceReminderRepetition, string title, string body)
        {
            ToastNotifier = ToastNotificationManager.CreateToastNotifier();

            XmlDocument toastXml = createToastXML(title, body);
            //local variable to check for how many weeks the user wants a notifications 
            int reminderRepetition = 0;

            //this loop checks how many reminder repetation the user wants to plan
            while (reminderRepetition <= maintenanceReminderRepetition)
            {
                DateTimeOffset notificationDateTime = maintenanceReminderStartDateTime.AddDays(reminderRepetition * dailyInterval);

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
        /// This function removes all scheduled notifications in the future 
        /// </summary>
        void IReminderNotification.RemoveAllNotifications()
        {
            if (plannedNotifications != null)
                foreach (var rem in plannedNotifications)
                {
                    ToastNotifier.RemoveFromSchedule(rem);
                }
            plannedNotifications.Clear();
            ToastNotifier = null;
        }

        /// <summary>
        /// Add all notifications from the list plannedNotifications to the scheduler
        /// </summary>
        private void addAllNotificationsToScheduler()
        {
            if (plannedNotifications != null)
                foreach (var rem in plannedNotifications)
                {
                    ToastNotifier.AddToSchedule(rem);
                }

        }

        private XmlDocument createToastXML(string title, string body)
        {
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
            toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode(title));
            toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode(body));
            Windows.Data.Xml.Dom.IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");

            return toastXml;
        }
    }
}

