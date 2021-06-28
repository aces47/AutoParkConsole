using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	internal abstract class Engine
	{
		public string EngineTypeName { get; }
		public double TaxCoefficientByEngineType { get; }

		public string GetEngineTypeName() => EngineTypeName;
		public double GetTaxCoefficientByEngineType() => TaxCoefficientByEngineType;

		public Engine(string engineTypeName, double taxCoefficientByEngineType = 1d)
		{
			EngineTypeName = engineTypeName;
			TaxCoefficientByEngineType = taxCoefficientByEngineType;
		}
	}
}
