using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	internal class VehicleType
	{
		public string TypeName;
		public double TaxCoefficient;

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
