using EntityLayer.Entities;

namespace DataAccessLayer.Abstract
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        int GetNotificationCountByStatusFalse();
        List<Notification> GetNotificationsByStatusFalse();
        void ChangeStatusToTrue(int id);
        void ChangeStatusToFalse(int id);
    }
}
