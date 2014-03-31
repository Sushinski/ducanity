using System;
using System.Collections.Generic;
using DukappCore.BL.Records;


namespace DukappCore.BL.Managers {
	/// <summary>
	/// Manager classes are an abstraction on the data access layers
	/// </summary>
	public static class ScheduleManager {

		public static ScheduleRecord GetScheduleRec(int id)
		{
			return DukappCore.DAL.DukappRepository.GetScheduleRec(id);
		}

		public static List<ScheduleRecord> GetScheduleRecords ()
		{
			return new List<ScheduleRecord>(DukappCore.DAL.DukappRepository.GetScheduleRecords());
		}

		public static int SaveScheduleRecord (ScheduleRecord item)
		{
			return DukappCore.DAL.DukappRepository.SaveScheduleRecord(item);
		}

		public static int DeleteScheduleRecord(int id)
		{
			return DukappCore.DAL.DukappRepository.DeleteScheduleRecord(id);
		}

		public static void DeleteAllScheduleRecords()
		{
			List<ScheduleRecord> sch_list = GetScheduleRecords ();
			foreach (ScheduleRecord rec in sch_list) {
				DeleteScheduleRecord (rec.ID);
			}
		}
	}
}