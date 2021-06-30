using System;
using System.IO;
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
			MyQueue<Vehicle> queue = new MyQueue<Vehicle>();

			Console.WriteLine("Queue:");
			for (int i = 0; i < vehilesForQueue.Count; i++)
			{
				queue.Enqueue(vehilesForQueue[i]);
				Console.WriteLine($"Automobile {vehilesForQueue[i].ModelName} in queue");
			}

			Console.WriteLine("Washed vehicles:");
			int queueCount = queue.Count();
			for (int i = 0; i < queueCount; i++)
			{
				Vehicle vehicle = queue.Dequeue();
				Console.WriteLine($"Automobile {vehicle.ModelName} washed");
			}
		}
	}
}
