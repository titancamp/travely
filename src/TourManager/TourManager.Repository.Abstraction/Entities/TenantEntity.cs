using System.Collections.Generic;

namespace TourManager.Repository.Entities
{
    /// <summary>
    /// The tenant entity
    /// </summary>
    public class TenantEntity
    {
        /// <summary>
        /// The tenant entity id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The tenant name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The tenant key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The tenant tours collection
        /// </summary>
        public ICollection<TourEntity> TourEntities { get; set; }

        /// <summary>
        /// The tenant clients collection
        /// </summary>
        public ICollection<ClientEntity> ClientEntities { get; set; }
    }
}