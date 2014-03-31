using System;
using DukappCore.SQLite;
using DukappCore.BL.Contracts;

namespace DukappCore.BL.Records
{
	public class RuleRecord : IRecord
	{
		public RuleRecord ()
		{
		}
		/// <summary>
		/// This is the rules record - contains rule id, name, and text itself 
		/// </summary>
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string RuleName { get; set; }
		public string RuleText { get; set; }
	}
}

