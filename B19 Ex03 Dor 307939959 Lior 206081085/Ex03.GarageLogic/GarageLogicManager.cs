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
		public List<string> GetVechiclesPlateBySort(Vechicles.VehicleStatus vehicleStatus)
		{
			List<string> ListOfPlate = new List<string>();
			foreach (var item in m_ListOfVechicles)
			{
				if(item.Value.Status== vehicleStatus)
				{
					ListOfPlate.Add(item.Key);
				}
			}
			return ListOfPlate;
		}
		public List<string> GetAllVechiclesPlate()
		{
			List<string> ListOfPlate = new List<string>();
			foreach(var item in m_ListOfVechicles)
			{
				ListOfPlate.Add(item.Key);
			}
			return ListOfPlate;

		}
		public void SetVechiclesStatus(string i_PlateNumber,Vechicles.VehicleStatus i_VechiclesStatus)
		{

			if (!m_ListOfVechicles.ContainsKey(i_PlateNumber))
			{
				throw new Exception("there are not Plate like that, try again");
			}
			else
			{
				m_ListOfVechicles[i_PlateNumber].Status = i_VechiclesStatus;
			}
		}
		public List <StringPlusType> getLsit(Vechicles.OprtionOfVechicles vechicleType, string plate)
		{
			List<StringPlusType> ListToReturn = null;
			ListToReturn= m_ListOfVechicles[plate].getQuestions();
			return ListToReturn;
		}
		public void SetVechicel(Vechicles.OprtionOfVechicles vechicleType, string plate,List<StringPlusType> Answers)
		{
			m_ListOfVechicles[plate].set(Answers);
		}
		public void del(string plate)

		{
			m_ListOfVechicles.Remove(plate);
		
		}
		public string getinfo(string plate)
		{
			string x = null;
			if (!m_ListOfVechicles.ContainsKey(plate))
			{
				throw new Exception("there are not Plate like that, try again");
			}
			else
			{
				x= m_ListOfVechicles[plate].GetInfo();
			}
			return x;
		}


	}


}
