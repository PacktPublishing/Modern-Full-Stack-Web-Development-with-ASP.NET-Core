using Microsoft.AspNetCore.Mvc;
using Chapter12.Models;

namespace Chapter12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogisticsController : ControllerBase
    {
        private static List<LogisticsItem> logisticsItems = new List<LogisticsItem>
        {
            new LogisticsItem { Id = 1, ItemName = "Pallet of cotton seeds", Quantity = 50, Location = "Warehouse A" },
            new LogisticsItem { Id = 2, ItemName = "Box of electronics", Quantity = 200, Location = "Warehouse B" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<LogisticsItem>> GetItems()
        {
            return Ok(logisticsItems);
        }

        [HttpGet("{id}")]
        public ActionResult<LogisticsItem> GetItem(int id)
        {
            var item = logisticsItems.Find(i => i.Id == id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public ActionResult<LogisticsItem> CreateItem(LogisticsItem item)
        {
            item.Id = logisticsItems.Count + 1;
            logisticsItems.Add(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, LogisticsItem updatedItem)
        {
            var item = logisticsItems.Find(i => i.Id == id);
            if (item == null)
                return NotFound();
            item.ItemName = updatedItem.ItemName;
            item.Quantity = updatedItem.Quantity;
            item.Location = updatedItem.Location;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = logisticsItems.Find(i => i.Id == id);
            if (item == null)
                return NotFound();
            logisticsItems.Remove(item);
            return NoContent();
        }
    }
}
