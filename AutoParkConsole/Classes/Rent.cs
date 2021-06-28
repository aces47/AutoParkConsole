using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkConsole.Classes
{
	public class Rent
	{
		DateTime _RentDate;
		decimal _RentCost;

		public void SetRentDate(DateTime rentDate) => _RentDate = rentDate;
		public DateTime GetRentDate() => _RentDate;
		public void SetRentCost(decimal rentCost) => _RentCost = rentCost;
		public decimal GetRentCost() => _RentCost;

		public Rent()
		{

		}

		public Rent(DateTime rentDate,decimal rentCost)
		{
			_RentDate = rentDate;
			_RentCost = rentCost;
		}
	}
}
