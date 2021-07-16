using System;
using System.IO;
using AutoParkConsole.Classes;

namespace AutoParkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToCSV = Directory.GetCurrentDirectory();
            Collections collections =
                new Collections(pathToCSV + "types.csv", pathToCSV + "vehicles.csv", pathToCSV + "rents.csv");
            collections.Insert(8,
                new(8,
                new ElectricalEngine(25),
                collections.VehicleTypes[1],
                "Tesla Model S",
                null,
                2025,
                2020,
                100,
                Color.Black,
                150));

            MechanicOrders orders = new MechanicOrders(pathToCSV + "orders.csv");
            orders.Print();
        }
    }
}
