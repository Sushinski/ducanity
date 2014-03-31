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
	[Register ("BasketTWCell")]
	partial class BasketTWCell
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView CheckBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton DelCheck { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel MealTxt { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel QtyTxt { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DelCheck != null) {
				DelCheck.Dispose ();
				DelCheck = null;
			}

			if (MealTxt != null) {
				MealTxt.Dispose ();
				MealTxt = null;
			}

			if (CheckBtn != null) {
				CheckBtn.Dispose ();
				CheckBtn = null;
			}

			if (QtyTxt != null) {
				QtyTxt.Dispose ();
				QtyTxt = null;
			}
		}
	}
}
