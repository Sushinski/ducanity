using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace Dukapp
{
    public partial class MealPages : UIPageViewController
    {
        public List<UIViewController> pages;
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public MealPages()
            : base(UIPageViewControllerTransitionStyle.Scroll,
                UIPageViewControllerNavigationOrientation.Horizontal,
                UIPageViewControllerSpineLocation.Max)
        {
            pages = new List<UIViewController>();
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
            this.DataSource = new CookDataSource( this );
            this.View.BackgroundColor = UIColor.White;
            // Perform any additional setup after loading the view, typically from a nib.
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
 
    }


    public class CookDataSource : UIPageViewControllerDataSource 
    {

        public int Pages {get {return 2;} }
        public int m_cur_page;
        private UIPageViewController m_parent;

        public CookDataSource(UIPageViewController parent ) : base()
        {
            m_parent = parent;
        }

        public override UIViewController GetPreviousViewController (UIPageViewController pageViewController, 
            UIViewController referenceViewController)
        {
            int index = ((PagedVC)referenceViewController).m_PageIndex;
            //cycling
            if (index <= 0)
                index = 1;
            else
                index = 0;
            m_cur_page = index;
            return ((MealPages)pageViewController).pages[index];
        }

        public override UIViewController GetNextViewController (UIPageViewController pageViewController, 
            UIViewController referenceViewController)
        {
            int index = ((PagedVC)referenceViewController).m_PageIndex;
            //cycling
            if (index >= 1)
                index = 0;
            else
                index = 1;
            m_cur_page = index;
            return ((MealPages)pageViewController).pages[index];
        }

        public override int GetPresentationCount(UIPageViewController pageViewController)
        {
            MealPages mp = m_parent as MealPages;
            mp.setupPageControllerAppearance();
            return 2;
        }

        public override int GetPresentationIndex(UIPageViewController pageViewController)
        {
            return m_cur_page;
        }




    }
}

