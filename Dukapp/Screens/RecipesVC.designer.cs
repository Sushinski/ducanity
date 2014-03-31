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
	[Register ("RecipesVC")]
	partial class RecipesVC
	{
		[Outlet]
		MonoTouch.UIKit.UIButton OnBakeryBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OnDrinksBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OnFavoritesBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OnFirstCoursesBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OnHomeBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OnSaladsBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OnSaucesBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OnSecondCoursesBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OnSnacksBtn { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (OnFavoritesBtn != null) {
				OnFavoritesBtn.Dispose ();
				OnFavoritesBtn = null;
			}

			if (OnFirstCoursesBtn != null) {
				OnFirstCoursesBtn.Dispose ();
				OnFirstCoursesBtn = null;
			}

			if (OnHomeBtn != null) {
				OnHomeBtn.Dispose ();
				OnHomeBtn = null;
			}

			if (OnSaladsBtn != null) {
				OnSaladsBtn.Dispose ();
				OnSaladsBtn = null;
			}

			if (OnSecondCoursesBtn != null) {
				OnSecondCoursesBtn.Dispose ();
				OnSecondCoursesBtn = null;
			}

			if (OnSnacksBtn != null) {
				OnSnacksBtn.Dispose ();
				OnSnacksBtn = null;
			}

			if (OnBakeryBtn != null) {
				OnBakeryBtn.Dispose ();
				OnBakeryBtn = null;
			}

			if (OnDrinksBtn != null) {
				OnDrinksBtn.Dispose ();
				OnDrinksBtn = null;
			}

			if (OnSaucesBtn != null) {
				OnSaucesBtn.Dispose ();
				OnSaucesBtn = null;
			}
		}
	}
}
