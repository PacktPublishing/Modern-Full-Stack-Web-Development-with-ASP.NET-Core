using Chapter9.Interfaces;
using Chapter9.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chapter9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : Controller
    {
        private readonly List<Shipment> shipments;
        [HttpGet("{id:int}")]
       public IActionResult GetShipmentById(int id)
        {
            var shipment = shipments.Where(x => x.Id == id);
            return Ok(shipment);
        }

        [HttpGet("type/{type}")]
        public IActionResult GetShipmentByType(string type)
        {
            return Ok();
        }

        [HttpGet("{shipmentId:regex(^SHIPMENT-[[0-7]]{{5}}$)}")]
        public IActionResult GetShipmentByCustomNumber(string shipmentId)
        {
            return Ok();
        }
    }
}
