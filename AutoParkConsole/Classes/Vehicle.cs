using System;

namespace AutoParkConsole.Classes
{
	internal class Vehicle : IComparable<Vehicle>
	{
		public int Id { get; }
		public AbstractEngine AbstractEngine { get; }
		public VehicleType VehicleType { get; }
		public string ModelName { get; }
		public string GosNumber { get; set; }
		public int Weight { get; set; }
		public int ManufactureYear { get; }
		public int Mileage { get; set; }
		public Color Color { get; set; }
		public double TankCapacity { get; set; }
		public List<Rent> Rents { get; set; }

		public Vehicle() { }

		public Vehicle(
			AbstractEngine engine,
			VehicleType type,
			string model,
			string gosNumber,
			int weight,
			int manufactureYear,
			int mileage,
			Color color,
			int tankCapacity = 0)
		{
			AbstractEngine = engine;
			VehicleType = type;
			ModelName = model;
			GosNumber = gosNumber;
			Weight = weight;
			ManufactureYear = manufactureYear;
			Mileage = mileage;
			Color = color;
			TankCapacity = tankCapacity;
			Id = id;
		}

		public decimal GetTotalVehicleIncome()
		{
			if (Rents != null)
			{
				decimal totalIncome = 0;
				foreach (Rent rent in Rents)
				{
					totalIncome += rent.RentCost;
				}

				return totalIncome;
			}

			return 0m;
		}

		public double GetCalcTaxPerMonth() =>
			(Weight * 0.0013d) + (VehicleType.TaxCoefficient * AbstractEngine.TaxCoefficientByEngineType * 30) + 5;

		public override bool Equals(object obj)
		{
			if (obj is Vehicle)
			{
				var other = obj as Vehicle;
				if (VehicleType == other.VehicleType && ModelName.Equals(other.ModelName))
				{
					return true;
				}
			}

			return false;
		}
		public override string ToString() =>
			$"{AbstractEngine},{VehicleType},{ModelName},{GosNumber},{Weight},{ManufactureYear},{Mileage},{Color},{TankCapacity}";

		public int CompareTo(Vehicle other)
		{
			double thisTaxCoefficient = VehicleType.TaxCoefficient;
			double otherTaxCoefficient = other.VehicleType.TaxCoefficient;

			return thisTaxCoefficient.CompareTo(otherTaxCoefficient);
		}

	}
}
