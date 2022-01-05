using PaymentManager.Shared;
using System;

namespace PaymentManager.Api.Dtos
{
    public class ReceivableItemReadDto
    {
        public int Id { get; set; }
        public string InvoiceId { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool InvoiceSent { get; set; }
        //public Attachment? Attachment { get; set; }
    }
}