using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	internal class Rent
	{
		public DateTime RentDate { get; set; }
		public decimal RentCost { get; set; }

		public Rent() { }


		public Rent(DateTime rentDate, decimal rentCost)
		{
			RentDate = rentDate;
			RentCost = rentCost;
		}
	}
}
