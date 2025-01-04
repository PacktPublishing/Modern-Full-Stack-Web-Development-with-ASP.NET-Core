using Microsoft.AspNetCore.Mvc;

namespace Chapter9.Controllers
{
    [Route("{tenant}.domainexample.com/api/[controller]")]
    [ApiController]
    public class TenantShipmentController : Controller
    {
        [HttpGet("")]
        public IActionResult GetShipments(string tenant)
        {

            return Ok();
        }
    }
}
