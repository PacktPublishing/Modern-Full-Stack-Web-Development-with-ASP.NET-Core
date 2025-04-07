using Microsoft.AspNetCore.Mvc;

namespace Chapter2.Controllers;

[Route("products")]
public class ProductsController : Controller
{
    [Route("")] // Combines to define the route 'products' 

    public IActionResult Index() => View();

    [Route("{id}")] // Combines to define the route 'products/id' 
    public IActionResult Details(int id) => View();
}
