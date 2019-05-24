using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public class Wheel
	{
		/*
		 שם יצרן )string)
o לחץ אוויר נוכחי )float)
o לחץ אוויר מקסימאלי שקבע היצרן )float)
o פעולת ניפוח )מתודה שמקבלת נתון לגבי כמה אוויר להוסיף לגלגל, ומשנה את
מצב לחץ האוויר אם הוא לא חורג מהמקסימום(
		 */
		private string m_NameOfCreator = null;
		private float m_CurrentWheelPressure = 0;
		private float m_MaxWheelPressure = 0;
	
		public Wheel(float i_MaxWheelPressure)
		{
			m_MaxWheelPressure = i_MaxWheelPressure;
		}
		public float CurrPressure
		{
			set
			{
				CurrPressure = value;
			}
			get
			{
				return CurrPressure;
			}
		}
		public string Creator
		{
			set
			{
				m_NameOfCreator = value;
			}
			get
			{
				return m_NameOfCreator;
			}
		}


	}
		
}
