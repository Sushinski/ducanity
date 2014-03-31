using System;
using DukappCore.BL.Records;

namespace DukappCore.BL.Managers
{
	public static class PrefsManager
    {
		public static PrefsRecord GetPrefsRecordValue( string pref_name )
		{
            return DukappCore.DAL.DukappRepository.GetPrefsRecord(pref_name);
		}
		public static int UpdatePrefsRecord (PrefsRecord item)
		{
			return DukappCore.DAL.DukappRepository.UpdatePrefsRecord(item);
		}
        public static void ClearHistory()
        {
            DukappCore.DAL.DukappRepository.ClearHistory();
        }
    }
}

