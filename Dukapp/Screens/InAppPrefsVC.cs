using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DukappCore.BL.Records;
using DukappCore.BL.Managers;
using System.Threading.Tasks;

namespace Dukapp
{
    public partial class InAppPrefsVC : PagedVC
	{
		PrefsVC prefs_scr;
        NSDate m_notifTime;
        //UIViewController m_parent;
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public InAppPrefsVC ()
			: base (UserInterfaceIdiomIsPhone ? "InAppPrefsVC_iPhone" : "InAppPrefsVC_iPad", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
		}

		public override void ViewDidLoad ()
        {
            base.ViewDidLoad();
            this.View.BackgroundColor = UIColor.FromPatternImage (UIImage.FromFile ("Images/png/background-graph@2x.png"));
            this.TitleImage.Image = UIImage.FromFile("images/png/divisions/sections-13@2x.png");
            this.HomeBtn.SetBackgroundImage(UIImage.FromFile("images/png/homebutton@2x.png"), UIControlState.Normal);
            // get if notifs enabled
            PrefsRecord rec = PrefsManager.GetPrefsRecordValue("NotifDate");
            if (rec.PrefValue != "0"
                && UIApplication.SharedApplication.ScheduledLocalNotifications.GetLength(0) > 0)
            {
                m_notifTime = UIApplication.SharedApplication.ScheduledLocalNotifications[0].FireDate;
                this.EnableDiarySw.On = true;
                EnableDiaryControls(true);
            }
            else
            {
                m_notifTime = NSDate.Now;
                EnableDiaryControls(false);
            }
            this.TimePicker.Date = m_notifTime;
            this.HoursTb.Text = NSDateToDateTime(m_notifTime).ToString("HH:mm");
         
            this.OnResetHistory.TouchUpInside += async (sender, e) => {
                int button = await ShowAlert ("Сброс истории", "Вы уверены?", "Да", "Нет");
                if( button == 0)
                {
                    PrefsRecord pref = PrefsManager.GetPrefsRecordValue("isDietStarted");
                    pref.PrefValue = "0";
                    PrefsManager.UpdatePrefsRecord( pref );
                    PrefsManager.ClearHistory();
                    if(prefs_scr == null)
                    {
                        prefs_scr = new PrefsVC ();
                    }
                    PresentViewController (prefs_scr, true, null);
                }

			};

            this.HomeBtn.TouchUpInside += (sender, e) => 
            {
                this.NavigationController.PopToRootViewController(true);
            };

            this.HoursTb.Started += (sender, e) => 
            {
                this.HoursTb.EndEditing(true);
            };

            this.HoursTb.TouchDown += (sender, e) => 
            {
                this.TimePicker.Hidden = false;
                this.SetTimeBtn.Hidden = false;
                //this.HoursTb.UserInteractionEnabled = false;
            };

            this.EnableDiarySw.TouchUpInside += (sender, e) =>
            {
                EnableDiaryControls( this.EnableDiarySw.On );
                EnableDiaryNotification( this.EnableDiarySw.On );
                PrefsRecord pref = PrefsManager.GetPrefsRecordValue("NotifDate");
                pref.PrefValue = this.EnableDiarySw.On == true ? "1":"0";
                PrefsManager.UpdatePrefsRecord( pref );
                this.TimePicker.Hidden = true;
                this.SetTimeBtn.Hidden = true;
            };
                
            this.SetTimeBtn.TouchUpInside += (sender, e) => 
            {
                m_notifTime = this.TimePicker.Date;
                DateTime date = NSDateToDateTime(m_notifTime);
                this.HoursTb.Text = date.ToString("HH:mm");
                this.SetTimeBtn.Hidden = true;
                EnableDiaryNotification( true );
                this.TimePicker.Hidden = true;
                this.HoursTb.EndEditing(true);
            };
		}
         
        public static Task<int> ShowAlert (string title, string message, params string [] buttons)
        {
            var tcs = new TaskCompletionSource<int> ();
            var alert = new UIAlertView {
                Title = title,
                Message = message
            };
            foreach (var button in buttons)
                alert.AddButton (button);
            alert.Clicked += (s, e) => tcs.TrySetResult (e.ButtonIndex);
            alert.Show ();
            return tcs.Task;
        }

        private void EnableDiaryControls(bool bEnable )
        {
            this.EverydayLbl.Hidden = !bEnable;
            this.HoursTb.Hidden = !bEnable;
        }

        private void EnableDiaryNotification( bool bEnable )
        {
            UIApplication.SharedApplication.CancelAllLocalNotifications();
            if(bEnable) SetNotification( m_notifTime );
        }

        private static DateTime NSDateToDateTime(NSDate date)
        {
            DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime( 
                new DateTime(2001, 1, 1, 0, 0, 0) );
            return reference.AddSeconds(date.SecondsSinceReferenceDate);
        }

        private void SetNotification( NSDate time )
        {
            UILocalNotification notification = new UILocalNotification();
            notification.FireDate = time;
            notification.RepeatInterval = NSCalendarUnit.Day;
            notification.AlertAction = "DukAnDiet";
            notification.AlertBody = "Время заполнить свой вес!";
            notification.SoundName = UILocalNotification.DefaultSoundName;
            notification.ApplicationIconBadgeNumber = 1;
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
	}
}

