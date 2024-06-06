using Microsoft.AspNetCore.Mvc;

namespace Core_Blog.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
