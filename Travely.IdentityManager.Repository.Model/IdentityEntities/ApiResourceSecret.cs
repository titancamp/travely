using System;
using System.Collections.Generic;
using System.Text;

namespace Travely.IdentityManager.Repository.Model.IdentityEntities
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

        public virtual ApiResource ApiResource { get; set; }
    }
}
