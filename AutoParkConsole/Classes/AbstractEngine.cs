using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	public abstract class AbstractEngine
	{
		readonly string _EngineTypeName;
		readonly double _TaxCoefficientByEngineType;

		public string GetEngineTypeName() => _EngineTypeName;
		public double GetTaxCoefficientByEngineType() => _TaxCoefficientByEngineType;

		public abstract double GetMaxKilometers(double tankCapacity);

		protected AbstractEngine( string engineTypeName,double taxCoefficientByEngineType = 1d)
		{
			_EngineTypeName = engineTypeName;
			_TaxCoefficientByEngineType = taxCoefficientByEngineType;
		}
	}
}
