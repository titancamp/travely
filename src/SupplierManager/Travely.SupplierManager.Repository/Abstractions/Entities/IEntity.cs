namespace Travely.SupplierManager.Repository.Entities
{
    public interface IEntity
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public bool IsDeleted { get; set; }
    }
}