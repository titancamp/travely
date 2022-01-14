using System;

namespace PaymentManager.Grpc.Models
{
    public class AddPaymentModel
    {
		public int AgencyId { get; set; }
		public int TourId { get; set; }
		public string TourName { get; set; }
		public int TourStatus { get; set; }
		public int SupplierId { get; set; }
		public string SupplierName { get; set; }
		public double PlannedCost { get; set; }
		public double ActualCost { get; set; }
		public string Currency { get; set; }
	}
}
