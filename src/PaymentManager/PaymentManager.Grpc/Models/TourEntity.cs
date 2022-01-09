using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Grpc.Models
{
    public class TourEntity
    {
        public int AgencyId { get; set; }
        public List<int> TourIds { get; set; }
    }
}
