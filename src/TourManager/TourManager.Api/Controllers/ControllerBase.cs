using Microsoft.AspNetCore.Mvc;
using TourManager.Api.Utils;

namespace TourManager.Api.Controllers
{
    [ApiController]
    public class ControllerBase : Controller
    {
        public int TenantId => int.Parse(User.FindFirst(TravelyClaimTypes.Tenantid).Value);
    }
}