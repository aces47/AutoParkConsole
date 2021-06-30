using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	internal class VehicleComparer : IComparer<Vehicle>
	{
		public int Compare(Vehicle x, Vehicle y)
		{
			string xModelName = x.ModelName;
			string yModelName = y.ModelName;

			return xModelName.CompareTo(yModelName);
		}
	}
}
