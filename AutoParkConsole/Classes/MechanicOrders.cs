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
		private Dictionary<string, int> _orders;

		public MechanicOrders(string inFile)
		{
			_orders = new Dictionary<string, int>();
			using (StreamReader reader = new StreamReader(inFile))
			{
				while (!reader.EndOfStream)
				{
					string[] fieldsOfParts = reader.ReadLine().Split(',');

					foreach (string row in fieldsOfParts)
					{
						if (!_orders.TryAdd(row, 1))
						{
							_orders[row]++;
						}
					}
				}
			}
		}

		public void Print()
		{
			foreach (var item in _orders)
			{
				Console.WriteLine($"{item.Key} - {item.Value} шт.");
			}
		}
	}
}
