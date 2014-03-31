using System;
using System.Collections.Generic;
using DukappCore.BL.Records;

namespace DukappCore.BL.Objects
{
	public class ScheduleMaker
	{
		public ScheduleMaker ()
		{
		}
		public static List<ScheduleRecord> makeAttackCruise( int goal_difference, int attack_days, DateTime start_date  )
		{
			List<ScheduleRecord> sch_list = new List<ScheduleRecord> ();
			//first - fill cruise time
			DateTime cur_date = start_date;
			for (int i=0; i < attack_days; ++i) 
			{
				cur_date = start_date.AddDays (i);
				sch_list.Add( new ScheduleRecord( cur_date, DietPhaseId.DP_Attack ));  
			}
			// second - fill cruise section
			int cruse_days = goal_difference;// 1kg = 1 day of cruise
			cur_date = cur_date.AddDays (1);
			for (int i = 0; i < cruse_days; ++i) 
			{
				// continue adding days

				sch_list.Add (new ScheduleRecord (cur_date, DietPhaseId.DP_Cruise));
				cur_date = cur_date.AddDays (1);
			}
			return sch_list;
		}
		public static IList<ScheduleRecord> makeConsolidation( int prevAchiveWeight, DateTime start_date )
		{
			List<ScheduleRecord> sch_list = new List<ScheduleRecord> ();
			DateTime cur_date;
			for (int i = 0; i < prevAchiveWeight * 10; ++i) 
			{
				cur_date = start_date.AddDays (i);
				sch_list.Add (new ScheduleRecord (cur_date, DietPhaseId.DP_Consolidation));
			}
			return sch_list;
		}

	}
}

