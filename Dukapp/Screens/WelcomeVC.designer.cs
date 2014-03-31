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
	[Register ("WelcomeVC")]
	partial class WelcomeVC
	{
		[Outlet]
		MonoTouch.UIKit.UISwitch EnableStartTutor { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton Welcome_okay { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Welcome_okay != null) {
				Welcome_okay.Dispose ();
				Welcome_okay = null;
			}

			if (EnableStartTutor != null) {
				EnableStartTutor.Dispose ();
				EnableStartTutor = null;
			}
		}
	}
}
