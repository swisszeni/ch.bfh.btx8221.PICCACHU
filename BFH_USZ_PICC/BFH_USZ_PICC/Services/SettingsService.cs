using Plugin.Settings;
using Plugin.Settings.Abstractions;

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

    }
}
