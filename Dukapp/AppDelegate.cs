using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.IO;
using DukappCore.BL.Managers;
using DukappCore.BL.Records;

namespace Dukapp
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		WelcomeVC welcome_scr;
		HomeVC home_scr; 
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// Copy the database across (if it doesn't exist)
			var appdir = NSBundle.MainBundle.ResourcePath;
			var seedFile = Path.Combine (appdir, "Base/DukappDB.db3");
			if (!File.Exists (DukappCore.DAL.DukappRepository.DatabaseFilePath))
				File.Copy (seedFile, DukappCore.DAL.DukappRepository.DatabaseFilePath);
			// create a new window instance based on the screen size
            DukappCore.DAL.DukappRepository.Open();
            RectangleF mrect = UIScreen.MainScreen.Bounds;
            window = new UIWindow (mrect);
            home_scr = new HomeVC ();
            RectangleF rct = home_scr.View.Bounds;
            var rootNavigationController = new UINavigationController ();
            rootNavigationController.NavigationBarHidden = true;
            rootNavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
            rootNavigationController.PushViewController(home_scr, true);
            window.RootViewController = rootNavigationController;

            app.SetStatusBarStyle (UIStatusBarStyle.LightContent, true);
            // window.RootViewController = home_scr;
			// make the window visible
			window.MakeKeyAndVisible ();
			PrefsRecord rec = PrefsManager.GetPrefsRecordValue("isDietStarted");
			if ( rec.PrefValue == "0" )
			{
				welcome_scr = new WelcomeVC ( home_scr );
				//rootNavigationController.PushViewController(welcome_scr, true);
				home_scr.PresentViewController (welcome_scr, true, null); 
			}
			return true;
		}

        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            // show an alert
            new UIAlertView(notification.AlertAction, notification.AlertBody,null, "OK", null).Show();
            // reset our badge
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        }

        public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {
            //new UIAlertView(notification.AlertAction, notification.AlertBody,null, "OK", null).Show();
            // reset our badge
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        }
	}
}

