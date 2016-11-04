using System;
using System.Collections.Generic;
using System.Linq;
using UserNotifications;

using Foundation;
using UIKit;
using HockeyApp.iOS;

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
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new BFH_USZ_PICC.Application());

            // Request notification permissions from the user
            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert, (approved, err) => {
                // Handle approval
                Xamarin.Forms.Device.BeginInvokeOnMainThread(registerNotificationTypes);
                
            });

            // Get current notification settings
            UNUserNotificationCenter.Current.GetNotificationSettings((settings) => {
                var alertsAllowed = (settings.AlertSetting == UNNotificationSetting.Enabled);
            });

            // Enable crashlog with HockeyApp
            var manager = BITHockeyManager.SharedHockeyManager;
            manager.Configure("5f9acbf75fc1485dbc6fab3a278f5920");
            manager.StartManager();
            manager.Authenticator.AuthenticateInstallation();
            return base.FinishedLaunching(app, options);
        }

        private void registerNotificationTypes()
        {
            var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
            UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
        }
    }
}
