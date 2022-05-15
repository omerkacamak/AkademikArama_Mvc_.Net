using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    public class LoginController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Kontrol()
        {
            return View();
        }
    }
}