using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DukappCore.BL.Managers;
using DukappCore.BL.Records;
using System.Collections.Generic;
using DukappCore.BL.Objects;

namespace Dukapp
{
	public partial class BaseListVC : UIViewController
	{
		UITableView m_table;
        RecipTableSrc m_data_source;
        UIViewController m_parent;
        UIImage m_title_img;
        RecipeSrcType m_src_type;
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

        public BaseListVC ( RecipeSrcType src_type, UIViewController parent )
			: base (UserInterfaceIdiomIsPhone ? "BaseListVC_iPhone" : "BaseListVC_iPad", null)
		{
            if (parent != null)
                m_parent = parent;
            m_src_type = src_type;
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
		}
           
        public void clearTable()
        {
            if (m_table != null)
                m_table.RemoveFromSuperview();

        }

        public void addTable( DietPhaseId phase )
        {
            m_data_source = new RecipTableSrc( phase, this );
            setTitleImage(RecipeSrcType.All);
            m_table = new UITableView (View.ViewWithTag (4).Frame);
            m_table.Source = m_data_source;
            m_table.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            Add (m_table);
        }

        public void addTable( RecipeSrcType src_type )
        {
            m_data_source = new RecipTableSrc( src_type, this );
            setTitleImage(src_type);
            m_table = new UITableView (View.ViewWithTag (4).Frame);
            m_table.Source = m_data_source;
            m_table.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            Add (m_table);

        }

        protected void setTitleImage( RecipeSrcType src_type )
        {
            switch( src_type )
            {
                case(RecipeSrcType.Favourites):
                    m_title_img = UIImage.FromFile("images/png/divisions/favourite-section@2x.png");
                    break;

                case(RecipeSrcType.Snacks):
                    m_title_img = UIImage.FromFile("images/png/divisions/snacks-section@2x.png");
                    break;

                case(RecipeSrcType.FirstCourses):
                    m_title_img = UIImage.FromFile("images/png/divisions/soups-section@2x.png");
                    break;

                case(RecipeSrcType.SecondCourses):
                    m_title_img = UIImage.FromFile("images/png/divisions/maincourse-section@2x.png");
                    break;

                case(RecipeSrcType.Salads):
                    m_title_img = UIImage.FromFile("images/png/divisions/salads-section@2x.png");
                    break;

                case(RecipeSrcType.Drinks):                    
                    m_title_img = UIImage.FromFile("images/png/divisions/drinks-section@2x.png");
                    break;

                case(RecipeSrcType.Sauces):        
                    m_title_img = UIImage.FromFile("images/png/divisions/sauce-section@2x.png");
                    break;

                case(RecipeSrcType.Bakery):
                    m_title_img = UIImage.FromFile("images/png/divisions/bakery-section@2x.png");
                    break;

                default:
                    break;
            }
            this.BLHeadImg.Image = m_title_img;
        }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            addTable(m_src_type);
            this.BLHomeBtn.TouchUpInside += (sender, e) =>
            {
                this.NavigationController.PopToRootViewController(true);
            };
            this.BLBackBtn.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewControllerAnimated(true);
            };
		}

	}
}

