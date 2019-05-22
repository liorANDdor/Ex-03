using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	class Vechicles
	{
		Engine f;
		private string m_NameOfOwners;
		private string m_numberOfOwners;
		private int m_VehicleStatus = (int)VehicleStatus.inRepairing;
		private string m_NameOfModel;
		private string m_LicensePlate;
		private float m_PrecentOfEnergy;
		private Wheel m_setOfWheels;

		public enum VehicleStatus
		{
			inRepairing=1,
			isFixed=2,
			isPaid=3
		}

	}
}
