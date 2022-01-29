using PaymentManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Services.Models
{
    public class PayableItem
    {
        public int? Id { get; set; }
        public string InvoiceId { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public Guid? AttachmentId { get; set; }
    }
}
