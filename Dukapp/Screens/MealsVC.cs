using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DukappCore.BL.Records;
using DukappCore.BL.Managers;
using System.Collections.Generic;
using DukappCore.BL.Objects;

namespace Dukapp
{
    public partial class MealsVC : PagedVC
	{
        //List<MealRecord> m_meals;
		private UITableView m_table;
		private MealTableSrc m_table_source;
		private RecipeRecord m_recipe;
        private List<DietPhase> m_d_p;
        private UIViewController m_parent;
        //string m_stage;
        public int PageIndex {get {return 0;} }

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public MealsVC ()
            : base (UserInterfaceIdiomIsPhone ? "MealsVC_iPhone" : "MealsVC_iPad", null )
		{
			//this.Title = "Meals";

		}

        public MealsVC ( RecipeRecord recipe, UIViewController parent = null )
            : base (UserInterfaceIdiomIsPhone ? "MealsVC_iPhone" : "MealsVC_iPad", null)
        {
			List<RecipeMealsRecord> rmr = RecipeManager.GetMealsForRecipe(recipe.ID);
			m_table_source = new MealTableSrc(rmr.ToArray());
			this.Title = "Meals";
            m_d_p = RecipeManager.GetPhaseForRecipe(recipe.ID);
            m_d_p.Sort();
            //m_stage = "Stages: ";
            m_recipe = recipe;
			this.Title = recipe.RecipeName;
            m_PageIndex = 0;
            m_parent = parent;
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
            // add stages buttons
            this.RecipeBgImg.BackgroundColor = UIColor.FromRGB(0x54, 0x54, 0x54);
            this.RecipeNameTxt.TextColor = UIColor.White;
            float strt_x = this.View.ViewWithTag(1).Frame.Left;
            float strt_y = this.View.ViewWithTag(1).Frame.Top;
            //set color fo stage btn text
            this.AtckBtn.TitleLabel.TextColor = UIColor.FromRGB(0x47, 0xBA, 0xA4);
            this.CruiseBtn.TitleLabel.TextColor = UIColor.FromRGB(0x47, 0xBA, 0xA4);
            this.ConsolidBtn.TitleLabel.TextColor = UIColor.FromRGB(0x47, 0xBA, 0xA4);
            this.StabBtn.TitleLabel.TextColor = UIColor.FromRGB(0x47, 0xBA, 0xA4);
            this.View.BackgroundColor = UIColor.Clear;
            // wihin sorted list check phases
            foreach (DietPhase dp in m_d_p)
            {
                if (this.View.ViewWithTag(1).Frame.Right - strt_x < this.ConsolidBtn.Bounds.Width)
                {
                    strt_y = this.View.ViewWithTag(2).Frame.Top;
                    strt_x = this.View.ViewWithTag(2).Frame.Left;
                }
                if (dp == DietPhaseId.DP_Attack)
                {
                    this.AtckBtn.Frame = new RectangleF(strt_x, strt_y, this.AtckBtn.Bounds.Width, this.AtckBtn.Bounds.Height);
                    strt_x += this.AtckBtn.Bounds.Width;
                    this.AtckBtn.Hidden = false;
                    this.AtckBtn.UserInteractionEnabled = true;
                    continue;
                }
                if (dp == DietPhaseId.DP_Cruise)
                {
                    this.CruiseBtn.Frame = new RectangleF(strt_x, strt_y, this.CruiseBtn.Bounds.Width, this.CruiseBtn.Bounds.Height);
                    strt_x += this.CruiseBtn.Bounds.Width;
                    this.CruiseBtn.Hidden = false;
                    this.CruiseBtn.UserInteractionEnabled = true;
                    continue;
                }

                if (dp == DietPhaseId.DP_Consolidation)
                {
                    this.ConsolidBtn.Frame = new RectangleF(strt_x, strt_y, this.ConsolidBtn.Bounds.Width, this.ConsolidBtn.Bounds.Height);
                    strt_x += this.ConsolidBtn.Bounds.Width;
                    this.ConsolidBtn.Hidden = false;
                    this.ConsolidBtn.UserInteractionEnabled = true;
                    continue;
                }
                if (dp == DietPhaseId.DP_Stabilization)
                {
                    this.StabBtn.Frame = new RectangleF(strt_x, strt_y, this.StabBtn.Bounds.Width, this.StabBtn.Bounds.Height);
                    this.StabBtn.Hidden = false;
                    this.StabBtn.UserInteractionEnabled = true;
                }
            }
        
            this.HeadImg.Image = UIImage.FromFile("images/png/divisions/ingredients-section@2x.png");
            m_table = new UITableView(View.ViewWithTag(5).Frame);
            m_table.Source = m_table_source;
            m_table.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            Add(m_table);

            this.AddToFavBtn.SetBackgroundImage(UIImage.FromFile( m_recipe.isFavourite == 1 ? 
                "images/png/star--full-icon@2x.png" : 
                "images/png/star--empty-icon@2x.png"),UIControlState.Normal); 
            this.AddAllBtn.SetBackgroundImage(UIImage.FromFile("images/png/shopping-list-icon@2x.png"), UIControlState.Normal);
            this.RecipeNameTxt.Text = m_recipe.RecipeName;

            this.AddToFavBtn.TouchUpInside += (sender, e) =>
            {
                m_recipe.isFavourite ^= 1;
                this.AddToFavBtn.SetBackgroundImage( UIImage.FromFile( m_recipe.isFavourite == 1 ? 
                    "images/png/star--full-icon@2x.png" : 
                    "images/png/star--empty-icon@2x.png"),UIControlState.Normal); 
                RecipeManager.SaveRecipeRecord(m_recipe);
            };

            this.OnBackBtn.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewControllerAnimated(true);
            };

            this.OnHomeBtn.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopToRootViewController(true);
            };

            this.AtckBtn.TouchUpInside += (sender, e) => 
            {
                BaseListVC bl = m_parent as BaseListVC;
                if( bl != null )
                {
                    bl.clearTable();
                    bl.addTable(DietPhaseId.DP_Attack);
                }
                this.NavigationController.PopViewControllerAnimated(false);

            };

            this.CruiseBtn.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewControllerAnimated(false);
            };

            this.ConsolidBtn.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewControllerAnimated(false);
            };

            this.StabBtn.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewControllerAnimated(false);
            };
		}

        /*public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			base.TouchesBegan(touches, evt);
			UITouch touch = touches.AnyObject as UITouch;
			if (touch != null)
			{
				PointF pt = touch.LocationInView(View);
				if( this.FavImg.Frame.Contains(pt) )
				{
					
				}
			}
		}*/
	}
}

