using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.NotificationDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult NotificationList()
        {
            return Ok(_notificationService.TGetListAll());
        }

        [HttpGet("StatusFalse")]
        public ActionResult GetNotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TGetNotificationCountByStatusFalse());
        }

        [HttpGet("GetNotificationByStatusFalse")]
        public ActionResult GetNotificationByStatusFalse()
        {
            return Ok(_notificationService.TGetNotificationsByStatusFalse());
        }

        [HttpPost]
        public IActionResult InsertNotification(InsertNotificationDto insertNotificationDto)
        {
            var value = _mapper.Map<Notification>(insertNotificationDto);
            _notificationService.TInsert(value);
            return Ok("Kayıt Başarıyla Eklendi");
        }

    }
}
