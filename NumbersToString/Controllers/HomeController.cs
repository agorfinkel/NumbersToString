using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NumbersToString.Models;

using System.Diagnostics;

namespace NumbersToString.Controllers
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
            return View();
        }
        public IActionResult Convert(double numberToConvert)
        {
            var numbersToStringManager = new Resources.NumbersToString();
            ViewBag.ConvertedNumber = numbersToStringManager.Convert(numberToConvert);
            return View("Index");
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
