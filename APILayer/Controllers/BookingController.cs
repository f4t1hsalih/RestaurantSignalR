using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.BookingDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        private readonly IValidator<InsertBookingDto> _insertBookingValidator;

        public BookingController(IBookingService bookingService, IMapper mapper, IValidator<InsertBookingDto> insertBookingValidator)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _insertBookingValidator = insertBookingValidator;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult BookingListBtID(int id)
        {
            var value = _mapper.Map<GetBookingDto>(_bookingService.TGetById(id));
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            return Ok(value);
        }

        [HttpPost]
        public IActionResult InsertBooking(InsertBookingDto insertBookingDto)
        {
            var validationResult = _insertBookingValidator.Validate(insertBookingDto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var value = _mapper.Map<Booking>(insertBookingDto);
            _bookingService.TInsert(value);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(value);
            return Ok("Kayıt Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            _bookingService.TDelete(value);
            return Ok("Kayıt Başarıyla Silindi");
        }

        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Onaylandı");
        }

        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.TBookingStatusCancelled(id);
            return Ok("Rezervasyon İptal Edildi");
        }

    }
}
