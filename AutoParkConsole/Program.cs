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
				{ new(vehicleTypes[0],"Volkswagen Crafter","5427 AX-7",2022,2015,376000,Color.Blue),
			new(vehicleTypes[0],"Volkswagen Crafter","6427 AX-7",2500,2014,227010,Color.White),
			new(vehicleTypes[0],"Electric Bus E321","6785 BA-7",12080,2019,20451,Color.Green),
			new(vehicleTypes[1],"Golf 5","8682 AX-7",1200,2006,230451,Color.Gray),
			new(vehicleTypes[1],"Tesla Model","E001 AA-7",2200,2019,10454,Color.White),
			new(vehicleTypes[2],"Hamm HD 12VV",null,3000,2016,122,Color.Yellow),
			new(vehicleTypes[3],"МТЗ Беларус - 1025.4","1145 AB-7",1200,2020,109,Color.Red), };

			Console.WriteLine("Array of vehicles before sorting:");
			VehicleHelper.PrintVehicleArray(vehicles);
			Array.Sort(vehicles);
			Console.WriteLine("Array of vehicles after sorting:");
			VehicleHelper.PrintVehicleArray(vehicles);

			var minAndMaxVehicles = VehicleHelper.GetMaxAndMinMileageVehicles(vehicles);

			Console.WriteLine($"Minimal mileage vehicle is:{minAndMaxVehicles.min}\n" +
				$"Maximal mileage vehicle is:{minAndMaxVehicles.max}");

		}
	}
}
