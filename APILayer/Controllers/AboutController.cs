using BusinessLayer.Abstract;
using DTOLayer.AboutDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    //Bu controllerda bilinçli olarak Dto kullanmadım. Diğer bir şekilde nasıl yapıldığına dair bir örnek olması açısından.

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
            var value = _aboutService.TGetById(id);
            if (value == null)
                return NotFound("Kayıt bulunamadı");

            return Ok(value);
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
            var value = _aboutService.TGetById(id);
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            _aboutService.TDelete(value);
            return Ok("Kayıt Başarıyla Silindi");
        }

    }
}
