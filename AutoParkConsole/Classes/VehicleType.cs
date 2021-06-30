using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	internal class VehicleType
	{
		public int Id { get; }
		public string TypeName { get; set; }
		public double TaxCoefficient { get; set; }

		public VehicleType()
		{

		}

		public VehicleType(int id, string name, double taxCoefficient = 1d)
		{
			TypeName = name;
			TaxCoefficient = taxCoefficient;
			Id = id;
		}

		public void Display()
		{
			Console.WriteLine($"TypeName = {TypeName}\nTaxCoeffiient = {TaxCoefficient}");
		}

		public override string ToString() => $"{TypeName},{TaxCoefficient}";
	}
}
