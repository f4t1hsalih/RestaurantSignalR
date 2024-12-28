using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TChangeStatusToFalse(int id)
        {
            _notificationDal.ChangeStatusToTrue(id);
        }

        public void TChangeStatusToTrue(int id)
        {
            _notificationDal.ChangeStatusToTrue(id);
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> TGetListAll()
        {
            return _notificationDal.GetListAll();
        }

        public List<Notification> TGetListWhere(Expression<Func<Notification, bool>> predicate)
        {
            return _notificationDal.GetListWhere(predicate);
        }

        public int TGetNotificationCountByStatusFalse()
        {
            return _notificationDal.GetNotificationCountByStatusFalse();
        }

        public List<Notification> TGetNotificationsByStatusFalse()
        {
            return _notificationDal.GetNotificationsByStatusFalse();
        }

        public void TInsert(Notification entity)
        {
            _notificationDal.Insert(entity);
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
