using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	class DieselEngine : AbstractCombustionEngine
	{
		public DieselEngine(double engineCapacity, double fuelConsumptionPer100) : base("Diesel", 1.2d)
		{
			_EngineCapacity = engineCapacity;
			_FuelConsumptionPer100 = fuelConsumptionPer100;
		}

		public override string ToString() =>
			$"{GetEngineTypeName()},{GetTaxCoefficientByEngineType()},{GetEngineCapacity()},{GetFuelConsumptionPer100()}";
	}
}
