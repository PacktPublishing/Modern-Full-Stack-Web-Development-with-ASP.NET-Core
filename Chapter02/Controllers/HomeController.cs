using Chapter2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Chapter2.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
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

    public IActionResult Confirmation() => View();

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
