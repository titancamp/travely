﻿namespace Travely.Shared.IdentityClient.Authorization.Common
{
    public record UserInfo
    {
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public int AgencyId { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
