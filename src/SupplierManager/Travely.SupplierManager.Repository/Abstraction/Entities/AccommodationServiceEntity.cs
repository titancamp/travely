namespace Travely.SupplierManager.Repository.Entities
{
    public class AccommodationServiceEntity
    {
        public int Id { get; set; }
        public AccommodationEntity Accommodation {get; set; }
        public string Name { get; set; }
    }
}
