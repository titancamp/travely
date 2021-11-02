namespace Travely.IdentityManager.Service.Abstractions.Models.Response
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}
