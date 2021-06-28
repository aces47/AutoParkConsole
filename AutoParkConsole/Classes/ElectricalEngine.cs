﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	internal class ElectricalEngine : Engine
	{
		public double ElectricityConsumption { get; set; }


		public ElectricalEngine(double electricityConsumption) : base("Electrical", 0.1d)
		{
			ElectricityConsumption = electricityConsumption;
		}

		public double GetMaxKilometers(double batterySize) => batterySize / ElectricityConsumption;

		public override string ToString() =>
			$"{EngineTypeName},{TaxCoefficientByEngineType},{ElectricityConsumption}";
	}
}
