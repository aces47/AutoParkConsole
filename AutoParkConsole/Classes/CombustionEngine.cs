using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	internal class CombustionEngine : Engine
	{
		public double EngineCapacity { get; set; }
		public double FuelConsumptionPer100 { get; set; }

		public double GetMaxKilometers(double tankCapacity) => tankCapacity * 100 / FuelConsumptionPer100;

		public CombustionEngine(string typeName, double taxCoefficientByEngine)
			: base(typeName, taxCoefficientByEngine)
		{

		}
	}
}
