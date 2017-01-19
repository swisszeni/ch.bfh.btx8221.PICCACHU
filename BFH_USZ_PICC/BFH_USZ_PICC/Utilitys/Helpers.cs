using BFH_USZ_PICC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFH_USZ_PICC.Utilitys
{
    /// <summary>
    /// Helper class to transform platform culture strings
    /// </summary>
    public class PlatformCultureHelper
    {
        public PlatformCultureHelper(string platformCultureString)
        {
            if (String.IsNullOrEmpty(platformCultureString))
            {
                throw new ArgumentException("Expected culture identifier", nameof(platformCultureString));
            }
            // .NET expects dash, not underscore
            PlatformString = platformCultureString.Replace("_", "-");
            var dashIndex = PlatformString.IndexOf("-", StringComparison.Ordinal);
            if (dashIndex > 0)
            {
                var parts = PlatformString.Split('-');
                LanguageCode = parts[0];
                LocaleCode = parts[1];
            }
            else
            {
                LanguageCode = PlatformString;
                LocaleCode = "";
            }
        }
        public string PlatformString { get; private set; }
        public string LanguageCode { get; private set; }
        public string LocaleCode { get; private set; }
        public override string ToString()
        {
            return PlatformString;
        }
    }

    /// <summary>
    /// Helper class to centralize definition of App and Event IDs specific to HockeyApp
    /// </summary>
    public static class HockeyAppHelper
    {
        /// <summary>
        /// The different platformspecific App IDs of HockeyApp
        /// </summary>
        public static class AppIds
        {
            public const string HockeyAppId_iOS = "5f9acbf75fc1485dbc6fab3a278f5920";
            public const string HockeyAppId_Droid = "244728446c94483cb57c2620f12c9982";
            public const string HockeyAppId_UWP = "f06f141af5b041b7a0f90c9abf32449b";
        }

        /// <summary>
        /// The Event IDs for the Eventlogging og HockeyApp
        /// </summary>
        public static class Events
        {
            public const string JournalAdministredDrugEntryCreated = "User created Journal Entry Type AdministredDrug";
            public const string JournalBandageChangingEntryCreated = "User created Journal Entry Type BandageChanging";
            public const string JournalBloodWithdrawalEntryCreated = "User created Journal Entry Type BloodWithdrawal";
            public const string JournalCatheterFlushEntryCreated = "User created Journal Entry Type CatheterFlush";
            public const string JournalInfusionEntryCreated = "User created Journal Entry Type Infusion";
            public const string JournalMicroClaveChangingEntryCreated = "User created Journal Entry Type MicroClaveChanging";
            public const string JournalStatlockChangingEntryCreated = "User created Journal Entry Type StatlockChanging";

            public const string JournalDataExported = "User exported Journal Data";
        }

        /// <summary>
        /// Wrapper for tracking events. Only loggs when in deploy mode (unless specified other by the flag) and uses the correct version of the MetricsManager (depending on the OS).
        /// </summary>
        /// <param name="eventName">the constant to identify the event</param>
        public static void TrackEvent(string eventName)
        {
            if(Xamarin.Forms.Device.OS == Xamarin.Forms.TargetPlatform.Windows)
            {
                Xamarin.Forms.DependencyService.Get<IHockeyEventService>()?.TrackEvent(eventName);
            } else
            {
                HockeyApp.MetricsManager.TrackEvent(eventName);
            }
        }
    }

    /// <summary>
    /// Generic helper class to allow platform specific propertys in xaml
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class OnCustomPlatform<T>
    {
        public OnCustomPlatform()
        {
            Android = default(T);
            iOS = default(T);
            WinPhone = default(T);
            Windows = default(T);
            Other = default(T);
        }

        public T Android { get; set; }
        public T iOS { get; set; }
        public T WinPhone { get; set; }
        public T Windows { get; set; }
        public T Other { get; set; }

        public static implicit operator T(OnCustomPlatform<T> onPlatform)
        {
            switch (Xamarin.Forms.Device.OS)
            {
                case Xamarin.Forms.TargetPlatform.Android:
                    return onPlatform.Android;
                case Xamarin.Forms.TargetPlatform.iOS:
                    return onPlatform.iOS;
                case Xamarin.Forms.TargetPlatform.WinPhone:
                    return onPlatform.WinPhone;
                case Xamarin.Forms.TargetPlatform.Windows:
                    if (Xamarin.Forms.Device.Idiom == Xamarin.Forms.TargetIdiom.Desktop)
                        return onPlatform.Windows;
                    else
                        return onPlatform.WinPhone;
                default:
                    return onPlatform.Other;
            }
        }
    }
}
