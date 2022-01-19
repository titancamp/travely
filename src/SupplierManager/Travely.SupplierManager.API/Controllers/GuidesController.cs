using AutoMapper;
using Travely.SupplierManager.Repository.Filters;
using Travely.SupplierManager.Service;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Controllers
{
    public class GuidesController : SupplierController<Guides, Guides, Guides, GuidesFilter>
    {
        public GuidesController(ISupplierService<Guides, GuidesFilter> service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}