using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace Dukapp
{
    public partial class DukappPagedVC : UIPageViewController
    {
        public List<UIViewController> m_pages;
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public DukappPagedVC( UIPageViewControllerDataSource source )
            : base(UIPageViewControllerTransitionStyle.Scroll,
                UIPageViewControllerNavigationOrientation.Horizontal,
                UIPageViewControllerSpineLocation.Max)
        {
            m_pages = new List<UIViewController>();
            this.DataSource = source;
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
            this.View.BackgroundColor = UIColor.White;
        }


        public void setupPageControllerAppearance()
        {
            foreach(object obj in this.View.Subviews)
            {
                UIPageControl pageControl = obj as UIPageControl;
                if( pageControl != null )
                {

                    pageControl.PageIndicatorTintColor = UIColor.FromRGB(0x81, 0xDB, 0xCA);
                    pageControl.CurrentPageIndicatorTintColor = UIColor.FromRGB(0x47, 0xBA, 0xA4);
                }
            }
            /*UIPageControl pageControl = this.View.Subviews. filteredArrayUsingPredicate:[NSPredicate predicateWithFormat:@"(class = %@)", [UIPageControl class]]] lastObject];
        pageControl.pageIndicatorTintColor = [UIColor grayColor];
        pageControl.currentPageIndicatorTintColor = [UIColor blackColor];*/
        }

        public override UIStatusBarStyle PreferredStatusBarStyle ()
        {
            return UIStatusBarStyle.LightContent;
        }

    }
}

