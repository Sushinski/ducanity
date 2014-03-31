using System;

namespace DukappCore.BL.Objects
{
	public enum DietPhaseId
	{
		DP_Default = 0,
		DP_Attack=1,
		DP_Cruise=2,
		DP_Consolidation=3,
		DP_Stabilization=4
	}

    public class DietPhase : IComparable
	{
		// phase id for graphic description
		protected DietPhaseId m_phase_id{ get; set;}
		// phase name
		protected string m_phase_name{ get; set; }
        protected string m_db_name;

		public override string ToString()
		{
            return m_db_name;
		}
          
        public string ToPrintString()
        {
            return m_phase_name;
        }

        public int CompareTo(Object obj)
        {
            DietPhase dp = obj as DietPhase;
            if (this.m_phase_id < dp.m_phase_id)
                return -1;
            else if (this.m_phase_id > dp.m_phase_id)
                return 1;
            else
                return 0;
        }

        public static bool operator< (DietPhase a, DietPhase b)
        {
            return a.m_phase_id < b.m_phase_id;
        }

        public static bool operator> (DietPhase a, DietPhase b)
        {
            return a.m_phase_id >= b.m_phase_id;
        } 

        public static bool operator== (DietPhase a, DietPhaseId b)
        {
            return a.m_phase_id == b; 
        }

        public static bool operator!= (DietPhase a, DietPhaseId b)
        {
            return a.m_phase_id != b; 
        }

        public int GetId()
        {
            return (int)m_phase_id;
        }

		public DietPhase ( DietPhaseId phase )
		{
			m_phase_id = phase;
			// [ToDo] add internacionalization
			switch (phase) 
			{
            case DietPhaseId.DP_Default:
                {
                    m_phase_name = "Метод Пьера Дюкана";
                    m_db_name = "";
                    break;
                }
			case DietPhaseId.DP_Attack:
				{
                    m_phase_name = "Фаза \"Атака\"";
                        m_db_name = "Attack";
					break;
				}
			case DietPhaseId.DP_Cruise:
				{
                    m_phase_name = "Фаза \"Круиз\"";
                    m_db_name = "Cruise";
					break;
				}
			case DietPhaseId.DP_Consolidation:
				{
                    m_phase_name= "Фаза \"Консолидация\"";
                    m_db_name = "Consolidation";
					break;
				}
			case DietPhaseId.DP_Stabilization:
				{
                    m_phase_name = "Фаза \"Стабилизация\"";
                    m_db_name = "Stabilization";
					break;
				}
			default:
				{
					m_phase_name = "All";
                        m_db_name = "";
					break;
				}
			}
		}
	}
}

