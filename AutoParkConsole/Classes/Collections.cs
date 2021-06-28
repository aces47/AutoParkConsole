using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace AutoParkConsole.Classes
{
	class Collections
	{
		List<VehicleType> _VehicleTypes;
		List<Vehicle> _Vehicles;

		public List<VehicleType> GetVehicleTypes() => _VehicleTypes;
		public List<Vehicle> GetVehicles() => _Vehicles;

		public Collections(string types, string vehicles, string rents)
		{
			_VehicleTypes = LoadVehicleTypes(types);
			_Vehicles = LoadVehicle(vehicles);
			LoadRents(rents);
		}

		List<VehicleType> LoadVehicleTypes(string inFile)
		{
			List<VehicleType> result = new List<VehicleType>();
			try
			{
				using (TextFieldParser reader = new TextFieldParser(inFile))
				{
					reader.SetDelimiters(",");
					reader.HasFieldsEnclosedInQuotes = true;
					while (!reader.EndOfData)
					{
						result.Add(CreateType(reader.ReadFields()));
					}
				}
			}
			catch (FileNotFoundException)
			{

				throw new FileNotFoundException(nameof(inFile));
			}
			catch (FileLoadException)
			{
				throw new FileLoadException(nameof(inFile));
			}


			return result;
		}
		List<Vehicle> LoadVehicle(string inFile)
		{
			List<Vehicle> result = new List<Vehicle>();

			try
			{
				using (TextFieldParser reader = new TextFieldParser(inFile))
				{
					reader.SetDelimiters(",");
					reader.HasFieldsEnclosedInQuotes = true;
					while (!reader.EndOfData)
					{
						result.Add(CreateVehicle(reader.ReadFields()));
					}
				}
			}
			catch (FileNotFoundException)
			{

				throw new FileNotFoundException(nameof(inFile));
			}
			catch (FileLoadException)
			{
				throw new FileLoadException(nameof(inFile));
			}

			return result;
		}
		Vehicle CreateVehicle(string[] rows)
		{
			int vehicleId = Convert.ToInt32(rows[0]);
			AbstractEngine vehicleEngine = null;
			VehicleType vehicleType = null;
			string vehicleModelName = rows[2];
			string vehicleGosNumber = rows[3];
			int vehicleWeight = Convert.ToInt32(rows[4]);
			int vehicleManufactureYear = Convert.ToInt32(rows[5]);
			int vehicleMileage = Convert.ToInt32(rows[6]);
			Color vehicleColor = Color.Black;
			double vehicleTankCapacity = Convert.ToDouble(rows[^1]);

			switch (rows[7])
			{
				case "Black":
					vehicleColor = Color.Black;
					break;
				case "White":
					vehicleColor = Color.White;
					break;
				case "Red":
					vehicleColor = Color.Red;
					break;
				case "Gray":
					vehicleColor = Color.Gray;
					break;
				case "Green":
					vehicleColor = Color.Green;
					break;
				case "Yellow":
					vehicleColor = Color.Yellow;
					break;
				case "Blue":
					vehicleColor = Color.Blue;
					break;
			}

			switch (rows[8])
			{
				case "Electrical":
					vehicleEngine = new ElectricalEngine(Convert.ToDouble(rows[10]));
					break;
				case "Gasoline":
					vehicleEngine = new GasolineEngine(Convert.ToDouble(rows[9]), Convert.ToDouble(rows[10]));
					break;
				case "Diesel":
					vehicleEngine = new DieselEngine(Convert.ToDouble(rows[9]), Convert.ToDouble(rows[10]));
					break;
			}

			foreach (VehicleType type in _VehicleTypes)
			{
				if (type.GetTypeId() == Convert.ToInt32(rows[1]))
				{
					vehicleType = type;
					break;
				}
			}

			return new Vehicle(
				vehicleId,
				vehicleEngine,
				vehicleType,
				vehicleModelName,
				vehicleGosNumber,
				vehicleWeight,
				vehicleManufactureYear,
				vehicleMileage,
				vehicleColor,
				vehicleTankCapacity);
		}
		VehicleType CreateType(string[] csvData)
		{
			return new VehicleType((Convert.ToInt32(csvData[0])), csvData[1], Convert.ToDouble(csvData[2]));
		}
		void LoadRents(string inFile)
		{
			try
			{
				using (TextFieldParser reader = new TextFieldParser(inFile))
				{
					reader.SetDelimiters(",");
					reader.HasFieldsEnclosedInQuotes = true;
					while (!reader.EndOfData)
					{
						string[] rows = reader.ReadFields();

						int vehicleId = Convert.ToInt32(rows[0]);
						DateTime rentDate = Convert.ToDateTime(rows[1]);
						decimal rentCost = Convert.ToDecimal(rows[2]);

						foreach (Vehicle vehicle in _Vehicles)
						{
							if (vehicle.GetId() == vehicleId)
							{
								List<Rent> rentList = vehicle.GetVehicleRentsList() ?? new List<Rent>();
								rentList.Add(new Rent(rentDate, rentCost));
								vehicle.SetVehicleRentsList(rentList);
							}
						}
					}
				}
			}
			catch (FileNotFoundException)
			{

				throw new FileNotFoundException(nameof(inFile));
			}
			catch (FileLoadException)
			{
				throw new FileLoadException(nameof(inFile));
			}
		}
		public void Insert(int index, Vehicle vehicle)
		{
			if (index < 0 || index > _Vehicles.Count - 1)
			{
				_Vehicles.Add(vehicle);
			}
			else
			{
				_Vehicles.Insert(index, vehicle);
			}
		}
		public int Delete(int index)
		{
			if (index < 0 || index > _Vehicles.Count - 1)
			{
				return -1;
			}
			else
			{
				_Vehicles.RemoveAt(index);
				return index;
			}
		}
		public decimal SumTotalProfit()
		{
			decimal sumTotalProfit = 0m;
			foreach (Vehicle vehicle in _Vehicles)
			{
				sumTotalProfit += vehicle.GetTotalProfit();
			}

			return sumTotalProfit;
		}
		public void Print()
		{
			Console.WriteLine($"{"ID",-5}{"Type",-10}{"Model name",-25}{"Number",-15}{"Weight(kg)",-15}" +
				$"{"Year",-10}{"Mileage",-10}{"Color",-10}{"Income",-10}{"Tax",-10}{"Profit",-10}");
			foreach (Vehicle vehicle in _Vehicles)
			{
				Console.WriteLine($"{vehicle.GetId(),-5}" +
					$"{vehicle.GetVehicleType().GetTypeName(),-10}" +
					$"{vehicle.GetModelName(),-25}" +
					$"{vehicle.GetGosNumber(),-15}" +
					$"{vehicle.GetWeight(),-15}" +
					$"{vehicle.GetManufactureYear(),-10}" +
					$"{vehicle.GetMileage(),-10}" +
					$"{vehicle.GetColor(),-10}" +
					$"{vehicle.GetTotalVehicleIncome(),-10:0.00}" +
					$"{vehicle.GetCalcTaxPerMonth(),-10:0.00}" +
					$"{vehicle.GetTotalProfit(),-10:0.00}");
			}
			Console.WriteLine($"Total: {SumTotalProfit(),120:0.00}");
		}
		public void Sort()
		{
			_Vehicles.Sort(new VehicleComparer());
		}
	}
}
