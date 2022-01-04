using PaymentManager.Shared;

namespace PaymentManager.Services.Models
{
    public class ReceivableCreate
    {
        public int TourId { get; set; }
        public string TourName { get; set; }
        public TourStatus TourStatus { get; set; }
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public decimal Rate { get; set; }
    }
}
