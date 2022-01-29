using AutoMapper;
using Travely.SupplierManager.Repository.Filters;
using Travely.SupplierManager.Service;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Controllers
{
    public class ActivitiesController : SupplierController<Activities, Activities, Activities, ActivitiesFilter>
    {
        public ActivitiesController(ISupplierService<Activities, ActivitiesFilter> service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}