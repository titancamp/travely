﻿using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace Travely.IdentityManager.Service.Abstractions.Models
{
    public class UserContextModel
    {
        public int UserId { get; set; }

        public Role Role { get; set; }

        public int AgencyId { get; set; }
    }
}
