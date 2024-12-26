using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.BasketDto;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBasketByTableNumber(int tableNumber)
        {
            var values = _mapper.Map<List<ResultBasketDto>>(_basketService.TGetBasketByTableNumber(tableNumber));
            return Ok(values);
        }
        [HttpGet("GetBasketByTableNumberWithProductNames")]
        public IActionResult GetBasketByTableNumberWithProductNames(int tableNumber)
        {
            var values = _mapper.Map<List<ResultBasketWithProductNamesDto>>(_basketService.TGetBasketByTableNumberWithProductNames(tableNumber));
            return Ok(values);
        }
    }
}
