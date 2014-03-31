using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using DukappCore.BL.Records;
using DukappCore.BL.Managers;

namespace Dukapp
{
	public partial class BasketVC : UIViewController
	{
        private UITableView m_table;
        private BasketTableSrc m_tableSource;
		private RectangleF table_frame;
		static bool UserInterfaceIdiomIsPhone 
        {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

        public BasketVC () : base (UserInterfaceIdiomIsPhone ? "BasketVC_iPhone" : "BasketVC_iPad", null)
		{
            //this.Title = "Basket";
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            this.BasketTitleImg.Image = UIImage.FromFile("images/png/divisions/shoppinglist-section@2x.png");
            this.BasketSubtitleImg.BackgroundColor = UIColor.FromRGB(0x54, 0x54, 0x54);
            this.OnBackBtn.SetBackgroundImage(UIImage.FromFile("images/png/backbutton@2x.png"),UIControlState.Normal);
            this.OnHomeBtn.SetBackgroundImage(UIImage.FromFile("images/png/homebutton@2x.png"), UIControlState.Normal);
            this.OnClearBtn.SetBackgroundImage(UIImage.FromFile("images/png/bin@2x.png"), UIControlState.Normal);
			table_frame = View.ViewWithTag(8).Frame;
			updateDatasource();      
            this.OnClearBtn.TouchUpInside += (sender, e) => 
            {
				m_tableSource.RemoveCheckedItems();
				m_table.DeleteRows(m_tableSource.m_selectedItems.ToArray(), UITableViewRowAnimation.Automatic);
            };
            this.OnBackBtn.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopViewControllerAnimated(true);
            };

            this.OnHomeBtn.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopToRootViewController(true);
            };
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			if (m_table!=null)
				m_table.RemoveFromSuperview();
			updateDatasource();
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
		}

		public void updateDatasource()
		{
			m_table = new UITableView(table_frame);
			m_table.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			List<BasketMealsRecord> items = BasketManager.GetBasketRecords();
			m_tableSource = new BasketTableSrc(items.ToArray());
			m_table.Source = m_tableSource;
			View.AddSubview(m_table);
		}
	}
}

