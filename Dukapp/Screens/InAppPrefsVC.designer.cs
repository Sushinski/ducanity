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
	[Register ("InAppPrefsVC")]
	partial class InAppPrefsVC
	{
		[Outlet]
		MonoTouch.UIKit.UISwitch EnableDiarySw { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel EverydayLbl { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton HomeBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField HoursTb { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField MinutesTb { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OnResetHistory { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton SetTimeBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView SubtitleImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIDatePicker TimePicker { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView TitleImage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (EnableDiarySw != null) {
				EnableDiarySw.Dispose ();
				EnableDiarySw = null;
			}

			if (EverydayLbl != null) {
				EverydayLbl.Dispose ();
				EverydayLbl = null;
			}

			if (SetTimeBtn != null) {
				SetTimeBtn.Dispose ();
				SetTimeBtn = null;
			}

			if (HomeBtn != null) {
				HomeBtn.Dispose ();
				HomeBtn = null;
			}

			if (HoursTb != null) {
				HoursTb.Dispose ();
				HoursTb = null;
			}

			if (MinutesTb != null) {
				MinutesTb.Dispose ();
				MinutesTb = null;
			}

			if (OnResetHistory != null) {
				OnResetHistory.Dispose ();
				OnResetHistory = null;
			}

			if (SubtitleImage != null) {
				SubtitleImage.Dispose ();
				SubtitleImage = null;
			}

			if (TitleImage != null) {
				TitleImage.Dispose ();
				TitleImage = null;
			}

			if (TimePicker != null) {
				TimePicker.Dispose ();
				TimePicker = null;
			}
		}
	}
}
