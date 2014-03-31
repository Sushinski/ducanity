using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Dukapp
{
    public partial class TextVC : PagedVC
    {
		protected string m_text;
        protected string m_subtitle_txt;
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public TextVC( string main_text, string subtitle = "" )
			: base(UserInterfaceIdiomIsPhone ? "TextVC_iPhone" : "TextVC_iPad", null)
        {
            m_text = main_text;
            m_subtitle_txt = subtitle;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.MainText.Text = m_text;
            this.SubtitleTxt.Text = m_subtitle_txt;
            this.SubtitleImageView.BackgroundColor = UIColor.FromRGB(0x54, 0x54, 0x54);
            this.SubtitleTxt.TextColor = UIColor.FromRGB(200, 200, 200);
            this.HomeBtn.SetBackgroundImage(UIImage.FromFile("images/png/homebutton@2x.png"), UIControlState.Normal);
            this.HomeBtn.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopToRootViewController(true);
            };
        }
    }
}

