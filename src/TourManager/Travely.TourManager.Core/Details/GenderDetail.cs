using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.TourManager.Core.Details
{
    public class GenderRequest
    {
        public string GenderName { get; set; }
    }

    public class GenderResponse
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }
    }
}
