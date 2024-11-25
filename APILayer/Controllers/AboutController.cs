using BusinessLayer.Abstract;
using DTOLayer.AboutDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var value = _aboutService.TGetListAll();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetAboutByID(int id)
        {
            var about = _aboutService.TGetById(id);
            if (about != null)
                return Ok(about);
            return NotFound("Kayıt bulunamadı");
        }


        [HttpPost]
        public IActionResult InsertAbout(InsertAboutDto insertAboutDto)
        {
            About about = new About
            {
                ImageUrl = insertAboutDto.ImageUrl,
                Title = insertAboutDto.Title,
                Description = insertAboutDto.Description
            };
            _aboutService.TInsert(about);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About
            {
                AboutId = updateAboutDto.AboutId,
                ImageUrl = updateAboutDto.ImageUrl,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description
            };
            _aboutService.TUpdate(about);
            return Ok("Kayıt Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var about = _aboutService.TGetById(id);
            if (about == null)
                return NotFound("Kayıt bulunamadı");

            _aboutService.TDelete(about);
            return NoContent(); // Veri dönmeden başarılı silme işlemi
        }

    }
}
