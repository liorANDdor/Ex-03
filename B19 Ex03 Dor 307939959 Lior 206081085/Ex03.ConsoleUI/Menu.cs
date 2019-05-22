using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
	class Menu
	{
		private List<string> m_Items;
		public List<string> Items
		{
			get
			{
				return m_Items;
			}
			set
			{
				m_Items = value;
			}
		}
	}
}
