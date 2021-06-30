using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	internal abstract class AbstractCombustionEngine : AbstractEngine
	{
		public double EngineCapacity { get; set; }
		public double FuelConsumptionPer100 { get; set; }

		public override double GetMaxKilometers(double tankCapacity) => tankCapacity * 100 / FuelConsumptionPer100;

		public AbstractCombustionEngine(string typeName, double taxCoefficientByEngine)
			: base(typeName, taxCoefficientByEngine)
		{

		}
	}
}
