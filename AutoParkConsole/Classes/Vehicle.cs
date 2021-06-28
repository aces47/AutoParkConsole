using System;

namespace AutoParkConsole.Classes
{
	internal class Vehicle : IComparable<Vehicle>
	{

		private readonly VehicleType _vehicleType;
		private readonly string _modelName;
		private string _gosNumber;
		private int _weight;
		private readonly int _manufactureYear;
		private int _mileage;
		private Color _color;
		private int _tankCapacity;

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
			_vehicleType = type;
			_modelName = model;
			_gosNumber = gosNumber;
			_weight = weight;
			_manufactureYear = manufactureYear;
			_mileage = mileage;
			_color = color;
			_tankCapacity = tankCapacity;
		}

		public string GetVehicleType() => $"{_vehicleType}";
		public string GetModelName() => $"{_modelName}";
		public void SetGosNumber(string gosNumber) => _gosNumber = gosNumber;
		public string GetGosNumber() => $"{_gosNumber}";
		public void SetWeight(int weight) => _weight = weight;
		public int GetWeight() => _weight;
		public int GetManufactureYear() => _manufactureYear;
		public void SetMileage(int mileage) => _mileage = mileage;
		public int GetMileage() => _mileage;
		public void SetColor(Color color) => _color = color;
		public Color GetColor() => _color;
		public void SetTankCapacity(int tankCapacity) => _tankCapacity = tankCapacity;
		public int GetTankCapacity() => _tankCapacity;

		public double GetCalcTaxPerMonth() => (_weight * 0.0013d) + (_vehicleType.GetTaxCoefficient() * 30) + 5;

		public override string ToString() =>
			$"{_vehicleType},{_modelName},{_gosNumber},{_weight},{_manufactureYear},{_mileage},{_color},{_tankCapacity}";

		public int CompareTo(Vehicle other)
		{
			double thisTaxCoefficient = _vehicleType.GetTaxCoefficient();
			double otherTaxCoefficient = other._vehicleType.GetTaxCoefficient();

			return thisTaxCoefficient.CompareTo(otherTaxCoefficient);
		}

	}
}
