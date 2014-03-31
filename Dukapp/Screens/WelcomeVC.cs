using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Dukapp
{

	public partial class WelcomeVC : UIViewController
	{


		PrefsVC prefs_scr;
		UIViewController m_parent_vc;
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public WelcomeVC ( UIViewController parent=null )
			: base (UserInterfaceIdiomIsPhone ? "WelcomeVC_iPhone" : "WelcomeVC_iPad", null)
		{
			m_parent_vc = parent;
			//NavigationItem.Title = "Dukapp"; 
			this.Title = "Dukapp Welcome";
			//this.Title = "Dukapp";
			//this.View.Bounds = UIScreen.MainScreen.Bounds;

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
			
			this.Welcome_okay.TouchUpInside += (sender, e) => {

				DismissViewController(true, null);

			};

		}
		public override void ViewDidDisappear (bool animated){
			base.ViewDidDisappear (animated);
			if (m_parent_vc != null) {
				if(prefs_scr == null)
					prefs_scr = new PrefsVC ();
				//this.NavigationController.PushViewController (prefs_scr, true);
				m_parent_vc.PresentViewController (prefs_scr, true, null);
			}
		}

	}
}

