using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Shared
{
    public enum PaymentStatus
    {
        PartiallyPaid = 1,
        FullyPaid,
        Overdue,
        Canceled,
        Unpaid
    }
}
