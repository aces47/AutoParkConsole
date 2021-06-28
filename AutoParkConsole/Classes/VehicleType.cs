using System;

namespace AutoParkConsole.Classes
{
	internal class VehicleType
	{
		public string TypeName { get; set; }
		public double TaxCoefficient { get; set; }

		public VehicleType()
		{

		}

		public VehicleType(string name, double taxCoefficient = 1d)
		{
			TypeName = name;
			TaxCoefficient = taxCoefficient;
		}

		public void Display()
		{
			Console.WriteLine($"TypeName = {TypeName}\nTaxCoeffiient = {TaxCoefficient}");
		}

		public override string ToString() => $"{TypeName},{TaxCoefficient}";
	}
}
