using System.Collections.Generic;

namespace PaymentManager.Grpc.Models
{
    public class PayablesByTourIdEntity
    {
        public int TourId { get; set; }
        public List<PayableReadEntity> Payables { get; set; }
    }
}
