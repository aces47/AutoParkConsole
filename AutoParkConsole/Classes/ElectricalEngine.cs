using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	internal class ElectricalEngine : Engine
	{
		double _ElectricityConsumption;

		public double GetElectricityConsumption() => _ElectricityConsumption;
		public void SetElectricityConsumption(double electricityConsumption) => _ElectricityConsumption = electricityConsumption;

		public ElectricalEngine(double electricityConsumption) : base("Electrical",0.1)
		{
			_ElectricityConsumption = electricityConsumption;
		}

		public double GetMaxKilometers(double batterySize) => batterySize / _ElectricityConsumption;

		public override string ToString() => 
			$"{GetEngineTypeName()},{GetTaxCoefficientByEngineType()},{_ElectricityConsumption}";
	}
}
