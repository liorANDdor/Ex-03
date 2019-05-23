﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
	class VechiclesCreat
	{
	
		public Vechicles add(string plate, Vechicles.OprtionOfVechicles vechiclesType)
		{
			Vechicles newVechicle = null;
			if (vechiclesType == Vechicles.OprtionOfVechicles.ElectricCar)
			{
				newVechicle = new Car();
			}
			else if (vechiclesType == Vechicles.OprtionOfVechicles.FuelCar)
			{
				newVechicle = new Car();
			}
			else if (vechiclesType == Vechicles.OprtionOfVechicles.ElectricMotorcycle)
			{
				//newVechicle = new Motorcycle();
			}
			else if (vechiclesType == Vechicles.OprtionOfVechicles.FuelMotorcycle)
			{
				//newVechicle = new Motorcycle();
			}
			else if(vechiclesType == Vechicles.OprtionOfVechicles.Truck)
			{
				//newVechicle = new Truck();
			}
			return newVechicle;
		}
	}
}
