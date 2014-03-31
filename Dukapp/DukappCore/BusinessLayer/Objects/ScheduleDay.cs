using System;

namespace DukappCore.BL.Objects
{
	public class ScheduleDay
	{
		public ScheduleDay ( DateTime day, DietPhase phase, int weight = 0 )
		{
			m_day = day;
			m_phase = phase;
			m_weight = weight;
		}
		// day date
		public DateTime m_day{ get; set; }
		// day phase
		public DietPhase m_phase{ get; set; }
		// day weight
		public int m_weight{ get; set; }

	}
}

