using PaymentManager.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentManager.Api.Dtos
{
    public class ReceivableItemUpdateDto
    {
        public int? Id { get; set; }
        public string InvoiceId { get; set; }
        [Required]
        public decimal PaidAmount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        public bool InvoiceSent { get; set; }
        public Guid? AttachmentId { get; set; }
    }
}
