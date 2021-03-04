using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.WebApi.Models.Response
{
    public class UserResponseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitleId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
