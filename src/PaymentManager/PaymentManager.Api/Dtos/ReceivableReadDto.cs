using PaymentManager.Shared;
using System;
using System.Collections.Generic;

namespace PaymentManager.Api.Dtos
{
    public class ReceivableReadDto
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Remaining { get; set; }
        public string Currency { get; set; }
        public decimal Rate { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? DueDate { get; set; }
        // public Attachment Attachment { get; set; }
        public List<ReceivableItemReadDto> ReceivableItems { get; set; }
        public string Note { get; set; }
    }
}
