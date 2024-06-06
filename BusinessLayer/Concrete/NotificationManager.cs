using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TDelete(Notification entity)
        {
            throw new NotImplementedException();
        }

        public Notification TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Notification> TGetList()
        {
            return _notificationDal.GetListAll();
        }

        public void TInsert(Notification entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Notification entity)
        {
            throw new NotImplementedException();
        }
    }
}
