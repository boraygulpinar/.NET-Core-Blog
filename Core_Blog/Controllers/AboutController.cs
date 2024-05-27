using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Blog.Controllers
{
    public class AboutController : Controller
    {
        AboutManager _aboutManager = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var values = _aboutManager.TGetList();
            return PartialView(values);
        }
        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
