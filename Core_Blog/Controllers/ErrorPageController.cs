using Microsoft.AspNetCore.Mvc;

namespace Core_Blog.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1(int code)
        {
            return View();
        }
    }
}
