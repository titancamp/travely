namespace Travely.ServiceManager.Abstraction.Models.Db
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
