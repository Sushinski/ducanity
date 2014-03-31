using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using DukappCore.BL.Managers;
using DukappCore.BL.Objects;

namespace Dukapp
{
	public partial class RulesVC : UIViewController
	{
		protected TextVC m_textVC;
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public RulesVC ()
			: base (UserInterfaceIdiomIsPhone ? "RulesVC_iPhone" : "RulesVC_iPad", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            /*string child_text;
			this.DietBtn.TouchUpInside += (sender, e) =>
			{
				child_text = RecordManager.GetRuleForStage( new  DietPhase(DietPhaseId.DP_Default ));
				m_textVC = new TextVC(child_text);
				this.NavigationController.PushViewController(this.m_textVC, true);
			};
			this.AttackBtn.TouchUpInside += (sender, e) =>
			{
				child_text = RecordManager.GetRuleForStage( new  DietPhase(DietPhaseId.DP_Attack ));
				m_textVC = new TextVC(child_text);
				this.NavigationController.PushViewController(this.m_textVC, true);
			};
			this.CruiseBtn.TouchUpInside += (sender, e) =>
			{
				child_text = RecordManager.GetRuleForStage( new  DietPhase(DietPhaseId.DP_Cruise ));
				m_textVC = new TextVC(child_text);
				this.NavigationController.PushViewController(this.m_textVC, true);
			};
			this.ConsBtn.TouchUpInside += (sender, e) =>
			{
				child_text = RecordManager.GetRuleForStage( new  DietPhase(DietPhaseId.DP_Consolidation ));
				m_textVC = new TextVC(child_text);
				this.NavigationController.PushViewController(this.m_textVC, true);
			};
			this.StabBtn.TouchUpInside += (sender, e) =>
			{
				child_text = RecordManager.GetRuleForStage( new  DietPhase(DietPhaseId.DP_Stabilization ));
				m_textVC = new TextVC(child_text);
				this.NavigationController.PushViewController(this.m_textVC, true);
			};*/
		}
	}
}

