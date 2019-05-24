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
			Questions.Add(new StringPlusType("Color (red, blue, black, grey): ",typeof(string)));
			Questions.Add(new StringPlusType ("Num Of Door (2, 3, 4, 5): ",typeof(int)));
		
			return Questions;
		}
		public override void set(List<StringPlusType>  Answer)
		{
			base.set(Answer);
			int k = k_numOfMemberToInit;
			float i = float.Parse(Answer[k+1].Word);
			foreach (Wheel x in m_SetOfWheels)
			{
				x.Creator = Answer[k].Word;
				x.CurrPressure = i;
			}
			k += 2;
			bool check = Enum.TryParse<ColorOfCar>(Answer[k].Word, out  m_Color);
			k++;
			if(!check)
			{
				throw new Exception();
			}
			numOfDoors = int.Parse(Answer[k].Word);
			k++;
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
				
						
		}


	}
}
