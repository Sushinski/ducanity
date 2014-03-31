// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Dukapp
{
	[Register ("PrefsVC")]
	partial class PrefsVC
	{
		[Outlet]
		MonoTouch.UIKit.UITextField AtackTF { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField DesireWeightTF { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem OkayBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField YourWeightTF { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (OkayBtn != null) {
				OkayBtn.Dispose ();
				OkayBtn = null;
			}

			if (AtackTF != null) {
				AtackTF.Dispose ();
				AtackTF = null;
			}

			if (DesireWeightTF != null) {
				DesireWeightTF.Dispose ();
				DesireWeightTF = null;
			}

			if (YourWeightTF != null) {
				YourWeightTF.Dispose ();
				YourWeightTF = null;
			}
		}
	}
}
