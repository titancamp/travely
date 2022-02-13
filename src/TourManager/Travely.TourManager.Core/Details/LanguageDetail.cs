using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.TourManager.Core.Details
{
    public class LanguageRequest
    {
        public string LanguageName { get; set; }
    }

    public class LanguageResponse
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
    }
}
