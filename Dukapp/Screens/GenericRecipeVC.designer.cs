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
	[Register ("GenericRecipeVC")]
	partial class GenericRecipeVC
	{
		[Outlet]
		MonoTouch.UIKit.UITableView RecipesTW { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (RecipesTW != null) {
				RecipesTW.Dispose ();
				RecipesTW = null;
			}
		}
	}
}
