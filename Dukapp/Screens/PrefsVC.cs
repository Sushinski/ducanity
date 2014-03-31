using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DukappCore.BL.Records;
using DukappCore.BL.Objects;
using DukappCore.BL.Managers;
using System.Collections.Generic;

namespace Dukapp
{
	public partial class PrefsVC : UIViewController
	{
		int m_my_weight;
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public PrefsVC ()
            : base (UserInterfaceIdiomIsPhone ? "PrefsVC_iPhone" : "PrefsVC_iPad", null)
		{
			//this.Title = "Dukapp";
			this.View.Bounds = UIScreen.MainScreen.Bounds;
			m_my_weight = 0;
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		int get_start_weight() { return m_my_weight; }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.OkayBtn.Clicked += (sender, e) => {
				DismissViewController (true, null);
				// get & parse params
				this.YourWeightTF.ResignFirstResponder();
				string your_w = this.YourWeightTF.Text;
				string desire_w = this.DesireWeightTF.Text;
				m_my_weight = System.Convert.ToInt32(your_w, 10);
				int goal_diff = m_my_weight - System.Convert.ToInt32(desire_w, 10 );
				int a_days = System.Convert.ToInt32(this.AtackTF.Text, 10);
				// clear prev schedule
				ScheduleManager.DeleteAllScheduleRecords();
				// calculate and save schedule(attack& cruise for now)
				List <ScheduleRecord> recs_list = ScheduleMaker.makeAttackCruise( goal_diff, a_days, DateTime.Now.Date ); 
				foreach (var sch in recs_list)
				{
					sch.m_weight = m_my_weight;
					ScheduleManager.SaveScheduleRecord( sch );
				}
				PrefsRecord pref = PrefsManager.GetPrefsRecordValue("isDietStarted");
				pref.PrefValue = "1";// diet have started
				PrefsManager.UpdatePrefsRecord( pref );

			};
		}
	}
}

