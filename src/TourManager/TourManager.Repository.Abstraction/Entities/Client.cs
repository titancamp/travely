using System.Collections.Generic;

namespace TourManager.Repository.Entities
{
    public class Client
    {
        public long Id { get; set; }
        public long ExternalId { get; set; }
        public ICollection<TourClient> TourClients { get; set; }
    }
}