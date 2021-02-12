using System.Collections.Generic;

namespace TourManager.Repository.Entities
{
    public class ClientEntity
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int ExternalId { get; set; }
        public TenantEntity Tenant { get; set; }
        public ICollection<TourClientEntity> TourClients { get; set; }
    }
}