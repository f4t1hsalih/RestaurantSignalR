using AutoMapper;
using DTOLayer.NotificationDto;
using EntityLayer.Entities;

namespace APILayer.Mapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {
            CreateMap<Notification, InsertNotificationDto>().ReverseMap();
        }
    }
}
