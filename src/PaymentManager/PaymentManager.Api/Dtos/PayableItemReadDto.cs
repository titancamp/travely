using PaymentManager.Shared;
using System;

namespace PaymentManager.Api.Dtos
{
    public class PayableItemReadDto
    {
        public int Id { get; set; }
        public string InvoiceId { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public Guid? AttachmentId { get; set; }
    }
}
