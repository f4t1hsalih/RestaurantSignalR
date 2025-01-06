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
            var notifications = _mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetListAll());
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        public IActionResult GetNotificationByID(int id)
        {
            var value = _mapper.Map<GetNotificationDto>(_notificationService.TGetById(id));
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            return Ok(value);
        }

        [HttpPost]
        public IActionResult InsertNotification(InsertNotificationDto insertNotificationDto)
        {
            insertNotificationDto.Date = Convert.ToDateTime(DateTime.Now);

            var value = _mapper.Map<Notification>(insertNotificationDto);
            _notificationService.TInsert(value);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var value = _mapper.Map<Notification>(updateNotificationDto);
            _notificationService.TUpdate(value);

            return Ok("Kayıt Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetById(id);
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            _notificationService.TDelete(value);
            return Ok("Kayıt Başarıyla Silindi");
        }

        [HttpPut("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _notificationService.TChangeStatusToTrue(id);
            return Ok("Durum True Olarak Güncellendi");
        }

        [HttpPut("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _notificationService.TChangeStatusToFalse(id);
            return Ok("Durum False Olarak Güncellendi");
        }

        [HttpGet("StatusFalseCount")]
        public ActionResult GetNotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TGetNotificationCountByStatusFalse());
        }

        [HttpGet("StatusFalse")]
        public ActionResult GetNotificationByStatusFalse()
        {
            var notifications = _mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetNotificationsByStatusFalse());
            return Ok(notifications);
        }

    }
}
