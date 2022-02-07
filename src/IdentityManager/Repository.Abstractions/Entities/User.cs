using System;
using Travely.Common.Entities;

namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
        
        public Permission Permissions { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastLogin { get; set; }
        public Status Status { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public Agency Agency { get; set; }
    }
}
