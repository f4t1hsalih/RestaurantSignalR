using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DiscountDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult DiscountListByID(int id)
        {
            var value = _mapper.Map<GetDiscountDto>(_discountService.TGetById(id));
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            return Ok(value);
        }

        [HttpPost]
        public IActionResult InsertDiscount(InsertDiscountDto insertDiscountDto)
        {
            var value = _mapper.Map<Discount>(insertDiscountDto);
            _discountService.TInsert(value);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var value = _mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(value);
            return Ok("Kayıt Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            _discountService.TDelete(value);
            return Ok("Kayıt Başarıyla Silindi");
        }

    }
}
