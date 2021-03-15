using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace IdentityManager.WebApi.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Column(TypeName = "datetime")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [NotMapped]
        public string Role { get; set; }

    }
}
