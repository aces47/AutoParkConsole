using System;
using AutoParkConsole.Classes;

namespace AutoParkConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			VehicleType[] vehicleTypes =
				{ new("Bus", 1.2d), new("Car", 1d), new("Rink", 1.5d), new("Tractor", 1.2d) };

			Vehicle[] vehicles =
				{ new(new GasolineEngine(2d,8.1d),vehicleTypes[0],"Volkswagen Crafter","5427 AX-7",2022,2015,376000,Color.Blue,75),
			new(new GasolineEngine(2.18d,8.5d),vehicleTypes[0],"Volkswagen Crafter","6427 AX-7",2500,2014,227010,Color.White,75),
			new(new ElectricalEngine(50), vehicleTypes[0],"Electric Bus E321","6785 BA-7",12080,2019,20451,Color.Green,150),
			new(new DieselEngine(1.6d,7.2d), vehicleTypes[1],"Golf 5","8682 AX-7",1200,2006,230451,Color.Gray,55),
			new(new ElectricalEngine(25), vehicleTypes[1],"Tesla Model","E001 AA-7",2200,2019,10454,Color.White,70),
			new(new DieselEngine(3.2d,25d), vehicleTypes[2],"Hamm HD 12VV",null,3000,2016,122,Color.Yellow,20),
			new(new DieselEngine(4.75d,20.1d),vehicleTypes[3],"МТЗ Беларус - 1025.4","1145 AB-7",1200,2020,109,Color.Red,135), };

			Console.WriteLine("Array of vehicles:");
			VehicleHelper.PrintVehicleArray(vehicles);

			Vehicle maxKilometersVehicle = vehicles[0];
			double maxKilometersDistance = 
				maxKilometersVehicle.GetEngineTypeOfVehicle().GetMaxKilometers(vehicles[0].GetTankCapacity());

			for (int counter = 1; counter < vehicles.Length; counter++)
			{
				double maxKilometersCurrentVehicleDistance =
					vehicles[counter].GetEngineTypeOfVehicle().GetMaxKilometers(vehicles[counter].GetTankCapacity());
				if (maxKilometersDistance< maxKilometersCurrentVehicleDistance)
				{
					maxKilometersDistance = maxKilometersCurrentVehicleDistance;
					maxKilometersVehicle = vehicles[counter];
				}
			}

			Console.WriteLine($"This vehicle can drive max distance:{maxKilometersVehicle}\nMax distance is:{maxKilometersDistance:0.00}");

		}
	}
}
