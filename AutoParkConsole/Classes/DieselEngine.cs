using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	internal class DieselEngine : AbstractCombustionEngine
	{
		public DieselEngine(double engineCapacity, double fuelConsumptionPer100) : base("Diesel", 1.2d)
		{
			EngineCapacity = engineCapacity;
			FuelConsumptionPer100 = fuelConsumptionPer100;
		}

		public override string ToString() =>
			$"{EngineTypeName},{TaxCoefficientByEngineType},{EngineCapacity},{FuelConsumptionPer100}";
	}
}
