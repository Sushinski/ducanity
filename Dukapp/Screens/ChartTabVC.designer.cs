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
	[Register ("ChartTabVC")]
	partial class ChartTabVC
	{
		[Outlet]
		MonoTouch.UIKit.UIButton chartWeightAddBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField chartWeightTB { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton HomeBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView SubtitleImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView TitleImage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (chartWeightAddBtn != null) {
				chartWeightAddBtn.Dispose ();
				chartWeightAddBtn = null;
			}

			if (chartWeightTB != null) {
				chartWeightTB.Dispose ();
				chartWeightTB = null;
			}

			if (HomeBtn != null) {
				HomeBtn.Dispose ();
				HomeBtn = null;
			}

			if (SubtitleImage != null) {
				SubtitleImage.Dispose ();
				SubtitleImage = null;
			}

			if (TitleImage != null) {
				TitleImage.Dispose ();
				TitleImage = null;
			}
		}
	}
}
