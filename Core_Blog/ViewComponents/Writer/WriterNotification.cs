using Microsoft.AspNetCore.Mvc;

namespace Core_Blog.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
