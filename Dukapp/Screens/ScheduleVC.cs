using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;


namespace Dukapp
{
	public partial class ScheduleVC : UITabBarController
	{
		UIViewController cal_tab, chart_tab, pref_tab;


		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public ScheduleVC ()
			: base (UserInterfaceIdiomIsPhone ? "ScheduleVC_iPhone" : "ScheduleVC_iPad", null)
		{
			this.Title = "Schedule";
			this.View.Bounds = UIScreen.MainScreen.Bounds;
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			cal_tab = new CalendarTabVC ();
			cal_tab.Title = "Calendar";
			chart_tab = new ChartTabVC ();
			chart_tab.Title = "WeightChart";
			pref_tab = new InAppPrefsVC ();
			pref_tab.Title = "Preferencies";

			var tabs = new UIViewController[] { cal_tab, chart_tab, pref_tab };
			ViewControllers = tabs;
			SelectedViewController = cal_tab;

			cal_tab.TabBarItem = new UITabBarItem (UITabBarSystemItem.History, 0);
			chart_tab.TabBarItem = new UITabBarItem (UITabBarSystemItem.MostRecent, 1);
			pref_tab.TabBarItem = new UITabBarItem (UITabBarSystemItem.More, 2);

		}


	}

}

