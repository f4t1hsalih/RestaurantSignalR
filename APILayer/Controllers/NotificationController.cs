using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.CategoryDto;
using DTOLayer.NotificationDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly IValidator<InsertNotificationDto> _insertValidator;
        private readonly IValidator<UpdateNotificationDto> _updateValidator;

        public NotificationController(INotificationService notificationService, IMapper mapper, IValidator<InsertNotificationDto> insertValidator, IValidator<UpdateNotificationDto> updateValidator)
        {
            _notificationService = notificationService;
            _mapper = mapper;
            _insertValidator = insertValidator;
            _updateValidator = updateValidator;
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

            var result = _insertValidator.Validate(insertNotificationDto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var value = _mapper.Map<Notification>(insertNotificationDto);
            _notificationService.TInsert(value);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var result = _updateValidator.Validate(updateNotificationDto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

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
