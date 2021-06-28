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

			double averageTax = 0d;
			double max = vehicleTypes[0].GetTaxCoefficient();
			double currentTax;

			for (int counter = 0; counter < vehicleTypes.Length; counter++)
			{
				currentTax = vehicleTypes[counter].GetTaxCoefficient();
				if (max < currentTax)
				{
					max = currentTax;
				}

				vehicleTypes[counter].Display();
				averageTax += currentTax;

				if (counter == vehicleTypes.Length - 1)
				{
					averageTax /= vehicleTypes.Length;
					vehicleTypes[counter].SetTaxCoefficient(1.3d);
				}
			}

			foreach (VehicleType vehicle in vehicleTypes)
			{
				Console.WriteLine($"{vehicle}");
			}

			vehicleTypes[^1].SetTaxCoefficient(1.3d);

			Console.WriteLine($"Max tax:{max}\nAverage before changes tax:{averageTax:0.00}");
		}
	}
}
