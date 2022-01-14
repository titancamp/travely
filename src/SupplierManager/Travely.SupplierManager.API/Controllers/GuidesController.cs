using AutoMapper;
using Travely.SupplierManager.Service;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Controllers
{
    public class GuidesController : SupplierController<Guides, Guides, Guides>
    {
        public GuidesController(ISupplierService<Guides> service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}