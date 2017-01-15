using BFH_USZ_PICC.Models;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace BFH_USZ_PICC.Services
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public class SettingsService
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string FirstAppExecutionKey = "first_app_execution";
        private static readonly bool FirstAppExecutionDefault = true;

        private const string ReminderStartDateTimeKey = "reminderstart_Date_Time";
        private static readonly DateTime ReminderStartDateTimeDefault = DateTime.Now;

        private const string ReminderFrequencyKey = "reminder_frequency";
        private static readonly int ReminderFrequencyDefault = 6;

        private const string ReminderRepetitionKey = "reminder_repetition";
        private static readonly int ReminderRepetitionDefault= 0;

        private const string IsReminderSetKey = "is_reminder_set";
        private static readonly bool IsReminderSetDefault = false;


        #endregion


        public static bool FirstAppExecution
        {
            get
            {
                return AppSettings.GetValueOrDefault<bool>(FirstAppExecutionKey, FirstAppExecutionDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<bool>(FirstAppExecutionKey, value);
            }
        }
       
        
        public static DateTime ReminderStartDateTime
        {
            get
            {
                return AppSettings.GetValueOrDefault<DateTime>(ReminderStartDateTimeKey, ReminderStartDateTimeDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<DateTime>(ReminderStartDateTimeKey, value);
            }
        }

        public static int ReminderFrequency
        {
            get
            {
                return AppSettings.GetValueOrDefault<int>(ReminderFrequencyKey, ReminderFrequencyDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<int>(ReminderFrequencyKey, value);
            }
        }

        public static int ReminderRepetition
        {
            get
            {
                return AppSettings.GetValueOrDefault<int>(ReminderRepetitionKey, ReminderRepetitionDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<int>(ReminderRepetitionKey, value);
            }
        }

        public static bool IsReminderSet
        {
            get
            {
                return AppSettings.GetValueOrDefault<bool>(IsReminderSetKey, IsReminderSetDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<bool>(IsReminderSetKey, value);
            }
        }
    }
}
