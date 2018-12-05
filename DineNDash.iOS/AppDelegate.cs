using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Prism;
using Prism.Ioc;
using Syncfusion.SfRating.XForms.iOS;
using UIKit;
using Google.Maps;
using UserNotifications;

namespace DineNDash.iOS
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
            //if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            //{
            //    // Ask the user for permission to get notifications on iOS 10.0+
            //    UNUserNotificationCenter.Current.RequestAuthorization(
            //            UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound,
            //            (approved, error) => { });
            //}
            //else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            //{
            //    // Ask the user for permission to get notifications on iOS 8.0+
            //    var settings = UIUserNotificationSettings.GetSettingsForTypes(
            //            UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
            //            new NSSet());

            //    UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            //}

            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                // Ask the user for permission to get notifications on iOS 10.0+
                UNUserNotificationCenter.Current.RequestAuthorization(
                    UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound,
                    (approved, error) => { });

                // Watch for notifications while app is active
                UNUserNotificationCenter.Current.Delegate = new UserNotificationCenterDelegate();
            }
            else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                // Ask the user for permission to get notifications on iOS 8.0+
                var settings = UIUserNotificationSettings.GetSettingsForTypes(
                    UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                    new NSSet());

                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            }

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDQ0MThAMzEzNjJlMzMyZTMwVjQ1SmIxRmRZYnBtK0Y0T2NVUG83czkwdTA5TmIreUhPZzd0ZVdBeTdRaz0=");

            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsMaps.Init();

            ZXing.Net.Mobile.Forms.iOS.Platform.Init();
            Xamarin.FormsGoogleMaps.Init("AIzaSyAmReieSp33ltXnORIKa4TM8GSnQUG1ZRA");
            Xamarin.FormsGoogleMapsBindings.Init();


            new SfRatingRenderer();

          
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);

         
        }
    }

    public class UserNotificationCenterDelegate : UNUserNotificationCenterDelegate
    {
        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            // Tell system to display the notification anyway or use
            // `None` to say we have handled the display locally.
            completionHandler(UNNotificationPresentationOptions.Alert);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
