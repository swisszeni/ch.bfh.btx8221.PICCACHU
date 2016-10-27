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
using Android.Icu.Util;

[assembly: Dependency(typeof(ReminderNotification))]

namespace BFH_USZ_PICC.Droid.DependencyServices
{
    public class ReminderNotification : IReminderNotification
    {
        AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);
        Intent alarmIntent = new Intent(Forms.Context, typeof(AlarmReceiver));
        PendingIntent pendingIntent;

        void IReminderNotification.AddNotification(DateTime maintenanceReminderStartDateAndTime, int maintenanceReminderRepetition)
        {   
            createNotification();

            // time when the first notification should appear from now on (if time is in the past, the notification will be fired immediately). 
            TimeSpan reminderTime = maintenanceReminderStartDateAndTime - DateTime.Now;
                    
            //Contains the miliseconds of one week, so the notification can be scheduled weekly    
            long weekly = AlarmManager.IntervalDay * 7;

            alarmManager.SetInexactRepeating(AlarmType.ElapsedRealtimeWakeup, SystemClock.ElapsedRealtime() + (long)reminderTime.TotalMilliseconds, weekly, pendingIntent);
            
            //int reminderRepetition = 0;
            //long millisecondsInOneWeek = 604800000;
            //this loop checks how many reminder repetation the user wants to plan
            //while (reminderRepetition <= maintenanceReminderRepetition)
            //{
            //    alarmManager.Set(AlarmType.ElapsedRealtimeWakeup, SystemClock.ElapsedRealtime() + (long)reminderTime.TotalMilliseconds + Convert.ToInt64(millisecondsInOneWeek * reminderRepetition), pendingIntent);
            //    alarmManager.SetInexactRepeating(AlarmType.ElapsedRealtimeWakeup, SystemClock.ElapsedRealtime() + (long)reminderTime.TotalMilliseconds, weekly, pendingIntent);

            //    reminderRepetition++;
            //}
        }

        void IReminderNotification.RemoveAllNotifications()
        {
            if (alarmManager != null || alarmManager.NextAlarmClock != null)
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
    }
}