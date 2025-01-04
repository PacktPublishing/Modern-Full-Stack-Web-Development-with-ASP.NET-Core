using Chapter2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Chapter2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to your first ViewBag";
            ViewBag.CurrentDate = DateTime.UtcNow;
            return View();
        }

        public IActionResult ShipmentDetails()
        {
            ViewData["Title"] = "Shipment Details";
            ViewData["Value"] = 100000.00;
            return View();
        }

        public IActionResult SubmitForm()
        {
            TempData["SuccessMessage"] = "The information was successfully saved!";
            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
