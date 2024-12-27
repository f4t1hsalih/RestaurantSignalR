using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.BookingDto;
using DTOLayer.ContactDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
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
            var value = _mapper.Map<Booking>(insertBookingDto);
            _bookingService.TInsert(value);
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
            _bookingService.TUpdate(booking);
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
