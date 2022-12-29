using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApp.Controllers
{
    public class CultureController : Controller
    {
        [HttpPost]
        public IActionResult SetCulture(string culture,string returnURL) 
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            return LocalRedirect(returnURL);

        }
    }
}
