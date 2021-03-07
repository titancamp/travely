using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.WebApi.Models.Error
{
    public class ValidationErrorModel : ErrorModel
    {
        public string Name { get; set; }
    }
}
