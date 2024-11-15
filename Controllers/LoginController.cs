using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Group_Project_Chat_app.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index() => RedirectToAction("Login", "Auth");
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
