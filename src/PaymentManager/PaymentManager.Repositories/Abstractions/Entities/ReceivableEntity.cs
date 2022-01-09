using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PaymentManager.Shared;

namespace PaymentManager.Repositories.Entities
{
    public class ReceivableEntity
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public int AgencyId { get; set; }

        [Required]
        public int TourId { get; set; }

        [Required]
        public string TourName { get; set; }

        [Required]
        public TourStatus TourStatus { get; set; }

        [Required]
        public int PartnerId { get; set; }

        [Required]
        public string PartnerName { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal Remaining { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public decimal Rate { get; set; }

        public PaymentStatus Status { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime LastModified { get; set; } = DateTime.Now;

        public DateTime? DueDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        public PaymentType? PaymentType { get; set; }
        
        public bool HasAttachment { get; set; }

        public bool InvoiceSent { get; set; }

        public ICollection<ReceivableItemEntity> ReceivableItems { get; set; }

        public string Note { get; set; }
    }
}