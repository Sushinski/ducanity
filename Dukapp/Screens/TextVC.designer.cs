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
	[Register ("TextVC")]
	partial class TextVC
	{
		[Outlet]
		MonoTouch.UIKit.UIButton BackBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton HomeBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView MainText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView SubtitleImageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel SubtitleTxt { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView TitleImgView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TitleImgView != null) {
				TitleImgView.Dispose ();
				TitleImgView = null;
			}

			if (SubtitleImageView != null) {
				SubtitleImageView.Dispose ();
				SubtitleImageView = null;
			}

			if (BackBtn != null) {
				BackBtn.Dispose ();
				BackBtn = null;
			}

			if (HomeBtn != null) {
				HomeBtn.Dispose ();
				HomeBtn = null;
			}

			if (SubtitleTxt != null) {
				SubtitleTxt.Dispose ();
				SubtitleTxt = null;
			}

			if (MainText != null) {
				MainText.Dispose ();
				MainText = null;
			}
		}
	}
}
