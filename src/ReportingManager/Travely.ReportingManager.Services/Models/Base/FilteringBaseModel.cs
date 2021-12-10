using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.ReportingManager.Services.Models.Base
{
    public class FilteringBaseModel
    {
        public string FieldName { get; set; }

        public string Value { get; set; }

        public FilteringOperationType Type { get; set; }
    }
}
