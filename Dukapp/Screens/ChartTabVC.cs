using System;
using System.Drawing;
using OxyPlot;
using MonoTouch;
using OxyPlot.MonoTouch;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;
using DukappCore.BL.Managers;
using DukappCore.BL.Records;
using DukappCore.BL.Objects;
using System.Collections.Generic;


namespace Dukapp
{
	using System.Collections.ObjectModel;
	using System.Globalization;

    public partial class ChartTabVC : PagedVC
	{
		List<ScheduleRecord> sch_list; 
		Dictionary<DateTime, ScheduleRecord> phase_dict;
		ChartView chview;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public ChartTabVC ()
			: base (UserInterfaceIdiomIsPhone ? "ChartTabVC_iPhone" : "ChartTabVC_iPad", null)
		{
			sch_list = ScheduleManager.GetScheduleRecords ();
			phase_dict = new Dictionary<DateTime, ScheduleRecord> ();
			foreach( ScheduleRecord schr in sch_list)
			{
				phase_dict.Add (schr.m_date.Date, schr);
			}

		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
		}

		public void refreshChart()
		{
			sch_list.Clear ();
			sch_list = ScheduleManager.GetScheduleRecords ();
			phase_dict.Clear ();
			foreach( ScheduleRecord schr in sch_list)
			{
				phase_dict.Add (schr.m_date.Date, schr);
			}
			// possible to save chart view state
			chview.RemoveFromSuperview();
			chview = new ChartView(sch_list,this.View.ViewWithTag(3).Frame);
            View.AddSubview (chview);

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            this.View.BackgroundColor = UIColor.FromPatternImage (UIImage.FromFile ("Images/png/background-graph@2x.png"));
            this.TitleImage.Image = UIImage.FromFile("images/png/divisions/graph-section@2x.png");
            this.HomeBtn.SetBackgroundImage(UIImage.FromFile("images/png/homebutton@2x.png"), UIControlState.Normal);
            //this.chartWeightTB.Background = UIImage.FromFile("images/png/weighttoday-whitr@2x.png");
            this.chartWeightAddBtn.SetBackgroundImage(UIImage.FromFile("images/png/weighttoday-button@2x.png"), UIControlState.Normal);
            this.chartWeightTB.Placeholder = "Мой вес сегодня";
			RectangleF rct = this.View.ViewWithTag (3).Frame;
			chview = new ChartView (sch_list, rct);
            View.AddSubview (chview);
			this.chartWeightAddBtn.TouchUpInside += (sender, e) => {
				int weight = System.Convert.ToInt32(this.chartWeightTB.Text, 10);
				phase_dict[DateTime.Today].m_weight = weight;
				ScheduleManager.SaveScheduleRecord(phase_dict[DateTime.Today]);
				this.chartWeightTB.ResignFirstResponder();
				sch_list = ScheduleManager.GetScheduleRecords ();
				chview.RemoveFromSuperview();
				chview = new ChartView(sch_list,this.View.ViewWithTag(3).Frame);
				View.AddSubview(chview);
			};
            this.HomeBtn.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopToRootViewController(true);
            };
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			refreshChart ();
		}

        public override UIStatusBarStyle PreferredStatusBarStyle ()
        {
            return UIStatusBarStyle.LightContent;
        }





	}
}

