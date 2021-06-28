using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	internal static class VehicleHelper
	{
		public static void PrintVehicleArray(Vehicle[] vehicles)
		{
			foreach (Vehicle vehicle in vehicles)
			{
				Console.WriteLine(vehicle);
			}
		}

		public static (Vehicle min, Vehicle max) GetMaxAndMinMileageVehicles(Vehicle[] vehicles)
		{
			Vehicle max = vehicles[0];
			Vehicle min = vehicles[0];

			for (int counter = 1; counter < vehicles.Length; counter++)
			{
				if (vehicles[counter].Mileage > max.Mileage)
				{
					max = vehicles[counter];
				}
				else if (vehicles[counter].Mileage < min.Mileage)
				{
					min = vehicles[counter];
				}
			}

			return (min, max);
		}
	}
}
