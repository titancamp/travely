using AutoMapper;
using Travely.SupplierManager.Service;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Controllers
{
    public class ActivitiesController : SupplierController<Activities, Activities, Activities>
    {
        public ActivitiesController(ISupplierService<Activities> service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}