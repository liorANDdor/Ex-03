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
		public Car(Engine i_Engine,string i_numOfLicensePlate):base(i_Engine, i_numOfLicensePlate)
		{
			m_Color = ColorOfCar.black;
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
			m_Color = (ColorOfCar)Answer[k_numOfMemberToInit].Word;
						
		}


	}
}
