using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;


namespace Dukapp
{
    public partial class MealTWCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("MealTWCell");
        public static readonly UINib Nib;
        public bool m_bChecked;
        public bool m_bWasChanged;
        public bool m_bGrayBackgnd;

        static MealTWCell()
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
                Nib = UINib.FromName("MealTWCell_iPhone", NSBundle.MainBundle);
            else
                Nib = UINib.FromName("MealTWCell_iPad", NSBundle.MainBundle);
        }

        public MealTWCell(IntPtr handle) : base (handle)
        {
        }

        public MealTWCell (NSString cellId) : base (UITableViewCellStyle.Value1, cellId)
        {
            this.CellLabel.TextColor = UIColor.FromRGB(200, 200, 200);
            this.CellLabel.BackgroundColor = UIColor.Clear;
        }

        public void update(int cell_id)
        {
            this.BackgroundColor = m_bGrayBackgnd ?  UIColor.FromRGB(225, 225, 225) : UIColor.White ;
        }

        public static MealTWCell Create()
        {
            return (MealTWCell)Nib.Instantiate(null, null)[0];
        }

        public void UpdateCell ( string caption = "", string qty = "", string dim = "" )
        {
            if( caption != "" ) 
                this.CellLabel.Text = caption;
            string quantity = "";
            if (qty != "")
            {
                if (qty != "0")
                    quantity = qty + " " + dim;
                else
                    quantity = dim;
                this.CellQty.Text = quantity;
            }
            this.AddToBasketBtn.Image = 
                UIImage.FromFile( m_bChecked ? "images/png/polnaya-korzina-icon@2x.png" : "images/png/pustaya-korzina-icon@2x.png");
        }
        
        public override void TouchesBegan (NSSet touches, UIEvent evt)
        {
            base.TouchesBegan (touches, evt);
            UITouch touch = touches.AnyObject as UITouch;
            if (touch != null)
            {
                PointF pt = touch.LocationInView(this.AddToBasketBtn);
                if( this.AddToBasketBtn.Bounds.Contains(pt) )
                {
                    m_bChecked = !m_bChecked;
                    m_bWasChanged = true;
                    UpdateCell();
                }
            }
        }

    }
}

