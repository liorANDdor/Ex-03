using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
	class UserInterfaceInputOutput
	{
		public void ShowMenu(Menu i_Menu)
		{
			Console.Clear();
			int i = 1;
			foreach(string item in i_Menu.Items)
			{
				Console.WriteLine("{0}. {1}", i, item);
				i++;
			}
		}
		public int getInputFromUserByMenuLength(int i_NumOfOptionsToChoose)
		{
			int userInputToInt = 0;
			bool isConvertedToInt = false;
			string userInput;
			Console.WriteLine("\nPlease enter your choose: ");
			userInput = Console.ReadLine();
			isConvertedToInt = int.TryParse(userInput, out userInputToInt);
			if(!isConvertedToInt)
			{
				throw new FormatException("Invalid input");
			}
			else if (userInputToInt < 1 || userInputToInt > i_NumOfOptionsToChoose)
			{
				throw new ArgumentException("Input is out of range");
			}
			else
			{
				return userInputToInt;
			}
		}
		public void StopTheProgram()
		{
			Console.WriteLine("Press any key to continue to return the menu");
			string userInput;
			userInput = Console.ReadLine();
		}
		public void PrintMessageToUser(string i_Message)
		{
			Console.WriteLine(i_Message);
		}
		public string GetStringFromUser()
		{
			string userInput;
			userInput = Console.ReadLine();
			return userInput;
		}


	}
}
