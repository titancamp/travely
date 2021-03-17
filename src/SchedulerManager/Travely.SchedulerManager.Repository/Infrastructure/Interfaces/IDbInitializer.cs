using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Travely.SchedulerManager.Repository.Infrastructure.Interfaces
{
    public interface IDbInitializer
    {
        /// <summary>
        /// Applies any pending migrations for the context to the database.
        /// Will create the database if it does not already exist.
        /// </summary>
        void Initialize(IServiceScope scope);

        /// <summary>
        /// Adds some default values to the Db
        /// </summary>
        Task SeedData(bool isDevelopmentEnvironment);
    }
}
