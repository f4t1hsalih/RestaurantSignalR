using EntityLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        int TGetNotificationCountByStatusFalse();
    }
}
