using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.SliderDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var sliders = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(sliders);
        }

        [HttpGet("{id}")]
        public IActionResult SliderDetail(int id)
        {
            var slider = _mapper.Map<GetSliderDto>(_sliderService.TGetById(id));
            if (slider == null)
                return NotFound("Kayıt Bulunamadı");

            return Ok(slider);
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            var slider = _mapper.Map<Slider>(updateSliderDto);
            _sliderService.TUpdate(slider);
            return Ok("Kayıt Başarıyla Güncellendi");
        }

    }
}
