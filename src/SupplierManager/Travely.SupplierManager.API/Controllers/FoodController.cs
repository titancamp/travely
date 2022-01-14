using AutoMapper;
using Travely.SupplierManager.Service;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Controllers
{
    public class FoodController : SupplierController<Food, Food, Food>
    {
        public FoodController(ISupplierService<Food> service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}