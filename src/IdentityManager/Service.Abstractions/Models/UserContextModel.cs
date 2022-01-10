using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace Travely.IdentityManager.Service.Abstractions.Models
{
    public class UserContextModel
    {
        public int UserId { get; set; }

        public Role Role { get; set; }

        public int Permissions { get; set; }

        public int AgencyId { get; set; }
    }
}
