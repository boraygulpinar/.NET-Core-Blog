using Microsoft.AspNetCore.Mvc;

namespace Core_Blog.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
