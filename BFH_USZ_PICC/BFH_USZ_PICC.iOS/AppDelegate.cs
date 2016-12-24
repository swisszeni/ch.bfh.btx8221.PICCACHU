using System;
using System.Collections.Generic;
using System.Linq;
using UserNotifications;

using Foundation;
using UIKit;
using HockeyApp.iOS;
using BFH_USZ_PICC.Utilitys;
using GalaSoft.MvvmLight.Ioc;
using XLabs.Platform.Services;

namespace BFH_USZ_PICC.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            InitializeHockeyApp();
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new BFH_USZ_PICC.Application());

            // Request notification permissions from the user
            Xamarin.Forms.Device.BeginInvokeOnMainThread(RegisterNotificationTypes);

            // Register the platofrm specific service
            RegisterIOC();

            return base.FinishedLaunching(app, options);
        }

        /// <summary>
        /// Registering the platform specific parts of HockeyApp to track events and crashes.
        /// </summary>
        private void InitializeHockeyApp()
        {
            var manager = BITHockeyManager.SharedHockeyManager;
            manager.Configure(HockeyAppHelper.AppIds.HockeyAppId_iOS);
            manager.StartManager();
            manager.Authenticator.AuthenticateInstallation();
        }

        private void RegisterNotificationTypes()
        {
            // Use different approach for iOS 10 and newer... because Apple
            if(UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                // New 
                UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound, (approved, err) => {
                    // Handle approval
                    // What to do now?
                });
            } else
            {
                // Oldschool
                var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            }
        }

        private void RegisterIOC()
        {
            SimpleIoc.Default.Register<ISecureStorage, SecureStorage>();
        }
    }
}
