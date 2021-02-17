using System;

namespace Travely.IdentityManager.Repository.Abstractions.Entities
{ 
    public class ApiResourceSecret
    {
        public int Id { get; set; }
        public int ApiResourceId { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; }
        public DateTime Created { get; set; }

        public ApiResource ApiResource { get; set; }
    }
}
