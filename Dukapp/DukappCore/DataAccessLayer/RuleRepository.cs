using System;
using System.Collections.Generic;
using DukappCore.BL.Records;
using DukappCore.BL.Objects;

namespace DukappCore.DAL
{
	public partial class DukappRepository 
	{
		public static RuleRecord GetRule(int id)
		{
			return instance.db.GetItem<RuleRecord>(id);
		}

		public static IEnumerable<RuleRecord> GetRuleRecords ()
		{
			return instance.db.GetItems<RuleRecord>();
		}

		public static int SaveRuleRecord (RuleRecord item)
		{
			return instance.db.SaveItem<RuleRecord>(item);
		}

		public static int DeleteRuleRecord(int id)
		{
			return instance.db.DeleteItem<RuleRecord>(id);
		}

		public static string GetRuleForStage( DietPhase phase )
		{
			return instance.db.GetItemsWParam<RuleRecord>("RuleRecord", "RuleName", phase.GetId().ToString())[0].RuleText.ToString();
		}
	}
}

