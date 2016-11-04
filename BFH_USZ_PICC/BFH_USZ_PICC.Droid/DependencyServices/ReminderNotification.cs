using System;
using Android.App;
using Android.Content;
using Android.OS;
using BFH_USZ_PICC.Interfaces;
using BFH_USZ_PICC.Droid.DependencyServices;
using Xamarin.Forms;
using System.Collections.Generic;

[assembly: Dependency(typeof(ReminderNotification))]

namespace BFH_USZ_PICC.Droid.DependencyServices
{
    public class ReminderNotification : IReminderNotification
    {
        AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);
        List<PendingIntent> pendingIntents;

        void IReminderNotification.AddNotification(DateTimeOffset maintenanceReminderStartDateTime, int dailyInterval, int maintenanceReminderRepetition, string title, string body)
        {
            pendingIntents = new List<PendingIntent>();

            // time when the first notification should appear from now on (if time is in the past, the notification will be fired immediately). 
            TimeSpan reminderTime = maintenanceReminderStartDateTime - DateTimeOffset.Now;
            
            int dailyMiliseconds = 86400000;
            long intervalInMiliseconds = dailyMiliseconds * dailyInterval;

            long currentReminderTime = SystemClock.ElapsedRealtime() + (long)reminderTime.TotalMilliseconds;
             
            int countReminderRepetitions = 0;
            while (countReminderRepetitions <= maintenanceReminderRepetition)
            {
                PendingIntent intent = createPendingIntent(title, body, countReminderRepetitions);
              
                //FIXME Android schedules the repeating forever (not just accoridng to maintenanceReminderRepetition, because a loop with alarmManager.SetRepeating creates only one repeating (and not serveral repeatings as expected).
                //alarmManager.SetInexactRepeating(AlarmType.ElapsedRealtimeWakeup, SystemClock.ElapsedRealtime() + (long)reminderTime.TotalMilliseconds, (dailyMiliseconds * dailyInterval), intent);
                alarmManager.Set(AlarmType.ElapsedRealtimeWakeup, SystemClock.ElapsedRealtime() + (long)reminderTime.TotalMilliseconds + (countReminderRepetitions * intervalInMiliseconds), intent);
                
                pendingIntents.Add(intent); 
                              
                countReminderRepetitions++;
            }                          
        }

        void IReminderNotification.RemoveAllNotifications()
        {
            if (pendingIntents != null)
            {
                foreach (var intent in pendingIntents)
                {
                    alarmManager.Cancel(intent);
                }
                pendingIntents = null;
            }
        }

        /// <summary>
        /// Create a notification pattern with the needed text to inform the user about the PICC maintenance.
        /// </summary>
        private PendingIntent createPendingIntent(string title, string body, int id)
        {
            Intent alarmIntent = new Intent(Forms.Context, typeof(AlarmReceiver));
            alarmIntent.PutExtra("message", body);
            alarmIntent.PutExtra("title", title);
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(Forms.Context, id, alarmIntent, PendingIntentFlags.UpdateCurrent);

            return pendingIntent;
        }
    }
}