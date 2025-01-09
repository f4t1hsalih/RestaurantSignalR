using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.OrderDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult InsertOrder(InsertOrderDto ınsertOrderDto)
        {
            var value = _mapper.Map<Order>(ınsertOrderDto);
            _orderService.TInsert(value);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderCount());
        }

        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            return Ok(_orderService.TActiveOrderCount());
        }

        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderService.TLastOrderPrice());
        }

        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            return Ok(_orderService.TTodayTotalPrice());
        }

        [HttpPost("CompleteOrder/{tableId}")]
        public IActionResult CompleteOrder(int tableId)
        {
            bool result = _orderService.TCompleteOrderByTableId(tableId); // Sipariş tamamlandıysa true döner
            if (result)
            {
                return Ok(new { message = "Sipariş Başarıyla Tamamlandı." });
            }

            return BadRequest(new { message = "Siparişi Tamamlarken Bir Hata Oluştu." });
        }

    }
}
