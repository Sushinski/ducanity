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
	[Register ("RulesVC")]
	partial class RulesVC
	{
		[Outlet]
		MonoTouch.UIKit.UIButton AttackBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ConsBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton CruiseBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton DietBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton StabBtn { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DietBtn != null) {
				DietBtn.Dispose ();
				DietBtn = null;
			}

			if (AttackBtn != null) {
				AttackBtn.Dispose ();
				AttackBtn = null;
			}

			if (CruiseBtn != null) {
				CruiseBtn.Dispose ();
				CruiseBtn = null;
			}

			if (ConsBtn != null) {
				ConsBtn.Dispose ();
				ConsBtn = null;
			}

			if (StabBtn != null) {
				StabBtn.Dispose ();
				StabBtn = null;
			}
		}
	}
}
