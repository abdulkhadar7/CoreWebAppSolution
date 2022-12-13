using CoreWebApp.Models;
using CoreWebApp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _Category;
        public HomeController(ILogger<HomeController> logger,ICategoryService categoryService)
        {
            _logger = logger;
            _Category= categoryService;
        }

        public IActionResult Index()
        {
            var List=_Category.GetCategories();
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