using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Dukapp
{
    public partial class BasketTWCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("BasketTWCell");
        public static readonly UINib Nib;
		public bool m_bChecked;
        public bool m_bGrayBackgnd;

        static BasketTWCell()
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
                Nib = UINib.FromName("BasketTWCell_iPhone", NSBundle.MainBundle);
            else
                Nib = UINib.FromName("BasketTWCell_iPad", NSBundle.MainBundle);
        }

        public BasketTWCell(IntPtr handle) : base (handle)
        {
        }

        public BasketTWCell(NSString cellId) : base ( UITableViewCellStyle.Value1, cellId )
        {
   
            this.MealTxt.Font = UIFont.FromName("Helvetica", 13f);
            this.QtyTxt.Font = UIFont.FromName("Helvetica", 14f);
        }

        public void update(int cell_id)
        {
            this.BackgroundColor = m_bGrayBackgnd ?  UIColor.FromRGB(225, 225, 225) : UIColor.White ;
        }

        public static BasketTWCell Create()
        {
            return (BasketTWCell)Nib.Instantiate(null, null)[0];
        }

        public void UpdateCell ( string name = "", string weight = "" )
        {
            if( name != "" ) this.MealTxt.Text = name;
            if( weight != "" ) this.QtyTxt.Text = weight;
            this.CheckBtn.Image =  
                UIImage.FromFile( m_bChecked ? "images/png/fulldot@2x.png" : "images/png/emptydot@2x.png");
        }
           

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
			UITouch touch = touches.AnyObject as UITouch;
			if (touch != null)
			{
                PointF pt = touch.LocationInView(this.CheckBtn);
                if( this.CheckBtn.Bounds.Contains(pt) )
				{
					m_bChecked = !m_bChecked;
					UpdateCell();
				}
			}
		}
    }
}

