﻿using System;
using System.Collections.Generic;

namespace TourManager.Models
{
	public class Tour
	{
		public int Id { get; set; }

		public bool? IsPackage { get; set; }

		public string TourName { get; set; }
		
		public decimal Price { get; set; }

		public string Origin { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public DateTime? PickUpTime { get; set; }

		public string PickUpDetails { get; set; }

		public DateTime? DropOffTime { get; set; }

		public string DropOffDetails { get; set; }

		public string Notes { get; set; }

		public List<string> Destinations { get; set; }

		public List<Booking> Bookings { get; set; }

		public List<Client> Clients { get; set; }
	}
}