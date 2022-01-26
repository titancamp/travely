using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Shared
{
    public enum TourStatus
    {
        Requested = 1,
        Pending = 2,
        ProposalSent = 3,
        ProposalApproved = 4,
        Ready = 5,
        Canceled = 6
    }
}
