using CoreWebApp.Models;
using CoreWebApp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreWebApp.Controllers
{
    //[Authorize]
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
            ViewBag.LanguageCulture = "en";
            //var List=_Category.GetCategories();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PrivacyRTL()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult CultureManagement(string culture,string returnUrl)
        {
            Response.Cookies.Append(
               CookieRequestCultureProvider.DefaultCookieName,
               CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
               new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
           return LocalRedirect(returnUrl);
        }
    }
}