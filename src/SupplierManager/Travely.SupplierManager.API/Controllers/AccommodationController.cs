using AutoMapper;
using Travely.SupplierManager.API.Requests;
using Travely.SupplierManager.API.Responses;
using Travely.SupplierManager.Repository.Filters;
using Travely.SupplierManager.Service;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Controllers
{
    public class AccommodationController : SupplierController<Accommodation, AccommodationRequest, AccommodationResponse, AccommodationFilter>
    {
        public AccommodationController(ISupplierService<Accommodation, AccommodationFilter> service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}