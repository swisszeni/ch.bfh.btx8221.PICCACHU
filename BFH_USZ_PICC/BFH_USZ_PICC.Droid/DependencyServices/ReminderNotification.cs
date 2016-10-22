using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Droid.DependencyServices;
using Xamarin.Forms;
using Uri = Android.Net.Uri;
using Android.Telephony;

[assembly: Dependency(typeof(ReminderNotification))]

namespace BFH_USZ_PICC.Droid.DependencyServices
{
    public class ReminderNotification : IReminderNotification
    {
        void IReminderNotification.AddNotification(DateTime maintenanceReminderStartDate, TimeSpan maintenanceReminderDailyTime, int maintenanceReminderRepetition)
        {
            // Instantiate the builder and set notification elements:
            Notification.Builder builder = new Notification.Builder(Forms.Context);

            builder.SetContentTitle("Wartung fällig!");
            builder.SetContentText("Ihr PICC Katheter sollte gewartet werden.");
            builder.SetSmallIcon(Resource.Drawable.icon);
            builder.SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis());

            // Build the notification:
            Notification notification = builder.Build();


            // Get the notification manager:
            NotificationManager notificationManager = (Forms.Context.ApplicationContext.GetSystemService(Context.NotificationService) as NotificationManager);


            // Publish the notification:
            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);
        }

        void IReminderNotification.RemoveAllNotifications()
        {
           // throw new NotImplementedException();
        }
    }
}