using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Travely.ServiceManager.DAL.Data
{
    public class ServiceManagerDbContextFactory : IDesignTimeDbContextFactory<ServiceManagerDbContext>
    {
        public ServiceManagerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ServiceManagerDbContext>().UseSqlServer("Server=(local);Database=ServiceManagerDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new ServiceManagerDbContext(optionsBuilder.Options);
        }
    }
}
