using System;
using System.Collections.Generic;

namespace PaymentManager.Services.Models
{
    public class PayableUpdate
    {
        public decimal? ActualCost { get; set; }
        public DateTime? DueDate { get; set; }
        public List<PayableItem> PayableItems { get; set; }
    }
}
