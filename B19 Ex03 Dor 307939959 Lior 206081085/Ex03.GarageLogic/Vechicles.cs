using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public  class Vechicles
	{
		protected const int k_numOfMemberToInit = 3;
		protected string m_VehicleModelName;
		protected string m_LicensePlateNumber;//
		protected Engine m_Engine;//
		protected string m_NameOfOwners;
		protected string m_PhoneNumberOfOwners;
		protected VehicleStatus m_VehicleStatus = VehicleStatus.inRepairing;//
		protected float m_PrecentOfEnergy;
		protected Wheel[] m_SetOfWheels;

		public VehicleStatus Status
		{
			get
			{
				return m_VehicleStatus;
			}
			set
			{
				m_VehicleStatus = value;
			}
		}
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
			Truck = 5,
		}
		public Vechicles(Engine i_Engine, string i_LicensePlateNumber)
		{
			m_Engine = i_Engine;
			m_LicensePlateNumber = i_LicensePlateNumber;
		}
		public virtual List<StringPlusType> getQuestions()
		{
			List<StringPlusType> Questions = new List<StringPlusType>();
			Questions.Add(new StringPlusType("Name Of Owner: ", typeof(string)));
			Questions.Add(new StringPlusType("Phone number Of Owner: ", typeof(string)));
			Questions.Add(new StringPlusType("Precent Of Energy: ", typeof(float)));
			Questions.Add(new StringPlusType("Wheel Creator ", typeof(string)));
			Questions.Add(new StringPlusType("Current Wheel Presure ", typeof(float)));

			return Questions;
		}
		public virtual void set(List<StringPlusType> Answer)
		{
			foreach(StringPlusType x in Answer)
			{
				
					var v = Convert.ChangeType(x.Word, x.mytype);
			
			}
			m_NameOfOwners = Answer[0].Word;
			m_PhoneNumberOfOwners = Answer[1].Word;
			m_PrecentOfEnergy = float.Parse(Answer[2].Word);
			if (m_PrecentOfEnergy > 100 || m_PrecentOfEnergy < 0)
				throw new Exception();
		}


	}
}
