using TourEntities.Service.Accommodation;

namespace Travely.SupplierManager.Repository.Entities
{
    public class AccommodationServiceEntity
    {
        public int Id { get; set; }
        public AccommodationService Service { get; set; }
    }
}