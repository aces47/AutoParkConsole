using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	public class VehicleType
	{
		string _TypeName;
		double _TaxCoefficient;

		public VehicleType()
		{

		}

		public VehicleType(string name,double taxCoefficient = 1d)
		{
			_TypeName = name;
			_TaxCoefficient = taxCoefficient;
		}

		public string GetTypeName() => _TypeName;

		public void SetTypeName(string name) => _TypeName = name;

		public double GetTaxCoefficient() => _TaxCoefficient;

		public void SetTaxCoefficient(double taxCoefficient) => _TaxCoefficient = taxCoefficient;

		public void Display()
		{
			Console.WriteLine($"TypeName = {_TypeName}\nTaxCoeffiient = {_TaxCoefficient}");
		}

		public override string ToString() => $"{_TypeName},{_TaxCoefficient}";
	}
}
