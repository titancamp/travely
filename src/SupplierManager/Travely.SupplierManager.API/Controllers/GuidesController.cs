using AutoMapper;
using Travely.SupplierManager.Repository.Filters;
using Travely.SupplierManager.Service;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Controllers
{
    public class GuidesController : SupplierController<GuidesModel, GuidesModel, GuidesModel, GuidesFilter>
    {
        public GuidesController(ISupplierService<GuidesModel, GuidesFilter> service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}