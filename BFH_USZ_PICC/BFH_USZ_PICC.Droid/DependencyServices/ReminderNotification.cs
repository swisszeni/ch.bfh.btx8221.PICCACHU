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
using Android.App;

[assembly: Dependency(typeof(ReminderNotification))]

namespace BFH_USZ_PICC.Droid.DependencyServices
{
    public class ReminderNotification : IReminderNotification
    {
        AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);
        Intent alarmIntent = new Intent(Forms.Context, typeof(AlarmReceiver));
        PendingIntent pendingIntent;

        void IReminderNotification.AddNotification(DateTime maintenanceReminderStartDate, TimeSpan maintenanceReminderDailyTime, int maintenanceReminderRepetition)
        {   
            createNotification();

            // time when the first notification should appear. Wihtin the loop, the time will be raised weekly.
            var reminderTime = maintenanceReminderStartDate - DateTime.Now + maintenanceReminderDailyTime;

            int reminderRepetition = 0;

            int millisecondsInOneWeek = 604800000;

            //this loop checks how many reminder repetation the user wants to plan
            while (reminderRepetition <= maintenanceReminderRepetition)
            {
                alarmManager.Set(AlarmType.ElapsedRealtimeWakeup, (reminderTime.Ticks + Convert.ToInt64(millisecondsInOneWeek * reminderRepetition)), pendingIntent);
                reminderRepetition++;
            }
        }

        void IReminderNotification.RemoveAllNotifications()
        {
            if (alarmManager.NextAlarmClock != null)
            {
                alarmManager.Cancel(pendingIntent);
            }
        }

        /// <summary>
        /// Create a notification pattern with the needed text to inform the user about the PICC maintenance.
        /// </summary>
        private void createNotification()
        {
            alarmIntent = new Intent(Forms.Context, typeof(AlarmReceiver));
            alarmIntent.PutExtra("message", "Wartung fällig!");
            alarmIntent.PutExtra("title", "Ihr PICC Katheter sollte gewartet werden.");
            pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
            alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);
        }

        //FIXME: Erste einfache Version für Notification, Nur Test!!!!
        // Instantiate the builder and set notification elements:
        //Notification.Builder builder = new Notification.Builder(Forms.Context);

        //builder.SetContentTitle("Wartung fällig!");
        //builder.SetContentText("Ihr PICC Katheter sollte gewartet werden.");
        //builder.SetSmallIcon(Resource.Drawable.icon);
        //builder.SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis());

        //// Build the notification:
        //Notification notification = builder.Build();


        //// Get the notification manager:
        //NotificationManager notificationManager = (Forms.Context.ApplicationContext.GetSystemService(Context.NotificationService) as NotificationManager);


        //// Publish the notification:
        //const int notificationId = 0;
        //notificationManager.Notify(notificationId, notification);
    }
}