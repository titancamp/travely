using PaymentManager.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentManager.Api.Dtos
{
    public class PayableItemUpdateDto
    {
        public int? Id { get; set; } = null;
        public string InvoiceId { get; set; } = null;
        [Required]
        public decimal PaidAmount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        public string Note { get; set; } = null;
        //public Attachment? Attachment { get; set; } = null;
    }
}
