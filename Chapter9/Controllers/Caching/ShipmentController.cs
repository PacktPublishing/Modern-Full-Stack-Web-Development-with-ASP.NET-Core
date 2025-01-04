using Chapter9.Interfaces;
using Chapter9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Chapter9.Controllers.Caching
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IMemoryCache _cache;

        public ShipmentController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpGet("{id}")]
        public IActionResult GetShipment(int id)
        {
            var cacheKey = $"Shipment_{id}";
            if (!_cache.TryGetValue(cacheKey, out IShipment shipment))
            {
                shipment = GetShipmentFromDatabase(id);

                // Set cache options
                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
                    SlidingExpiration = TimeSpan.FromMinutes(2)
                };

                _cache.Set(cacheKey, shipment, cacheOptions);
            }

            return Ok(shipment);
        }

        private IShipment GetShipmentFromDatabase(int id)
        {
            // Simulate a database call
            return new Shipment();
        }
    }

}
