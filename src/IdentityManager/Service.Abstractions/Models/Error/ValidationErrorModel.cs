using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travely.IdentityManager.Service.Abstractions.Models.Error
{
    public class ValidationErrorModel : ErrorModel
    {
        public string Name { get; set; }
    }
}
