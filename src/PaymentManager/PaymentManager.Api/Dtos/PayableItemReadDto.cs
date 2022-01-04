using PaymentManager.Shared;
using System;

namespace PaymentManager.Api.Dtos
{
    public class PayableItemReadDto
    {
        public int Id { get; set; }
        public string InvoiceId { get; set; } = null;
        public decimal PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public string Note { get; set; } = null;
        //public Attachment? Attachment { get; set; } = null;
    }
}
