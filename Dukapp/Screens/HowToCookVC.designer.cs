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
	[Register ("HowToCookVC")]
	partial class HowToCookVC
	{
		[Outlet]
		MonoTouch.UIKit.UIButton AtckBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ConsolidBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton CruiseBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView HowToCookTxt { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OnAddToFavBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OnBackBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OnHomeBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel RecipeNameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton StabBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView SubTitleImageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView TitleImageView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TitleImageView != null) {
				TitleImageView.Dispose ();
				TitleImageView = null;
			}

			if (HowToCookTxt != null) {
				HowToCookTxt.Dispose ();
				HowToCookTxt = null;
			}

			if (OnBackBtn != null) {
				OnBackBtn.Dispose ();
				OnBackBtn = null;
			}

			if (OnHomeBtn != null) {
				OnHomeBtn.Dispose ();
				OnHomeBtn = null;
			}

			if (OnAddToFavBtn != null) {
				OnAddToFavBtn.Dispose ();
				OnAddToFavBtn = null;
			}

			if (AtckBtn != null) {
				AtckBtn.Dispose ();
				AtckBtn = null;
			}

			if (RecipeNameLabel != null) {
				RecipeNameLabel.Dispose ();
				RecipeNameLabel = null;
			}

			if (SubTitleImageView != null) {
				SubTitleImageView.Dispose ();
				SubTitleImageView = null;
			}

			if (CruiseBtn != null) {
				CruiseBtn.Dispose ();
				CruiseBtn = null;
			}

			if (ConsolidBtn != null) {
				ConsolidBtn.Dispose ();
				ConsolidBtn = null;
			}

			if (StabBtn != null) {
				StabBtn.Dispose ();
				StabBtn = null;
			}
		}
	}
}
