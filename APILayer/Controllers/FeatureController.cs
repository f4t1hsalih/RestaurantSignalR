using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.FeatureDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var features = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(features);
        }

        [HttpGet("{id}")]
        public IActionResult FeatureDetail(int id)
        {
            var feature = _mapper.Map<GetFeatureDto>(_featureService.TGetById(id));
            if (feature != null)
            {
                return Ok(feature);
            }
            return NotFound("Kayıt Bulunamadı");
        }

        [HttpPost]
        public IActionResult InsertFeature(InsertFeatureDto insertFeatureDto)
        {
            var feature = _mapper.Map<Feature>(insertFeatureDto);
            _featureService.TInsert(feature);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var feature = _mapper.Map<Feature>(updateFeatureDto);
            _featureService.TUpdate(feature);
            return Ok("Kayıt Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var feature = _featureService.TGetById(id);
            if (feature != null)
            {
                _featureService.TDelete(feature);
                return Ok("Kayıt Başarıyla Silindi");
            }
            return NotFound("Kayıt Bulunamadı");
        }
    }
}
