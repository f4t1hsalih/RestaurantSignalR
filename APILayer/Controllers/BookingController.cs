using BusinessLayer.Abstract;
using DTOLayer.BookingDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult BookingListBtID(int id)
        {
            var value = _bookingService.TGetById(id);
            if (value != null)
            {
                return Ok(value);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult InsertBooking(InsertBookingDto insertBookingDto)
        {
            Booking booking = new Booking
            {
                Name = insertBookingDto.Name,
                Phone = insertBookingDto.Phone,
                Email = insertBookingDto.Email,
                PersonCount = insertBookingDto.PersonCount,
                Date = insertBookingDto.Date
            };
            _bookingService.TInsert(booking);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking
            {
                BookingId = updateBookingDto.BookingId,
                Name = updateBookingDto.Name,
                Phone = updateBookingDto.Phone,
                Email = updateBookingDto.Email,
                PersonCount = updateBookingDto.PersonCount,
                Date = updateBookingDto.Date
            };
            return Ok("Kayıt Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            if (value == null)
            {
                return NotFound();
            }
            _bookingService.TDelete(value);
            return Ok("Kayıt Başarıyla Silindi");
        }
    }
}
