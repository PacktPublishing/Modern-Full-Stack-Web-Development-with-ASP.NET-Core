using Microsoft.AspNetCore.Mvc;

namespace Chapter9.Controllers
{
    public class ShipmentVersioning : Controller
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        public IActionResult GetShipmentsV1()
        {
            return Ok();
        }

        [HttpGet, MapToApiVersion("2.0")]
        public IActionResult GetShipmentsV2()
        {
            return Ok();
        }
    }
}
