using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SO75948112.Models;
using System.Diagnostics;

namespace SO75948112.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var fruitList = new List<Fruit>
            {
                new Fruit { FruitId = 1, Name = "Banana" },
                new Fruit { FruitId = 2, Name = "Orange" },
                new Fruit { FruitId = 3, Name = "Apple" },
                new Fruit { FruitId = 4, Name = "Kiwi" },
            };

            var selectedFruit = new List<int> { 1, 2, 3, 4 };

            ViewBag.FruitSelectList = new MultiSelectList
            (
                items: fruitList,
                dataValueField: nameof(Fruit.FruitId),
                dataTextField: nameof(Fruit.Name),
                selectedValues: selectedFruit
            );

            return View();
        }

        [HttpPost]
        public IActionResult Index(DemoViewModel model)
        {
            return RedirectToAction("Index");
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