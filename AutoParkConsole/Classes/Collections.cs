using System;
using System.Collections.Generic;
using System.IO;

namespace AutoParkConsole.Classes
{
	internal class Collections
	{
		public List<VehicleType> VehicleTypes { get; set; }
		public List<Vehicle> Vehicles { get; set; }

		public Collections(string types, string vehicles, string rents)
		{
			VehicleTypes = LoadVehicleTypes(types);
			Vehicles = LoadVehicle(vehicles);
			LoadRents(rents);
		}

		private string[] ParseCsvData(string[] rawCsvData)
		{
			string[] result = new string[rawCsvData.Length];

			for (int counter = 0; counter < rawCsvData.Length; counter++)
			{
				if (rawCsvData[counter].StartsWith("\""))
				{
					result[counter] = rawCsvData[counter].TrimStart('\"') + ',' + rawCsvData[counter + 1].TrimEnd('\"');
					counter++;
				}
				else
				{
					result[counter] = rawCsvData[counter];
				}
			}

			return result;
		}

		private List<VehicleType> LoadVehicleTypes(string inFile)
		{
			List<VehicleType> result = new List<VehicleType>();
			try
			{
				using (StreamReader reader = new StreamReader(inFile))
				{

					while (!reader.EndOfStream)
					{
						string[] rawCsvData = reader.ReadLine().Split(',');
						result.Add(CreateType(ParseCsvData(rawCsvData)));
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

		private List<Vehicle> LoadVehicle(string inFile)
		{
			List<Vehicle> result = new List<Vehicle>();

			try
			{
				using (StreamReader reader = new StreamReader(inFile))
				{
					while (!reader.EndOfStream)
					{
						string[] rawCsvData = reader.ReadLine().Split(',');
						result.Add(CreateVehicle(ParseCsvData(rawCsvData)));
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

		private Vehicle CreateVehicle(string[] csvData)
		{
			int vehicleId = Convert.ToInt32(csvData[0]);
			AbstractEngine vehicleEngine = null;
			VehicleType vehicleType = null;
			string vehicleModelName = csvData[2];
			string vehicleGosNumber = csvData[3];
			int vehicleWeight = Convert.ToInt32(csvData[4]);
			int vehicleManufactureYear = Convert.ToInt32(csvData[5]);
			int vehicleMileage = Convert.ToInt32(csvData[6]);
			Color vehicleColor = Enum.Parse<Color>(csvData[7]);
			double vehicleTankCapacity = Convert.ToDouble(csvData[^1]);

			switch (csvData[8])
			{
				case "Electrical":
					vehicleEngine = new ElectricalEngine(Convert.ToDouble(csvData[10]));
					break;
				case "Gasoline":
					vehicleEngine = new GasolineEngine(Convert.ToDouble(csvData[9]), Convert.ToDouble(csvData[10]));
					break;
				case "Diesel":
					vehicleEngine = new DieselEngine(Convert.ToDouble(csvData[9]), Convert.ToDouble(csvData[10]));
					break;
			}

			foreach (VehicleType type in VehicleTypes)
			{
				if (type.Id == Convert.ToInt32(csvData[1]))
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

		private VehicleType CreateType(string[] csvData)
		{
			return new VehicleType((Convert.ToInt32(csvData[0])), csvData[1], Convert.ToDouble(csvData[2]));
		}

		private void CreateRent(string[] csvData)
		{
			int vehicleId = Convert.ToInt32(csvData[0]);
			DateTime rentDate = Convert.ToDateTime(csvData[1]);
			decimal rentCost = Convert.ToDecimal(csvData[2]);

			foreach (Vehicle vehicle in Vehicles)
			{
				if (vehicle.Id == vehicleId)
				{
					List<Rent> rentList = vehicle.Rents ?? new List<Rent>();
					rentList.Add(new Rent(rentDate, rentCost));
					vehicle.Rents = rentList;
				}
			}
		}

		private void LoadRents(string inFile)
		{
			try
			{
				using (StreamReader reader = new StreamReader(inFile))
				{
					while (!reader.EndOfStream)
					{
						string[] rawCsvData = reader.ReadLine().Split(',');

						string[] csvData = ParseCsvData(rawCsvData);

						CreateRent(csvData);
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
			if (index < 0 || index > Vehicles.Count - 1)
			{
				Vehicles.Add(vehicle);
			}
			else
			{
				Vehicles.Insert(index, vehicle);
			}
		}

		public int Delete(int index)
		{
			if (index < 0 || index > Vehicles.Count - 1)
			{
				return -1;
			}
			else
			{
				Vehicles.RemoveAt(index);
				return index;
			}
		}

		public decimal SumTotalProfit()
		{
			decimal sumTotalProfit = 0m;
			foreach (Vehicle vehicle in Vehicles)
			{
				sumTotalProfit += vehicle.GetTotalProfit();
			}

			return sumTotalProfit;
		}

		public void Print()
		{
			Console.WriteLine($"{"ID",-5}{"Type",-10}{"Model name",-25}{"Number",-15}{"Weight(kg)",-15}" +
				$"{"Year",-10}{"Mileage",-10}{"Color",-10}{"Income",-10}{"Tax",-10}{"Profit",-10}");
			foreach (Vehicle vehicle in Vehicles)
			{
				Console.WriteLine($"{vehicle.Id,-5}" +
					$"{vehicle.VehicleType.TypeName,-10}" +
					$"{vehicle.ModelName,-25}" +
					$"{vehicle.GosNumber,-15}" +
					$"{vehicle.Weight,-15}" +
					$"{vehicle.ManufactureYear,-10}" +
					$"{vehicle.Mileage,-10}" +
					$"{vehicle.Color,-10}" +
					$"{vehicle.GetTotalVehicleIncome(),-10:0.00}" +
					$"{vehicle.GetCalcTaxPerMonth(),-10:0.00}" +
					$"{vehicle.GetTotalProfit(),-10:0.00}");
			}
			Console.WriteLine($"Total: {SumTotalProfit(),120:0.00}");
		}

		public void Sort()
		{
			Vehicles.Sort(new VehicleComparer());
		}
	}
}
