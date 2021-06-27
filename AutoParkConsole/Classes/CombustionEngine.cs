using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	class CombustionEngine : Engine
	{
		protected double _EngineCapacity;
		protected double _FuelConsumptionPer100;

		public void SetEngineCapacity(double engineCapacity) => _EngineCapacity = engineCapacity;
		public double GetEngineCapacity() => _EngineCapacity;
		public void SetFuelConsumptionPer100(double fuelConsumprion) => _FuelConsumptionPer100 = fuelConsumprion;
		public double GetFuelConsumptionPer100() => _FuelConsumptionPer100;

		public double GetMaxKilometers(double tankCapacity) => tankCapacity * 100 / _FuelConsumptionPer100;

		public CombustionEngine(string typeName, double taxCoefficientByEngine)
			: base(typeName, taxCoefficientByEngine)
		{

		}
	}
}
