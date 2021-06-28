using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	class VehicleComparer : IComparer<Vehicle>
	{
		public int Compare(Vehicle x, Vehicle y)
		{
			string xModelName = x.GetModelName();
			string yModelName = y.GetModelName();

			return xModelName.CompareTo(yModelName);
		}
	}
}
