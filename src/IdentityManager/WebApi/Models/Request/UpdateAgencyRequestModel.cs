using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.WebApi.Models.Request
{
    public class UpdateAgencyRequestModel
    {
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string LogoFile { get; set; }
    }
}
