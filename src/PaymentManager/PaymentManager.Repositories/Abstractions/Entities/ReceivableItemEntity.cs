using System;
using System.ComponentModel.DataAnnotations;
using PaymentManager.Shared;

namespace PaymentManager.Repositories.Entities
{
    public class ReceivableItemEntity
    {
        public int Id { get; set; }
        public ReceivableEntity Receivable { get; set; }
        public string InvoiceId { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public Guid? AttachmentId { get; set; }
        public bool InvoiceSent { get; set; }
    }
}