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
		public Car(Engine i_Engine, string i_numOfLicensePlate) : base(i_Engine, i_numOfLicensePlate)
		{
			m_SetOfWheels = new Wheel[4];
			for (int i = 0; i < 4; i++)
			{
				m_SetOfWheels[i] = new Wheel(31);
			}
		}
		public override List<StringPlusType> getQuestions()
		{
			List<StringPlusType> Questions = base.getQuestions();
			Questions.Add(new StringPlusType(String.Format("Current Wheel Presure (0-{0}) ",m_SetOfWheels[0].MaxPressure), typeof(float)));
			Questions.Add(new StringPlusType("Color (red, blue, black, grey): ",typeof(string)));
			Questions.Add(new StringPlusType ("Num Of Door (2, 3, 4, 5): ",typeof(int)));
		
			return Questions;
		}
		public override void set(List<StringPlusType>  Answer)
		{
			base.set(Answer);
			int indInArrAnswer = k_numOfMemberToInit;
			float j = float.Parse(Answer[indInArrAnswer+1].Word);
			if (j > m_SetOfWheels[0].MaxPressure || j < 0)
			{
				throw new Exception();
			}

			for (int i = 0; i < 4; i++)
			{
				m_SetOfWheels[i].CurrPressure = j;
				m_SetOfWheels[i].Creator = Answer[indInArrAnswer + 1].Word;

			}
			indInArrAnswer += 2;
			bool check = Enum.TryParse<ColorOfCar>(Answer[indInArrAnswer].Word, out  m_Color);
			
			indInArrAnswer++;
			if(!check)
			{
				throw new Exception();
			}
			numOfDoors = int.Parse(Answer[indInArrAnswer].Word);
			indInArrAnswer++;
			if (numOfDoors > 5 || numOfDoors < 2)
			{
				throw new Exception();
			}
			if (m_Engine is FuelEngine)
			{
				(m_Engine as FuelEngine).FuelKind = FuelEngine.FuelKinds.Octan96;
				m_Engine.MaxCapacity = 55;
				m_Engine.CurrCapacity =m_PrecentOfEnergy/100* m_Engine.MaxCapacity;
			}
			else
			{
				(m_Engine as ElectricEngine).MaxCapacity = 1.8f;
			}
				
						
		}
		public override string GetInfo()
		{
			string x;
			x = String.Format(
			@"name of Owners: {0}
numofDoor: {1}
maxEne: {2}
color: {3}
c: {4}", m_NameOfOwners, numOfDoors,m_Engine.MaxCapacity,m_Color,(m_Engine as FuelEngine).FuelKind);
			return x;
		}


	}
}
