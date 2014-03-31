using System;
using MonoTouch.UIKit;


namespace Dukapp
{
    public class DukappPagedDataSource : UIPageViewControllerDataSource 
    {

        public int Pages { get; set; }
        public int m_cur_page;

        public DukappPagedDataSource( int pages_count ) : base()
        {
            Pages = pages_count;
        }

        public override UIViewController GetPreviousViewController (UIPageViewController pageViewController, 
            UIViewController referenceViewController)
        {
            int index = ((PagedVC)referenceViewController).m_PageIndex;
            //cycling
            if (index <= 0)
                index = Pages-1;// to last
            else 
                index = index -1;
            m_cur_page = index;
            return ((DukappPagedVC)pageViewController).m_pages[index];
        }

        public override UIViewController GetNextViewController (UIPageViewController pageViewController, 
            UIViewController referenceViewController)
        {
            int index = ((PagedVC)referenceViewController).m_PageIndex;
            //cycling
            if (index >= (Pages-1))
                index = 0;
            else
                index = index + 1;
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


