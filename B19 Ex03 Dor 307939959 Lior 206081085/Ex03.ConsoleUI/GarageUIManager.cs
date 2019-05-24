using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
	class GarageUIManager
	{
		GarageLogicManager m_GarageLogicManager = new GarageLogicManager();
		UserInterfaceInputOutput m_UserInterfaceInputOutput = new UserInterfaceInputOutput();
		public enum OptionsOfUser
		{
			AddVechicles = 1,
			ShowListOfVechicles = 2,
			ChangeVechiclesSituation = 3,
			InflatingWheels = 4,
			FuelAFuelVechicles = 5,
			ChargeElectricVechicles = 6,
			GetInfoOfCar = 7,
			ExitProgram = 8
		}
		public int GetInputFromUser(Menu i_Menu)
		{
			int userChoose = 0;
			bool isInputValid = false;
			while(!isInputValid)
			{
				m_UserInterfaceInputOutput.ShowMenu(i_Menu);
				try
				{
					userChoose = m_UserInterfaceInputOutput.getInputFromUserByMenuLength(i_Menu.Items.Count);
					isInputValid = true;
				}
				catch (FormatException ex)
				{
					m_UserInterfaceInputOutput.PrintMessageToUser(ex.Message);
				}
				catch (ArgumentException ex)
				{
					m_UserInterfaceInputOutput.PrintMessageToUser(ex.Message);
				}
				if(!isInputValid)
				{
					m_UserInterfaceInputOutput.StopTheProgram();
				}
			}
			return userChoose;
		}
		public void runSystem()
		{
			const int userIsNotChose = 0;
			int userChoose = userIsNotChose;
			Menu mainMenu = CreateMainMenu();

			while(userChoose != (int) OptionsOfUser.ExitProgram)
			{

				userChoose = GetInputFromUser(mainMenu);
				if (userChoose == (int)OptionsOfUser.AddVechicles)
				{
					AddVechicles();
				}
				else if (userChoose == (int)OptionsOfUser.ShowListOfVechicles)
				{
					ShowListOfVechicles();
				}
				else if (userChoose == (int)OptionsOfUser.ChangeVechiclesSituation)
				{
					ChangeVechiclesSituation();
				}
				else if (userChoose == (int)OptionsOfUser.InflatingWheels)
				{
					InflatingWheels();
				}
				else if (userChoose == (int)OptionsOfUser.FuelAFuelVechicles)
				{
					FuelAFuelVechicles();
				}
				else if (userChoose == (int)OptionsOfUser.ChargeElectricVechicles)
				{
					ChargeElectricVechicles();
				}
				else if (userChoose == (int)OptionsOfUser.GetInfoOfCar)
				{
					GetInfoOfCar();
				}
				
			}

		}
		private Menu CreateMainMenu()
		{
			Menu mainMenu = new Menu();
			List<string> items= new List<string>();
			items.Add("Add a new vechicles");
			items.Add("Show list of vechicles");
			items.Add("Change vechicles situation");
			items.Add("Inflating wheels ");
			items.Add("Fuel a fuel vechicles");
			items.Add("Charge electric vechicles");
			items.Add("Get info of vechicles");
			items.Add("Exit program");
			mainMenu.Items = items;
			return mainMenu;

		}
		private Menu BuildMenu(string[]i_StringToMenu)
		{
			Menu newMenu = new Menu();
			List<string> items = new List<string>();
			foreach (string eachString in i_StringToMenu)
			{
				items.Add(eachString);	
			}
			newMenu.Items = items;
			return newMenu;

		}

		private void AddVechicles()
		{
			string plate;
			string[] stringOfEnum = Enum.GetNames(typeof(Vechicles.OprtionOfVechicles));
			Menu vechiclesMenu =BuildMenu(stringOfEnum);
			m_UserInterfaceInputOutput.ShowMenu(vechiclesMenu);
			Vechicles.OprtionOfVechicles vechicleType = (Vechicles.OprtionOfVechicles)GetInputFromUser(vechiclesMenu);
			m_UserInterfaceInputOutput.PrintMessageToUser("Please Enter a plate number: ");
			plate = m_UserInterfaceInputOutput.GetStringFromUser();
			try
			{

				m_GarageLogicManager.AddNewV(vechicleType, plate);
				List<StringPlusType> Questions = m_GarageLogicManager.getLsit(vechicleType,plate);
				List<StringPlusType> Answers = new List<StringPlusType>();
				string answer;
				foreach(StringPlusType q in Questions)
				{
					m_UserInterfaceInputOutput.PrintMessageToUser(q.Word);
					answer = m_UserInterfaceInputOutput.GetStringFromUser();
					Answers.Add(new StringPlusType( answer,q.mytype));
				}
				try
				{
					m_GarageLogicManager.SetVechicel(vechicleType, plate, Answers);
				}
				catch(Exception rx)
				{
					m_UserInterfaceInputOutput.PrintMessageToUser("one of your inputs is not as needed, please try again");
					m_GarageLogicManager.del(plate);
				}
			}
			catch(Exception ex)
			{
				m_UserInterfaceInputOutput.PrintMessageToUser(ex.Message);
			}
			
			m_UserInterfaceInputOutput.StopTheProgram();		
		}
		private void ShowListOfVechicles()
		{
			const int k_AllVechicles = 4;
			string[] c = Enum.GetNames(typeof(Vechicles.VehicleStatus));
			Menu VehicleStatusMenu = BuildMenu(c);
			VehicleStatusMenu.Items.Add("AllVechicles");
			m_UserInterfaceInputOutput.ShowMenu(VehicleStatusMenu);
			int userInput= GetInputFromUser(VehicleStatusMenu);
			List<string> plateOFvechiclesToShow = null;
			if (userInput == k_AllVechicles)
			{
				plateOFvechiclesToShow = m_GarageLogicManager.GetAllVechiclesPlate();
			}
			else
			{
				Vechicles.VehicleStatus vehicleStatus = (Vechicles.VehicleStatus)userInput;
				
				plateOFvechiclesToShow= m_GarageLogicManager.GetVechiclesPlateBySort(vehicleStatus);
			}
			if (plateOFvechiclesToShow.Count == 0)
			{
				m_UserInterfaceInputOutput.PrintMessageToUser("there are no vechicles for you!");
			}
			else
			{
				foreach(string eachPlate in plateOFvechiclesToShow)
				{
					m_UserInterfaceInputOutput.PrintMessageToUser(eachPlate);
				}
			}
			m_UserInterfaceInputOutput.StopTheProgram();
		}
		private void ChangeVechiclesSituation()
		{
			string[] stringOfEnum = Enum.GetNames(typeof(Vechicles.VehicleStatus));

			Menu vechicleStatusMenu = BuildMenu(stringOfEnum);
			m_UserInterfaceInputOutput.ShowMenu(vechicleStatusMenu);
			Vechicles.VehicleStatus vechicleStatus = (Vechicles.VehicleStatus)GetInputFromUser(vechicleStatusMenu);
			string plate;
			m_UserInterfaceInputOutput.PrintMessageToUser("Please Enter a plate number: ");
			plate = m_UserInterfaceInputOutput.GetStringFromUser();
			try
			{
				m_GarageLogicManager.SetVechiclesStatus(plate, vechicleStatus);
				m_UserInterfaceInputOutput.PrintMessageToUser("Status has been changed");
			}
			catch(Exception ex)
			{
				m_UserInterfaceInputOutput.PrintMessageToUser(ex.Message);
			}
			m_UserInterfaceInputOutput.StopTheProgram();
			
		}
		private void InflatingWheels()
		{
			Console.WriteLine("4");
		}
		private void FuelAFuelVechicles()
		{
			Console.WriteLine("5");
		}
		private void ChargeElectricVechicles()
		{
			Console.WriteLine("6");
		}
		private void GetInfoOfCar()
		{
			Console.WriteLine("7");
		}
	}
}
