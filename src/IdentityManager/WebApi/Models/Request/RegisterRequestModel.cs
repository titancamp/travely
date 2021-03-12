using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.API.Models
{
    public class RegisterRequestModel
    {
        public string AgencyName { get; set; }



        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
               
        //[Required]
        //[StringLength(50, MinimumLength = 5)]
        //public string Address { get; set; }

        //[Required]
        //[StringLength(50, MinimumLength = 5)]
        //public string PhoneNumber { get; set; }

        //[Required]
        //public string LogoFile { get; set; }

        //public bool IsAdmin { get; set; }


    }
}
