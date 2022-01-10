using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Services.Models
{
    public class PayableSupplierUpdate
    {
        public int? SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}
