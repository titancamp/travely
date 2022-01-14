using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Grpc.Models
{
    public class PayableReadEntity
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
        public int TourStatus { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public decimal PlannedCost { get; set; }
        public decimal ActualCost { get; set; }
        public decimal Difference { get; set; }
        public decimal Paid { get; set; }
        public decimal Remaining { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
        public int PaymentStatus { get; set; }
        public List<PayableItem> PayableItems { get; set; }
        public string Note { get; set; }
    }

    public class PayableItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public double PaidAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentType { get; set; }
    }
}
