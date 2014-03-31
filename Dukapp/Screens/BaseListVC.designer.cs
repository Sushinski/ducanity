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
	[Register ("BaseListVC")]
	partial class BaseListVC
	{
		[Outlet]
		MonoTouch.UIKit.UIButton BLBackBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView BLHeadImg { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel BLHeadTxt { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton BLHomeBtn { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BLHeadImg != null) {
				BLHeadImg.Dispose ();
				BLHeadImg = null;
			}

			if (BLHeadTxt != null) {
				BLHeadTxt.Dispose ();
				BLHeadTxt = null;
			}

			if (BLHomeBtn != null) {
				BLHomeBtn.Dispose ();
				BLHomeBtn = null;
			}

			if (BLBackBtn != null) {
				BLBackBtn.Dispose ();
				BLBackBtn = null;
			}
		}
	}
}
