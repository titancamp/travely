using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.API.Models
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string Message { get; set; }
        public string RefreshToken { get; set; }
    }
}
