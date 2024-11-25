using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.ContactDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var contacts = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(contacts);
        }
        [HttpGet("{id}")]
        public IActionResult ContactListByID(int id)
        {
            var value = _contactService.TGetById(id);
            if (value != null)
            {
                var result = _mapper.Map<GetContactDto>(value);
                return Ok(result);
            }
            return NotFound("Kayıt Bulunamadı");
        }
        [HttpPost]
        public IActionResult InsertContact(InsertContactDto insertContactDto)
        {
            var value = _mapper.Map<Contact>(insertContactDto);
            _contactService.TInsert(value);
            return Ok("Kayıt Başarıyla Eklendi");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);
            return Ok("Kayıt Başarıyla Güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            if (value != null)
            {
                _contactService.TDelete(value);
                return Ok("Kayıt Başarıyla Silindi");
            }
            return NotFound("Kayıt Bulunamadı");
        }
    }
}
