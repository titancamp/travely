using System;
using System.Collections.Generic;

namespace Travely.IdentityManager.Service.Abstractions.Models
{
    public class ResultViewModel
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string Message { get; set; }

    }
}
