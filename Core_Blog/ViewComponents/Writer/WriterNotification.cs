﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Blog.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {
        NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = _notificationManager.TGetList();
            return View(values);
        }
    }
}
