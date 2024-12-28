using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(Context context) : base(context)
        {
        }

        public void ChangeStatusToFalse(int id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification != null)
                notification.Status = false;
            _context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id)
        {
            var notification = _context.Notifications.Find(id);
            if (notification != null)
                notification.Status = true;
            _context.SaveChanges();
        }

        public int GetNotificationCountByStatusFalse()
        {
            return _context.Notifications.Where(x => x.Status == false).Count();
        }

        public List<Notification> GetNotificationsByStatusFalse()
        {
            return _context.Notifications.Where(x => x.Status == false).ToList();
        }
    }
}
