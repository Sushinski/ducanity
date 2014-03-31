using System;
using DukappCore.SQLite;
using DukappCore.BL.Contracts;
using DukappCore.BL.Objects;

namespace DukappCore.BL.Records
{
	public class ScheduleRecord : IRecord
	{
		public ScheduleRecord(){
		}
		public ScheduleRecord ( DateTime day, DietPhaseId phase, int weight = 0 )
		{
			this.m_date = day;
			switch (phase) {
			case(DietPhaseId.DP_Attack):
				this.m_phase = 1;
				break;
			case(DietPhaseId.DP_Cruise):
				this.m_phase = 2;
				break;
			case(DietPhaseId.DP_Consolidation):
				this.m_phase = 3;
				break;
			case(DietPhaseId.DP_Stabilization):
				this.m_phase = 4;
				break;
			case(DietPhaseId.DP_Default):
				this.m_phase = 0;
				break;
			}
			this.m_weight = weight;
		}
		/// <summary>
		/// This is the rules record - contains rule id, name, and text itself 
		/// </summary>
		[PrimaryKey, AutoIncrement]
		public int ID{ get; set; }
		public DateTime m_date { get; set; }
		public int m_phase { get; set; }
		public int m_weight { get; set; }
		public string m_text { get; set; }

	}
}

