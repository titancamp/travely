using System.Collections.Generic;

namespace TourManager.Repository.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public ICollection<TourClient> TourClients { get; set; }
    }
}