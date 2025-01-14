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

        public ShipmentController()
        {
            shipments = new List<Shipment>
            {
                new Shipment { Id = 1, Type = "International", Description = "Shipment 1" },
                new Shipment { Id = 2, Type = "Domestic", Description = "Shipment 2" }
            };
        }

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
