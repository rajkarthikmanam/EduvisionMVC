using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EduvisionMvc.Models;

namespace EduvisionMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Home page
    public IActionResult Index()
    {
        ViewData["Title"] = "Home";
        return View();
    }

    // Visualization
    public IActionResult Visualize() => View();

    // About
    public IActionResult About() => View();

    // Optional: Privacy
    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
        => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
