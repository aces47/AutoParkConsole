using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	public static class VehicleHelper
	{
		public static void PrintVehicleArray(Vehicle[] vehicles)
		{
			foreach (Vehicle vehicle in vehicles)
			{
				Console.WriteLine($"{vehicle}");
			}
		}

		public static (Vehicle min,Vehicle max) GetFindMaxAndMinMileageVehicles(Vehicle[] vehicles)
		{
			Vehicle max = vehicles[0];
			Vehicle min = vehicles[0];

			for(int counter=1; counter<vehicles.Length;counter++)
			{
				if(vehicles[counter].GetMileage()>max.GetMileage())
				{
					max = vehicles[counter];
				}
				else if(vehicles[counter].GetMileage()<min.GetMileage())
				{
					min = vehicles[counter];
				}
			}

			return (min, max);
		}
	}
}
