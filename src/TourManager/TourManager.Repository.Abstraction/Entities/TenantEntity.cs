using System.Collections.Generic;

namespace TourManager.Repository.Entities
{
    public class TenantEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public ICollection<TourEntity> TourEntities { get; set; }
        public ICollection<ClientEntity> ClientEntities { get; set; }
    }
}