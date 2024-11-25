using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.SocialMediaDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var socialMedia = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(socialMedia);
        }
        [HttpGet("{id}")]
        public IActionResult SocialMediaById(int id)
        {
            var socialMedia = _mapper.Map<GetSocialMediaDto>(_socialMediaService.TGetById(id));
            if (socialMedia != null)
            {
                return Ok(socialMedia);
            }
            return NotFound("Kayıt Bulunamadı");
        }

        [HttpPost]
        public IActionResult SocialMediaAdd(InsertSocialMediaDto insertSocialMediaDto)
        {
            var socialMedia = _mapper.Map<SocialMedia>(insertSocialMediaDto);
            _socialMediaService.TInsert(socialMedia);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult SocialMediaUpdate(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var socialMedia = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(socialMedia);
            return Ok("Kayıt Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult SocialMediaDelete(int id)
        {
            var value = _socialMediaService.TGetById(id);
            if (value != null)
            {
                _socialMediaService.TDelete(value);
                return Ok("Kayıt Başarıyla Silindi");
            }
            return NotFound("Kayıt Bulunamadı");
        }

    }
}
