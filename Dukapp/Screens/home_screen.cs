using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Dukapp
{
	public partial class home_screen : UIViewController
	{
		RulesVC rulesView;
		ScheduleVC scheduleView;
		MealsVC mealsScreen;
		RecipesVC recipesScreen;
		GuidanceVC guidanceScreen;
		BasketVC basketScreen;



		public home_screen () : base ("home_screen", null)
		{
			//this.Title = "Dukapp";
			this.View.Bounds = UIScreen.MainScreen.Bounds;
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.RulesBtn.TouchUpInside += (sender, e) => {
				if(this.rulesView == null)
				{ this.rulesView = new RulesVC(); }
				this.NavigationController.PushViewController(this.rulesView, true);
			};
			this.ScheduleBtn.TouchUpInside += (sender, e) => {
				if(this.scheduleView == null)
				{ this.scheduleView = new ScheduleVC(); }
				this.NavigationController.PushViewController(this.scheduleView, true);
			};
			this.MealsBtn.TouchUpInside += (sender, e) => {
				if(this.mealsScreen == null)
				{ this.mealsScreen = new MealsVC(); }
				this.NavigationController.PushViewController(this.mealsScreen, true);
			};
			this.RecipesBtn.TouchUpInside += (sender, e) => {
				if(this.recipesScreen == null)
				{ this.recipesScreen = new RecipesVC(); }
				this.NavigationController.PushViewController(this.recipesScreen, true);
			};

			this.BasketBtn.TouchUpInside += (sender, e) => {
				if(this.basketScreen == null)
				{ this.basketScreen  = new BasketVC(); }
				this.NavigationController.PushViewController(this.basketScreen, true);
			};
			this.GuidanceBtn.TouchUpInside += (sender, e) => {
				if(this.guidanceScreen == null)
				{ this.guidanceScreen  = new GuidanceVC(); }
				this.NavigationController.PushViewController(this.guidanceScreen, true);
			};
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

