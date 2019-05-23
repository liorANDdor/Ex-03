using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	
	public class GarageLogicManager
	{
		private Dictionary<string,Vechicles> m_ListOfVechicles = new Dictionary<string, Vechicles>();
		private VechiclesCreat m_VeichiclesCreator = new VechiclesCreat();
		public void AddNewV(Vechicles.OprtionOfVechicles i_VechicleType, string i_PlateNumber)
		{
			if (m_ListOfVechicles.ContainsKey(i_PlateNumber))
				throw new Exception("there are already plate nuber like that, try again.");
			else
			{
				Vechicles newVechicle = m_VeichiclesCreator.add(i_PlateNumber, i_VechicleType);
				m_ListOfVechicles.Add(i_PlateNumber, newVechicle);
			}
		}
	}

	
}
