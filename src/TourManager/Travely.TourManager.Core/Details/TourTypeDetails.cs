using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.TourManager.Core.Details
{
    public class TourTypeRequest
    {
        public string TourTypeName { get; set; }
    }

    public class TourTypeResponse 
    {
        public int TourTypeId { get; set; }
        public string TourTypeName { get; set; }
    }
}
