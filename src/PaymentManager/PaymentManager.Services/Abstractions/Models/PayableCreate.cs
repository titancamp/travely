using PaymentManager.Shared;

namespace PaymentManager.Services.Models
{
    public class PayableCreate
    {
        public int TourId { get; set; }
        public string TourName { get; set; }
        public TourStatus TourStatus { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public decimal PlannedCost { get; set; }
        public string Currency { get; set; }
    }
}
