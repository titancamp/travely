using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace IdentityManager.WebApi.Models
{
    public class UserContextModel
    {
        public int UserId { get; set; }

        public Role Role { get; set; }

        public int AgencyId { get; set; }
    }
}
