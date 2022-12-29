using Microsoft.AspNetCore.Mvc;

namespace CoreWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
