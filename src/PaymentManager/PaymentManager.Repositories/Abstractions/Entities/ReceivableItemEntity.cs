using System;
using System.ComponentModel.DataAnnotations;
using PaymentManager.Shared;

namespace PaymentManager.Repositories.Entities
{
    public class ReceivableItemEntity
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public ReceivableEntity Receivable { get; set; }

        public string InvoiceId { get; set; }

        [Required]
        public decimal PaidAmount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        //public AttachmentEntity Attachment { get; set; }

        [Required]
        public bool InvoiceSent { get; set; }
    }
}