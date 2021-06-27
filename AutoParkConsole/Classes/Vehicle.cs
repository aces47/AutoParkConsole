using System;

namespace AutoParkConsole.Classes
{
	public enum Color
	{
		Black = 1,
		White,
		Red,
		Gray,
		Yellow,
		Blue,
		Green
	}

	public class Vehicle : IComparable<Vehicle>
	{

		readonly VehicleType _VehicleType;
		readonly string _ModelName;
		string _GosNumber;
		int _Weight;
		readonly int _ManufactureYear;
		int _Mileage;
		Color _Color;
		int _TankCapacity;

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
			_VehicleType = type;
			_ModelName = model;
			_GosNumber = gosNumber;
			_Weight = weight;
			_ManufactureYear = manufactureYear;
			_Mileage = mileage;
			_Color = color;
			_TankCapacity = tankCapacity;
		}

		public string GetVehicleType() => $"{_VehicleType}";
		public string GetModelName() => $"{_ModelName}";
		public void SetGosNumber(string gosNumber) => _GosNumber = gosNumber;
		public string GetGosNumber() => $"{_GosNumber}";
		public void SetWeight(int weight) => _Weight = weight;
		public int GetWeight() => _Weight;
		public int GetManufactureYear() => _ManufactureYear;
		public void SetMileage(int mileage) => _Mileage = mileage;
		public int GetMileage() => _Mileage;
		public void SetColor(Color color) => _Color = color;
		public Color GetColor() => _Color;
		public void SetTankCapacity(int tankCapacity) => _TankCapacity = tankCapacity;
		public int GetTankCapacity() => _TankCapacity;

		public double GetCalcTaxPerMonth() => (_Weight * 0.0013d) + (_VehicleType.GetTaxCoefficient() * 30) + 5;

		public override string ToString() =>
			$"{_VehicleType},{_ModelName},{_GosNumber},{_Weight},{_ManufactureYear},{_Mileage},{_Color},{_TankCapacity}";

		public int CompareTo(Vehicle other)
		{
			double thisTaxCoefficient = _VehicleType.GetTaxCoefficient();
			double otherTaxCoefficient = other._VehicleType.GetTaxCoefficient();
			if (thisTaxCoefficient < otherTaxCoefficient)
			{
				return -1;
			}
			else
			{
				return thisTaxCoefficient == otherTaxCoefficient ? 0 : 1;
			}
		}

	}
}
