using System;
using System.Collections.Generic;

namespace PaymentManager.Services.Models
{
    public class ReceivableUpdate
    {
        public DateTime? DueDate { get; set; }
        public List<ReceivableItem> ReceivableItems { get; set; }
        public string Note { get; set; }
    }
}