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
	[Register ("BasketVC")]
	partial class BasketVC
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView BasketSubtitleImg { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView BasketTitleImg { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OnBackBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OnClearBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OnHomeBtn { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BasketSubtitleImg != null) {
				BasketSubtitleImg.Dispose ();
				BasketSubtitleImg = null;
			}

			if (BasketTitleImg != null) {
				BasketTitleImg.Dispose ();
				BasketTitleImg = null;
			}

			if (OnBackBtn != null) {
				OnBackBtn.Dispose ();
				OnBackBtn = null;
			}

			if (OnClearBtn != null) {
				OnClearBtn.Dispose ();
				OnClearBtn = null;
			}

			if (OnHomeBtn != null) {
				OnHomeBtn.Dispose ();
				OnHomeBtn = null;
			}
		}
	}
}
