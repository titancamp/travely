using AutoMapper;
using Travely.SupplierManager.Service;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Controllers
{
    public class TransportationController : SupplierController<Transportation, Transportation, Transportation>
    {
        public TransportationController(ISupplierService<Transportation> service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}