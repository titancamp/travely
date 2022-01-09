using PaymentManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Services.Models
{
    public class ReceivableRead
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public decimal TotalAmount{ get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Remaining { get; set; }
        public string Currency { get; set; }
        public decimal Rate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public TourStatus TourStatus { get; set; }
        public PaymentStatus Status { get; set; }
        public PaymentType PaymentType { get; set; }
        public List<ReceivableItem> ReceivableItems { get; set; }
        public bool HasAttachment { get; set; }
        public bool InvoiceSent { get; set; }
        public string Note { get; set; }
    }
}
