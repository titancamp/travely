using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.WebApi.Models.Response
{
    public class AgencyResponseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int OwnerId { get; set; }
        public string? LogoFile { get; set; }
    }
}
