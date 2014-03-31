using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DukappCore.BL.Records;
using DukappCore.BL.Managers;

namespace Dukapp
{
    public partial class RecipeTWCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("RecipeTWCell");
        public static readonly UINib Nib;
        public bool m_bChecked;
        public bool m_bWasChanged;
        public bool m_bGrayBackgnd;

        static RecipeTWCell()
        {
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
                Nib = UINib.FromName("RecipeTWCell_iPhone", NSBundle.MainBundle);
            else
                Nib = UINib.FromName("RecipeTWCell_iPad", NSBundle.MainBundle);
        }

        public RecipeTWCell(IntPtr handle) : base (handle)
        {
        }

        public RecipeTWCell (NSString cellId, int cell_id ) : base (UITableViewCellStyle.Subtitle, cellId)
        {
            //ImageView.BackgroundColor = UIColor.
            //this.BackgroundColor = cell_id % 2 == 0 ? UIColor.White : UIColor.LightGray;
            this.RecipeLabel.TextColor = UIColor.FromRGB(200, 200, 200);
            //this.
            //SelectionStyle = UITableViewCellSelectionStyle.Gray;
            //Accessory = UITableViewCellAccessory.DetailDisclosureButton;
            this.RecipeLabel.BackgroundColor = UIColor.Clear;
            m_bWasChanged = false;
        }

        public void update(int cell_id)
        {
            this.BackgroundColor = m_bGrayBackgnd ?  UIColor.FromRGB(225, 225, 225) : UIColor.White ;
        }

        public override void TouchesBegan (NSSet touches, UIEvent evt)
        {
            base.TouchesBegan (touches, evt);
            UITouch touch = touches.AnyObject as UITouch;
            if (touch != null)
            {
                PointF pt = touch.LocationInView(FavImage);
                if( FavImage.Bounds.Contains(pt) )
                {
                    m_bChecked = !m_bChecked;
                    m_bWasChanged = true;
                    UpdateRow();
                }
            }
        }

        public void UpdateRow( string row_title = "" )
        {
            if( row_title != "" ) this.RecipeLabel.Text = row_title;
            this.FavImage.Image = UIImage.FromFile( m_bChecked ? 
                "images/png/star--full-icon@2x.png" : 
                "images/png/star--empty-icon@2x.png");
        }

        public static RecipeTWCell Create()
        {
            return (RecipeTWCell)Nib.Instantiate(null, null)[0];
        }

    }
}

