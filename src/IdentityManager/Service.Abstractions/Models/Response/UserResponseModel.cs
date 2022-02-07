using System;
using Travely.Common.Entities;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace Travely.IdentityManager.Service.Abstractions.Models.Response
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Permission Permission { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastLogin { get; set; }
        public Status Status { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
