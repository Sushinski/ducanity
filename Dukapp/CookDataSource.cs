using System;
using MonoTouch.UIKit;


namespace Dukapp
{
    public class CookDataSource : UIPageViewControllerDataSource 
    {

        public int Pages {get {return 2;} }
        public int m_cur_page;
        // private UIPageViewController m_parent;

        public CookDataSource(/*UIPageViewController parent */) : base()
        {
            // m_parent = parent;
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
            return ((DukappPagedVC)pageViewController).m_pages[index];
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
            return ((DukappPagedVC)pageViewController).m_pages[index];
        }

        public override int GetPresentationCount(UIPageViewController pageViewController)
        {
            /*DukappPagedVC mp = m_parent as DukappPagedVC;*/
            DukappPagedVC mp = pageViewController as DukappPagedVC;
            mp.setupPageControllerAppearance();
            return this.Pages;
        }

        public override int GetPresentationIndex(UIPageViewController pageViewController)
        {
            return m_cur_page;
        }
    }
}

