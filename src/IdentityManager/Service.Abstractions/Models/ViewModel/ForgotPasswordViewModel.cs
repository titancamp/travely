using System.ComponentModel.DataAnnotations;

namespace Travely.IdentityManager.Service.Abstractions.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
