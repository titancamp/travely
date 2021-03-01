namespace Travely.IdentityClient.Authorization.Data
{
    public class UserInfo
    {
        public int? UserId { get; set; }
        public int? EmployeeId { get; set; }
        public int? AgancyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        Unknown = 0,
        Admin
    }
}
