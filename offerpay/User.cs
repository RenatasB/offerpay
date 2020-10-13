using System;
using System.Collections.Generic;

namespace offerpay
{
	public class User
	{
		public int Id { get; set; }
		public decimal Balance { get; set; }

		public string Name { get; set; }
		public string Last { get; set; }
		public string Country { get; set; }
		public List<Offer> CompletedOffers { get; set; }

	}
}
