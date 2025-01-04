using Microsoft.AspNetCore.Mvc;

namespace Chapter2.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {

            return View();

        }
    }

} 

