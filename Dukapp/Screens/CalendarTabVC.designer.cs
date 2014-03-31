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
	[Register ("CalendarTabVC")]
	partial class CalendarTabVC
	{
		[Outlet]
		MonoTouch.UIKit.UILabel CalText1 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel CalText2 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel CalText3 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton HomeBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView TitleImg { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CalText1 != null) {
				CalText1.Dispose ();
				CalText1 = null;
			}

			if (CalText2 != null) {
				CalText2.Dispose ();
				CalText2 = null;
			}

			if (CalText3 != null) {
				CalText3.Dispose ();
				CalText3 = null;
			}

			if (HomeBtn != null) {
				HomeBtn.Dispose ();
				HomeBtn = null;
			}

			if (TitleImg != null) {
				TitleImg.Dispose ();
				TitleImg = null;
			}
		}
	}
}
