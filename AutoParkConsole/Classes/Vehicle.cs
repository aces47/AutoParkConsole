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
		readonly AbstractEngine _AbstractEngine;
		readonly VehicleType _VehicleType;
		readonly string _ModelName;
		string _GosNumber;
		int _Weight;
		readonly int _ManufactureYear;
		int _Mileage;
		Color _Color;
		double _TankCapacity;

		public Vehicle()
		{

		}

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
			_AbstractEngine = engine;
			_VehicleType = type;
			_ModelName = model;
			_GosNumber = gosNumber;
			_Weight = weight;
			_ManufactureYear = manufactureYear;
			_Mileage = mileage;
			_Color = color;
			_TankCapacity = tankCapacity;
		}

		public AbstractEngine GetEngineTypeOfVehicle() => _AbstractEngine;
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
		public void SetTankCapacity(double tankCapacity) => _TankCapacity = tankCapacity;
		public double GetTankCapacity() => _TankCapacity;

		public double GetCalcTaxPerMonth() =>
			(_Weight * 0.0013d) + (_VehicleType.GetTaxCoefficient() * _AbstractEngine.GetTaxCoefficientByEngineType() * 30) + 5;

		public override bool Equals(object obj)
		{
			if (obj is Vehicle)
			{
				var other = obj as Vehicle;
				if (_VehicleType == other._VehicleType && _ModelName.Equals(other._ModelName))
				{
					return true;
				}
			}

			return false;
		}
		public override string ToString() =>
			$"{_AbstractEngine},{_VehicleType},{_ModelName},{_GosNumber},{_Weight},{_ManufactureYear},{_Mileage},{_Color},{_TankCapacity}";

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
