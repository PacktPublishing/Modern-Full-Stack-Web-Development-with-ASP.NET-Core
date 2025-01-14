using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Chapter8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.0 },
            new Product { Id = 2, Name = "Product 2", Price = 20.0 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = Products.Find(x=> x.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            product.Id = Products.Count + 1;
            Products.Add(product);

            return CreatedAtAction(nameof(Products), product);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product updatedProduct)
        {
            var product = Products.Find(x=> x.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = Products.Find(x=> x.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            Products.Remove(product);

            return NoContent();
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Product>> Get([FromQuery] string name, [FromQuery] double? minPrice)
        {
            var products = Products.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            if (minPrice.HasValue)
            {
                products = products.Where(x => x.Price >= minPrice.Value);
            }

            return products.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id, [FromHeader(Name = "X-Custom-Header")] string customHeader)
        {
            var product = Products.Find(x=> x.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            Response.Headers.Add("X-Response-Header", "Response value");

            return Ok(new
            {
                Product = product,
                CustomHeaderReceived = customHeader
            });
        }
    }

    
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}


