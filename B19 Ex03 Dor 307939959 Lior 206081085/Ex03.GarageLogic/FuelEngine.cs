using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public class FuelEngine : Engine
	{
		private FuelKinds m_FuelKind;
		public enum FuelKinds
		{
			Soler=1,
			Octan95,
			Octan96,
			Octan98
		}
		public FuelKinds FuelKind
		{
			get
			{
				return m_FuelKind;
			}
			set
			{
				m_FuelKind = value;
			}
		}

	}
}
