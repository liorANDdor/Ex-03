using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public abstract class  Engine
	{
		public enum EngineKinds
		{
			Electric=1,
			Fuel
		}
		private float m_MaxCapacity;
		private float m_CurrentCapacity;

		public float MaxCapacity
		{
			get
			{
				return m_MaxCapacity;
			}

			set
			{
				m_MaxCapacity = value;
			}
		}
		public float CurrCapacity
		{
			get
			{
				return m_CurrentCapacity;
			}

			set
			{
				if (value > m_MaxCapacity)
					throw new Exception();
				m_CurrentCapacity = value;
			}
		}
	}
}
