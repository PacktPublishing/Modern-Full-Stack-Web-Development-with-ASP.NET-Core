using Chapter9.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chapter9.Controllers.Async
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipment(string id)
        {
            var shipment = await _shipmentService.GetShipment(id);

            if (shipment == null)
            {
                return NotFound();
            }
            return Ok(shipment);
        }
    }

}
