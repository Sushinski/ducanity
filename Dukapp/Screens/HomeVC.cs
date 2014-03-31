using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DukappCore.BL.Managers;
using DukappCore.BL.Objects;

namespace Dukapp
{
	public partial class HomeVC : UIViewController
	{

        //RulesVC rulesView;
		ScheduleVC scheduleView;
		MealsVC mealsScreen;
		RecipesVC recipesScreen;
		GuidanceVC guidanceScreen;
		BasketVC basketScreen;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public HomeVC ()
			: base (UserInterfaceIdiomIsPhone ? "HomeVC_iPhone" : "HomeVC_iPad", null)
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
            this.View.BackgroundColor = UIColor.FromPatternImage (UIImage.FromFile ("Images/png/background-menu@2x.png"));
            //this.View.InsertSubview (new UIImageView(UIImage.FromBundle("Images/png/background-menu.png")),0);
			this.RulesBtn.TouchUpInside += (sender, e) => {
                // add pages
                DukappPagedDataSource qsrc = new DukappPagedDataSource(5);
                DukappPagedVC mp = new DukappPagedVC(qsrc);
                TextVC mainrules = new TextVC( RecordManager.GetRuleForStage( new  DietPhase(DietPhaseId.DP_Default )), new DietPhase(DietPhaseId.DP_Default).ToPrintString());
                mainrules.m_PageIndex = 0;
                TextVC attacktxt = new TextVC( RecordManager.GetRuleForStage( new  DietPhase(DietPhaseId.DP_Attack )), new DietPhase(DietPhaseId.DP_Attack).ToPrintString());
                attacktxt.m_PageIndex = 1;
                TextVC cruisecktxt = new TextVC( RecordManager.GetRuleForStage( new  DietPhase(DietPhaseId.DP_Cruise )), new DietPhase(DietPhaseId.DP_Cruise).ToPrintString());
                cruisecktxt.m_PageIndex = 2;
                TextVC constxt = new TextVC( RecordManager.GetRuleForStage( new  DietPhase(DietPhaseId.DP_Consolidation )), new DietPhase(DietPhaseId.DP_Consolidation).ToPrintString());
                constxt.m_PageIndex = 3;
                TextVC stabtxt = new TextVC( RecordManager.GetRuleForStage( new  DietPhase(DietPhaseId.DP_Stabilization )), new DietPhase(DietPhaseId.DP_Stabilization).ToPrintString());
                stabtxt.m_PageIndex = 4;
                mp.m_pages.Add(mainrules);
                mp.m_pages.Add(attacktxt);
                mp.m_pages.Add(cruisecktxt);
                mp.m_pages.Add(constxt);
                mp.m_pages.Add(stabtxt);
                mp.SetViewControllers(new UIViewController[] { mainrules }, UIPageViewControllerNavigationDirection.Forward,  true, null);
                this.NavigationController.PushViewController (mp, true);
			};
			this.ScheduleBtn.TouchUpInside += (sender, e) => {
                DukappPagedDataSource qsrc = new DukappPagedDataSource(3);
                DukappPagedVC mp = new DukappPagedVC(qsrc);
                mp.View.BackgroundColor = UIColor.FromPatternImage (UIImage.FromFile ("Images/png/background-graph@2x.png"));
                CalendarTabVC calendar = new CalendarTabVC();
                calendar.m_PageIndex = 0;
                ChartTabVC chart = new ChartTabVC();
                chart.m_PageIndex = 1;
                InAppPrefsVC prefs = new InAppPrefsVC();
                prefs.m_PageIndex = 2;
                mp.m_pages.Add(calendar);
                mp.m_pages.Add(chart);
                mp.m_pages.Add(prefs);
                mp.SetViewControllers(new UIViewController[] { calendar }, UIPageViewControllerNavigationDirection.Forward,  true, null);
                this.NavigationController.PushViewController (mp, true);
			};
			this.RecBtn.TouchUpInside += (sender, e) => {
				if(this.recipesScreen == null)
				{ this.recipesScreen = new RecipesVC(); }
                //this.NavigationController.NavigationBarHidden = false;
				this.NavigationController.PushViewController(this.recipesScreen, true);
			};
			/*this.MealsBtn.TouchUpInside += (sender, e) => {
				if(this.mealsScreen == null)
				{ this.mealsScreen = new MealsVC(); }
                this.NavigationController.NavigationBarHidden = false;            
				this.NavigationController.PushViewController(this.mealsScreen, true);
			};*/


			this.BasketBtn.TouchUpInside += (sender, e) => {
				if(this.basketScreen == null)
				{ this.basketScreen  = new BasketVC(); }
                //this.NavigationController.NavigationBarHidden = false;
				this.NavigationController.PushViewController(this.basketScreen, true);
			};
			/*this.GuidanceBtn.TouchUpInside += (sender, e) => {
				if(this.guidanceScreen == null)
				{ this.guidanceScreen  = new GuidanceVC(); }
                this.NavigationController.NavigationBarHidden = false;            
				this.NavigationController.PushViewController(this.guidanceScreen, true);
			};*/
		}

        public override void ViewWillAppear (bool animated)
        {
            this.NavigationController.NavigationBarHidden = true;
            base.ViewWillAppear (true);
        }

        public override UIStatusBarStyle PreferredStatusBarStyle ()
        {
            return UIStatusBarStyle.LightContent;
        }
	}
}

