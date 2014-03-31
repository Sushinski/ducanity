using System;
using System.Collections.Generic;
using DukappCore.BL.Records;

namespace DukappCore.DAL
{
	public partial class DukappRepository 
	{
		public static ScheduleRecord GetScheduleRec(int id)
		{
			return instance.db.GetItem<ScheduleRecord>(id);
		}

		public static IEnumerable<ScheduleRecord> GetScheduleRecords ()
		{
			return instance.db.GetItems<ScheduleRecord>();
		}

		public static int SaveScheduleRecord (ScheduleRecord item)
		{
			return instance.db.SaveItem<ScheduleRecord>(item);
		}

		public static int DeleteScheduleRecord(int id)
		{
			return instance.db.DeleteItem<ScheduleRecord>(id);
		}
	}
}

