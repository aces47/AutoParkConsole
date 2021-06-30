using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	internal abstract class AbstractEngine
	{
		public string EngineTypeName { get; }
		public double TaxCoefficientByEngineType { get; }

		public abstract double GetMaxKilometers(double tankCapacity);

		protected AbstractEngine(string engineTypeName, double taxCoefficientByEngineType = 1d)
		{
			EngineTypeName = engineTypeName;
			TaxCoefficientByEngineType = taxCoefficientByEngineType;
		}
	}
}
