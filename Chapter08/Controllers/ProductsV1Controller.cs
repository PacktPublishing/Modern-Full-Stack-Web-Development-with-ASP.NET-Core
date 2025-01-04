using Microsoft.AspNetCore.Mvc;

namespace Chapter8.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsV1Controller : ControllerBase
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
    }
}
