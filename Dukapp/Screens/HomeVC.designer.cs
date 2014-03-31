// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Dukapp
{
	[Register ("HomeVC")]
	partial class HomeVC
	{
		[Outlet]
		MonoTouch.UIKit.UIButton BasketBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton GuidanceBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton MealsBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton RecBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton RulesBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ScheduleBtn { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BasketBtn != null) {
				BasketBtn.Dispose ();
				BasketBtn = null;
			}

			if (RecBtn != null) {
				RecBtn.Dispose ();
				RecBtn = null;
			}

			if (GuidanceBtn != null) {
				GuidanceBtn.Dispose ();
				GuidanceBtn = null;
			}

			if (RulesBtn != null) {
				RulesBtn.Dispose ();
				RulesBtn = null;
			}

			if (ScheduleBtn != null) {
				ScheduleBtn.Dispose ();
				ScheduleBtn = null;
			}

			if (MealsBtn != null) {
				MealsBtn.Dispose ();
				MealsBtn = null;
			}
		}
	}
}
