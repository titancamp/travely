using AutoMapper;
using Travely.SupplierManager.API.Requests;
using Travely.SupplierManager.API.Responses;
using Travely.SupplierManager.Service;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Controllers
{
    public class AccommodationController : SupplierController<Accommodation, AccommodationRequest, AccommodationResponse>
    {
        public AccommodationController(ISupplierService<Accommodation> service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}