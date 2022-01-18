using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Shared
{
    public enum PaymentStatus
    {
        Canceled = 1,
        FullyPaid = 2,
        Overdue = 3,
        PartiallyPaid = 4,
        Unpaid = 5
    }
}
