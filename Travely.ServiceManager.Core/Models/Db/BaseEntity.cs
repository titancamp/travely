namespace Travely.ServiceManager.Core.Models.Db
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
