using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Blog.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic4:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Admins.Where(x=>x.AdminID==1).Select(y=>y.Name).FirstOrDefault();
            ViewBag.v2 = c.Admins.Where(x=>x.AdminID==1).Select(y=>y.ImageURL).FirstOrDefault();
            ViewBag.v3 = c.Admins.Where(x=>x.AdminID==1).Select(y=>y.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
