using System.Text.Json.Serialization;

namespace Travely.IdentityManager.Service.Abstractions.Models.Request
{
    public class UserRequestModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}
 