using Microsoft.AspNetCore.Mvc;

namespace Core_Blog.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
