using System;
using DukappCore.SQLite;

namespace DukappCore.BL.Contracts
{
	public abstract class RecordBase : IRecord
	{
		public RecordBase ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
	}
}

