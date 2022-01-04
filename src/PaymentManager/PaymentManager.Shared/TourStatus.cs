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
        Pending,
        ProposalSent,
        ProposalApproved,
        Ready,
        Canceled,
        Deleted
    }
}
