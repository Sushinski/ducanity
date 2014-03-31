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
	[Register ("MealTWCell")]
	partial class MealTWCell
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView AddToBasketBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel CellLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel CellQty { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AddToBasketBtn != null) {
				AddToBasketBtn.Dispose ();
				AddToBasketBtn = null;
			}

			if (CellQty != null) {
				CellQty.Dispose ();
				CellQty = null;
			}

			if (CellLabel != null) {
				CellLabel.Dispose ();
				CellLabel = null;
			}
		}
	}
}
