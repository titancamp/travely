using System.Threading.Tasks;
using Travely.PropertyManager.Domain.Entities;

namespace Travely.PropertyManager.Data.Contracts.Repositories
{
    public interface IPropertyRepository
    {
        Task<Property> GetByIdAsync(int id);
    }
}
