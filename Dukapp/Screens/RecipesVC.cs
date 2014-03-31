using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DukappCore.BL.Records;

namespace Dukapp
{
	public partial class RecipesVC : UIViewController
	{
		protected BaseListVC m_list;
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public RecipesVC ()
			: base (UserInterfaceIdiomIsPhone ? "RecipesVC_iPhone" : "RecipesVC_iPad", null)
		{
			this.Title = "Recipes";
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

			this.OnFavoritesBtn.TouchUpInside += (sender, e) => {
				m_list = new BaseListVC( RecipeSrcType.Favourites, this );
    			this.NavigationController.PushViewController(this.m_list, true);
			};

			this.OnFirstCoursesBtn.TouchUpInside += (sender, e) => {
				m_list = new BaseListVC( RecipeSrcType.FirstCourses, this );
				this.NavigationController.PushViewController(this.m_list, true);
			};

			this.OnSecondCoursesBtn.TouchUpInside += (sender, e) => {
				m_list = new BaseListVC( RecipeSrcType.SecondCourses, this );
				this.NavigationController.PushViewController(this.m_list, true);
			};

			this.OnSaladsBtn.TouchUpInside += (sender, e) => {
				m_list = new BaseListVC( RecipeSrcType.Salads, this );
				this.NavigationController.PushViewController(this.m_list, true);
			};

			this.OnSnacksBtn.TouchUpInside += (sender, e) => {
				m_list = new BaseListVC( RecipeSrcType.Snacks, this );
				this.NavigationController.PushViewController(this.m_list, true);
			};

            this.OnBakeryBtn.TouchUpInside += (sender, e) => 
            {
                m_list = new BaseListVC(RecipeSrcType.Bakery, this );
                this.NavigationController.PushViewController(this.m_list, true);
            };

            this.OnDrinksBtn.TouchUpInside += (sender, e) => 
            {
                m_list = new BaseListVC(RecipeSrcType.Drinks, this );
                this.NavigationController.PushViewController(this.m_list, true);
            };

            this.OnSaucesBtn.TouchUpInside += (sender, e) => 
            {
                m_list = new BaseListVC(RecipeSrcType.Sauces, this );
                this.NavigationController.PushViewController(this.m_list, true);
            };

            this.OnHomeBtn.TouchUpInside += (sender, e) =>
            {
                this.NavigationController.PopToRootViewController(true);
            };

		}

	}
}

