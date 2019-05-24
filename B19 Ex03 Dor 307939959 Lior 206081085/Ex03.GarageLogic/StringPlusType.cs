using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public class StringPlusType
	{
		string word;
		Type type;
		public StringPlusType(string s, Type t)
		{
			word = s;
			type = t;
		}
		public string Word
		{
			get
			{
				return word;
			}
		}
		public Type mytype
		{
			get
			{
				return type;
			}
		}

	}
}
