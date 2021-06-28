using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	private class VehicleType
	{
		private string _typeName;
		private double _taxCoefficient;

		public VehicleType()
		{

		}

		public VehicleType(string name, double taxCoefficient = 1d)
		{
			_typeName = name;
			_taxCoefficient = taxCoefficient;
		}

		public string GetTypeName() => _typeName;

		public void SetTypeName(string name) => _typeName = name;

		public double GetTaxCoefficient() => _taxCoefficient;

		public void SetTaxCoefficient(double taxCoefficient) => _taxCoefficient = taxCoefficient;

		public void Display()
		{
			Console.WriteLine($"TypeName = {_typeName}\nTaxCoeffiient = {_taxCoefficient}");
		}

		public override string ToString() => $"{_typeName},{_taxCoefficient}";
	}
}
