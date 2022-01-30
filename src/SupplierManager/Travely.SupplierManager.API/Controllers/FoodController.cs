using AutoMapper;
using Travely.SupplierManager.Repository.Filters;
using Travely.SupplierManager.Service;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Controllers
{
    public class FoodController : SupplierController<Food, Food, Food, FoodFilter>
    {
        public FoodController(ISupplierService<Food, FoodFilter> service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}