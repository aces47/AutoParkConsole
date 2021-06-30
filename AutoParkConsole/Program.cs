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
			collections.Print();
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
			collections.Delete(1);
			collections.Delete(4);
			collections.Print();
			collections.Sort();
			collections.Print();

		}
	}
}
