using System.Collections.Generic;

namespace PaymentManager.Services.Models
{
    public class PayablesByTourId
    {
        public int TourId { get; set; }
        public List<PayableRead> Payables { get; set; }
    }
}
