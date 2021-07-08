using System;
using AutoParkConsole.Classes;

namespace AutoParkConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			const string pathToCSV = "D:\\GitHub\\AutoParkConsole\\AutoParkConsole\\";
			Collections collections =
				new Collections(pathToCSV + "types.csv", pathToCSV + "vehicles.csv", pathToCSV + "rents.csv");
			collections.Insert(8,
				new(8,
				new ElectricalEngine(25),
				collections.VehicleTypes[1],
				"Tesla Model S",
				null,
				2025,
				2020,
				100,
				Color.Black,
				150));

			var vehilesForQueue = collections.Vehicles;

			MyStack<Vehicle> stack = new MyStack<Vehicle>();

			Console.WriteLine("Stack:");
			for (int i = 0; i < vehilesForQueue.Count; i++)
			{
				stack.Push(vehilesForQueue[i]);
				Console.WriteLine($"Automobile {vehilesForQueue[i].ModelName} entering garage");
			}

			Console.WriteLine("Vehicles leaving the garage:");
			int stackCount = stack.Count();
			for (int i = 0; i < stackCount; i++)
			{
				Vehicle vehicle = stack.Pop();
				Console.WriteLine($"Automobile {vehicle.ModelName} leaved");
			}
		}
	}
}
