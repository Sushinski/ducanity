using System;
using System.Collections.Generic;
using DukappCore.BL.Records;
using DukappCore.DAL;
using DukappCore.BL.Objects;

namespace DukappCore.BL.Managers {

	public static class RecordManager {

		public static RuleRecord GetRule(int id)
		{
			return DukappRepository.GetRule(id);
		}

		public static IList<RuleRecord> GetRuleRecords ()
		{
			return new List<RuleRecord>(DukappRepository.GetRuleRecords());
		}

		public static int SaveRuleRecord (RuleRecord item)
		{
			return DukappRepository.SaveRuleRecord(item);
		}

		public static int DeleteRuleRecord(int id)
		{
			return DukappRepository.DeleteRuleRecord(id);
		}

        public static string GetRuleForStage( DietPhase phase )
		{
			return DukappRepository.GetRuleForStage( phase );
		}
	}
}