using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DukappCore.BL.Records;
using DukappCore.BL.Objects;
using DukappCore.BL.Managers;
using System.Collections.Generic;

namespace Dukapp
{
    public partial class HowToCookVC : PagedVC
    {
        private RecipeRecord m_recipe;
        private List<DietPhase> m_d_p;
        public int PageIndex {get {return 1;} }
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public HowToCookVC( RecipeRecord recipe )
			: base(UserInterfaceIdiomIsPhone ? "HowToCookVC_iPhone" : "HowToCookVC_iPad", null)
        {
            m_recipe = recipe;
            m_PageIndex = 1;
            m_d_p = RecipeManager.GetPhaseForRecipe(m_recipe.ID);
            m_d_p.Sort();
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
			
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.TitleImageView.Image = UIImage.FromFile("images/png/divisions/sposobprigotovleniya-section@2x.png");
            this.OnBackBtn.SetBackgroundImage(UIImage.FromFile("images/png/backbutton@2x.png"),UIControlState.Normal);
            this.OnHomeBtn.SetBackgroundImage(UIImage.FromFile("images/png/homebutton@2x.png"), UIControlState.Normal);
            this.OnAddToFavBtn.SetBackgroundImage(UIImage.FromFile( m_recipe.isFavourite == 1 ? 
                "images/png/star--full-icon@2x.png" : 
                "images/png/star--empty-icon@2x.png"),UIControlState.Normal); 
            this.RecipeNameLabel.Text = m_recipe.RecipeName;
            this.HowToCookTxt.Text = m_recipe.RecipeDesc;
            this.RecipeNameLabel.TextColor = UIColor.White;
            this.SubTitleImageView.BackgroundColor = UIColor.FromRGB(0x54, 0x54, 0x54);
            float strt_x = this.View.ViewWithTag(1).Frame.Left;
            float strt_y = this.View.ViewWithTag(1).Frame.Top;
            //set color fo stage btn text
            this.AtckBtn.TitleLabel.TextColor = UIColor.FromRGB(0x47, 0xBA, 0xA4);
            this.CruiseBtn.TitleLabel.TextColor = UIColor.FromRGB(0x47, 0xBA, 0xA4);
            this.ConsolidBtn.TitleLabel.TextColor = UIColor.FromRGB(0x47, 0xBA, 0xA4);
            this.StabBtn.TitleLabel.TextColor = UIColor.FromRGB(0x47, 0xBA, 0xA4);
            this.View.BackgroundColor = UIColor.Clear;
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

        }
    }

}

