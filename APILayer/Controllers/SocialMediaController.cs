using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.SocialMediaDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        private readonly IValidator<InsertSocialMediaDto> _insertValidator;
        private readonly IValidator<UpdateSocialMediaDto> _updateValidator;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper, IValidator<InsertSocialMediaDto> insertValidator, IValidator<UpdateSocialMediaDto> updateValidator)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
            _insertValidator = insertValidator;
            _updateValidator = updateValidator;
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
            var value = _mapper.Map<GetSocialMediaDto>(_socialMediaService.TGetById(id));
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            return Ok(value);
        }

        [HttpPost]
        public IActionResult SocialMediaAdd(InsertSocialMediaDto insertSocialMediaDto)
        {
            var validator = _insertValidator.Validate(insertSocialMediaDto);
            if (!validator.IsValid)
                return BadRequest(validator.Errors);

            var socialMedia = _mapper.Map<SocialMedia>(insertSocialMediaDto);
            _socialMediaService.TInsert(socialMedia);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult SocialMediaUpdate(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var validator = _updateValidator.Validate(updateSocialMediaDto);
            if (!validator.IsValid)
                return BadRequest(validator.Errors);

            var socialMedia = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(socialMedia);
            return Ok("Kayıt Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult SocialMediaDelete(int id)
        {
            var value = _socialMediaService.TGetById(id);
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            _socialMediaService.TDelete(value);
            return Ok("Kayıt Başarıyla Silindi");
        }

    }
}
