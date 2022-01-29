using AutoMapper;
using Travely.SupplierManager.Repository.Filters;
using Travely.SupplierManager.Service;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Controllers
{
    public class TransportationController : SupplierController<Transportation, Transportation, Transportation, TransportationFilter>
    {
        public TransportationController(ISupplierService<Transportation, TransportationFilter> service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}