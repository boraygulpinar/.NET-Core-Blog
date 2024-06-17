using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace Core_Blog.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.TGetList().Count;
            ViewBag.v2 = c.Comments.Count();
            ViewBag.v3 = c.Writers.Count();

            string api = "3dc5b447b8e6fd4f454620550a593982";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&units=metric&mode=xml&appid=" + api;

            XDocument document = XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
    }
}
