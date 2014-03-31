using System;
using DukappCore.BL.Records;

namespace DukappCore.DAL
{
	public partial class DukappRepository
    {
		public static PrefsRecord GetPrefsRecord( string pref_name )
		{
			return instance.db.GetItemsWParam<PrefsRecord>("PrefsRecord", "PrefName", "\"" + pref_name + "\"")[0];
		}

		public static int UpdatePrefsRecord( PrefsRecord item )
		{
			return instance.db.SaveItem<PrefsRecord>(item);
		}

        public static void ClearHistory()
        {
            instance.db.DeleteAllRecords<ScheduleRecord>();
        }
    }
}

