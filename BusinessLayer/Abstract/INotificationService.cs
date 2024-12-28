using EntityLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        int TGetNotificationCountByStatusFalse();
        List<Notification> TGetNotificationsByStatusFalse();
        void TChangeStatusToTrue(int id);
        void TChangeStatusToFalse(int id);
    }
}
