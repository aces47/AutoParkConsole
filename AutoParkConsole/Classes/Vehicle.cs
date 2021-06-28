using System;

namespace AutoParkConsole.Classes
{
	internal class Vehicle : IComparable<Vehicle>
	{
		public VehicleType VehicleType { get; }
		public string ModelName { get; }
		public string GosNumber { get; set; }
		public int Weight { get; set; }
		public int ManufactureYear { get; }
		public int Mileage { get; set; }
		public Color Color { get; set; }
		public int TankCapacity { get; set; }

		public Vehicle()
		{

		}

		public Vehicle(
			VehicleType type,
			string model,
			string gosNumber,
			int weight,
			int manufactureYear,
			int mileage,
			Color color,
			int tankCapacity = 0)
		{
			VehicleType = type;
			ModelName = model;
			GosNumber = gosNumber;
			Weight = weight;
			ManufactureYear = manufactureYear;
			Mileage = mileage;
			Color = color;
			TankCapacity = tankCapacity;
		}

		public double GetCalcTaxPerMonth() => (Weight * 0.0013d) + (VehicleType.TaxCoefficient * 30) + 5;

		public override string ToString() =>
			$"{VehicleType},{ModelName},{GosNumber},{Weight},{ManufactureYear},{Mileage},{Color},{TankCapacity}";

		public int CompareTo(Vehicle other)
		{
			double thisTaxCoefficient = VehicleType.TaxCoefficient;
			double otherTaxCoefficient = other.VehicleType.TaxCoefficient;

			return thisTaxCoefficient.CompareTo(otherTaxCoefficient);
		}

	}
}
