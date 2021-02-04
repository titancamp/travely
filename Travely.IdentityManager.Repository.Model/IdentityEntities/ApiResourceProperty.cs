using System;
using System.Collections.Generic;
using System.Text;

namespace Travely.IdentityManager.Repository.Model.IdentityEntities
{
    public class ApiResourceProperty
    {
        public int Id { get; set; }
        public int ApiResourceId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public virtual ApiResource ApiResource { get; set; }
    }
}
