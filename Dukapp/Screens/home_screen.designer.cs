// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Dukapp
{
	[Register ("home_screen")]
	partial class home_screen
	{
		[Outlet]
		MonoTouch.UIKit.UIButton RulesBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ScheduleBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton MealsBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton RecipesBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton GuidanceBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton BasketBtn { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
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

			if (RecipesBtn != null) {
				RecipesBtn.Dispose ();
				RecipesBtn = null;
			}

			if (GuidanceBtn != null) {
				GuidanceBtn.Dispose ();
				GuidanceBtn = null;
			}

			if (BasketBtn != null) {
				BasketBtn.Dispose ();
				BasketBtn = null;
			}
		}
	}
}
