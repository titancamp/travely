using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.TourManager.Core.Details
{

    public class TourStatusRequest
    {
        public string TourStatusName { get; set; }
    }

    public class TourStatusResponse
    {
        public int TourStatusId { get; set; }
        public string TourStatusName { get; set; }
    }

}
