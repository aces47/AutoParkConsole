using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	class MechanicOrders
	{
		Dictionary<string, int> _Orders;

		public MechanicOrders(string inFile)
		{
			_Orders = new Dictionary<string, int>();
			using (StreamReader reader = new StreamReader(inFile))
			{
				while(!reader.EndOfStream)
				{
					string[] rows = reader.ReadLine().Split(',');

					foreach (string row in rows)
					{
						if(!_Orders.TryAdd(row, 1))
						{
							_Orders[row]++;
						}
					}
				}
			}
		}

		public void Print()
		{
			foreach (var item in _Orders)
			{
				Console.WriteLine($"{item.Key} - {item.Value} шт.");
			}
		}
	}
}
