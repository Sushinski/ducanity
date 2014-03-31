using System;
using DukappCore.SQLite;
using DukappCore.BL.Contracts;

namespace DukappCore.BL.Records
{
	public class PrefsRecord : IRecord
    {
        public PrefsRecord()
        {
        }
		public PrefsRecord( string prefName, string prefValue )
		{
			PrefName = prefName;
			PrefValue = prefValue;
		}
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string PrefName { get; set; }
		public string PrefValue { get; set; }
    }
}

