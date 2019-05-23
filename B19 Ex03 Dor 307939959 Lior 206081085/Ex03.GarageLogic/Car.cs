using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	class Car : Vechicles
	{
		public enum ColorOfCar
		{
			red=1,
			blue,
			black,
			grey
		}
		private int numOfDoors;
		private ColorOfCar m_Color;
		public Car():base("lior","lior",5)
		{
			m_Color = ColorOfCar.black;
		}
		

	}
}
