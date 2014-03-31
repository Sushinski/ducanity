using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using DukappCore.BL.Managers;
using DukappCore.BL.Records;
using DukappCore.BL.Objects;

namespace Dukapp
{
    public partial class CalendarTabVC : PagedVC
	{

		public CalendarMonthView m_monthView;
		Dictionary<DateTime, ScheduleRecord> m_phase_dict;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public CalendarTabVC ()
			: base (UserInterfaceIdiomIsPhone ? "CalendarTabVC_iPhone" : "CalendarTabVC_iPad", null)
		{
			m_phase_dict = new Dictionary<DateTime, ScheduleRecord> ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		private void refreshData()
		{
			List<ScheduleRecord> sch_list = ScheduleManager.GetScheduleRecords ();	
			m_phase_dict.Clear ();
			foreach( ScheduleRecord schr in sch_list)
			{
				m_phase_dict.Add (schr.m_date.Date, schr);
			}
		}

		private void populateCalendar()
		{
			RectangleF cal_rect = View.ViewWithTag (2).Frame;
			m_monthView = new CalendarMonthView(cal_rect);
			/*MonthView.OnDateSelected += (date) => {
				Console.WriteLine(String.Format("Selected {0}", date.ToShortDateString()));
				//this.CalText1.Text = date.ToString();
			};
			MonthView.OnFinishedDateSelection = (date) => {
				Console.WriteLine(String.Format("Finished selecting {0}", date.ToShortDateString()));
			};*/
			m_monthView.IsDayMarkedDelegate = (date) => {
				return false;
			};
			m_monthView.IsDateAvailable = (date)=>{
				return true;
			};
			m_monthView.stageForDayDelegate = (date) => {
				ScheduleRecord rec;
				if( m_phase_dict.TryGetValue( date, out rec ) )
				return (int)rec.m_phase;
				else
				return 0;
			};
			View.AddSubview(m_monthView);
		}

		public void repopulateCalendar()
		{
			refreshData ();
			m_monthView.RemoveFromSuperview ();
			//if(m_monthView != null ) m_monthView.Delete ();
			populateCalendar ();
		}

		private void refreshCalendarLabels()
		{
			ScheduleRecord record;
			DietPhase phase;
			if (!m_phase_dict.TryGetValue (DateTime.Now.Date, out record))
				phase = new DietPhase(DietPhaseId.DP_Default);
			else
				phase = new DietPhase( (DietPhaseId)record.m_phase ); 
			this.CalText2.Text = "Текущая фаза: " + phase.ToString ();
			double weight_today,weight_yesterday;
			if (m_phase_dict.TryGetValue (DateTime.Now.Date, out record))
				weight_today = record.m_weight;
			else
				weight_today = 0;
			if (m_phase_dict.TryGetValue (DateTime.Now.Date.AddDays (-1), out record))
				weight_yesterday = record.m_weight;
			else
				weight_yesterday = weight_today;
			double cur_weight_loss = weight_yesterday - weight_today;
			this.CalText3.Text = "Прогресс веса за день: " + cur_weight_loss.ToString () + " кг";

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            this.TitleImg.Image = UIImage.FromFile("images/png/divisions/sections-12@2x.png");
            this.HomeBtn.SetBackgroundImage(UIImage.FromFile("images/png/homebutton@2x.png"), UIControlState.Normal);
			refreshData ();
			populateCalendar ();
			refreshCalendarLabels ();
            this.HomeBtn.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopToRootViewController(true);
            };
			//int phase;

		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			refreshData();
			refreshCalendarLabels ();
			repopulateCalendar ();
		}

	}
}

