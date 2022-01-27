using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PaymentManager.Shared;

namespace PaymentManager.Repositories.Entities
{
    public class ReceivableEntity
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
        public TourStatus TourStatus { get; set; }
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Remaining { get; set; }
        public string Currency { get; set; }
        public decimal Rate { get; set; }
        public PaymentStatus Status { get; set; }
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