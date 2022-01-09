namespace PaymentManager.Grpc.Models
{
    public class UpdateSupplierModel
    {
        public int AgencyId { get; set; }
        public int PayableId { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}
