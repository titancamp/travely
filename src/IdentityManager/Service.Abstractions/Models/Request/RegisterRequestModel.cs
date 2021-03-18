using System.ComponentModel.DataAnnotations;

namespace Travely.IdentityManager.Service.Abstractions.Models.Request
{
    public class RegisterRequestModel
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string AgencyName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
