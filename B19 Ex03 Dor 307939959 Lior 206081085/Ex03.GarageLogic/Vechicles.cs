using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public  class Vechicles
	{
		

		Engine f;
		private string m_NameOfOwners;
		private string m_numberOfOwners;
		private int m_VehicleStatus = (int)VehicleStatus.inRepairing;

		private float m_PrecentOfEnergy;
		private Wheel m_setOfWheels;

		public enum VehicleStatus
		{
			inRepairing=1,
			isFixed=2,
			isPaid=3
		}
		public enum OprtionOfVechicles
		{
			FuelCar = 1,
			ElectricCar = 2,
			FuelMotorcycle = 3,
			ElectricMotorcycle = 4,
			Truck = 5
		}
		public Vechicles(string i_nameOfOwner, string i_NumOfOwner, float i_PrecentOfEnergy)
		{
			m_NameOfOwners = i_nameOfOwner;
			m_numberOfOwners = i_NumOfOwner;
			m_PrecentOfEnergy = i_PrecentOfEnergy;
		}
		

	}
}
