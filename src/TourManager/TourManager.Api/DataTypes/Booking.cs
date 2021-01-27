﻿using System;
using System.Collections.Generic;
using TourManager.CommonTypes;

namespace TourManager.Api.DataTypes
{
	public class Booking
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public BookingType Type { get; set; }

		public BookingStatus Status { get; set; }

		public DateTime? CheckInDate { get; set; }

		public DateTime? CheckOutDate { get; set; }

		public DateTime? CancellationDeadline { get; set; }

		public string Origin { get; set; }

		public DateTime? ArrivalTime { get; set; }

		public string ArrivalFlightNumber { get; set; }

		public DateTime? DepartureTime { get; set; }

		public string DepartureFlightNumber { get; set; }

		public string Notes { get; set; }

		public ICollection<string> Destinations { get; set; }
	}
}