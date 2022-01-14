using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Grpc.Models
{
    public class PayablesByAgencyEntity
    {
        public int AgencyId { get; set; }

        /// <summary>
        /// Page size.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Page number
        /// </summary>
        public int Page { get; set; }
    }
}
