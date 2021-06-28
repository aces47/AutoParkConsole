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
				collections.GetVehicleTypes()[1],
				"Tesla Model S",
				null,
				2025,
				2020,
				100,
				Color.Black,
				150));

			var vehilesForQueue = collections.GetVehicles();
			MyQueue<Vehicle> queue = new MyQueue<Vehicle>();

			Console.WriteLine("Queue:");
			for(int i=0;i<vehilesForQueue.Count;i++)
			{
				queue.Enqueue(vehilesForQueue[i]);
				Console.WriteLine($"Automobile {vehilesForQueue[i].GetModelName()} in queue");
			}

			Console.WriteLine("Washed vehicles:");
			for(int i=0;i<queue.Count();i++)
			{
				Vehicle vehicle = queue.Dequeue();
				Console.WriteLine($"Automobile {vehicle.GetModelName()} washed");
			}
		}
	}
}
