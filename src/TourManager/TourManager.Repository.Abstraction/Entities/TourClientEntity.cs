namespace TourManager.Repository.Entities
{
    /// <summary>
    /// The tour client entity
    /// </summary>
    public class TourClientEntity
    {
        /// <summary>
        /// The tour client id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The tour client tour's id
        /// </summary>
        public int TourId { get; set; }

        /// <summary>
        /// The tour client's tour entity
        /// </summary>
        public TourEntity Tour { get; set; }

        /// <summary>
        /// The tour client's client id
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// The tour client's client entity
        /// </summary>
        public ClientEntity Client { get; set; }
    }
}