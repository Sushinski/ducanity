using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Dukapp
{
    public class PagedVC : UIViewController
    {
        public int m_PageIndex;
        public PagedVC( string name, NSBundle bundle ) : base( name, bundle )
        {
        }
    }
}

