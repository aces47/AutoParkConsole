using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
    internal class MechanicOrders
    {
        private Dictionary<string, int> Orders { get; }

        public MechanicOrders(string inFile)
        {
            Orders = new Dictionary<string, int>();
            using (StreamReader reader = new StreamReader(inFile))
            {
                while (!reader.EndOfStream)
                {
                    string[] fieldsOfParts = reader.ReadLine().Split(',');

                    foreach (string row in fieldsOfParts)
                    {
                        if (!Orders.TryAdd(row, 1))
                        {
                            Orders[row]++;
                        }
                    }
                }
            }
        }

        public void Print()
        {
            foreach (var item in Orders)
            {
                Console.WriteLine($"{item.Key} - {item.Value} шт.");
            }
        }
    }
}
