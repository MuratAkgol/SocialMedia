using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Hakkimda()
        {
            return View();
        }

        public IActionResult Iletisim()
        {
            return View();
        }

        public IActionResult KayitOl()
        {
            return View();
        }
    }
}
