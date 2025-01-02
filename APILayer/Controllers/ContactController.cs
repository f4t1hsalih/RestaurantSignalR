using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.ContactDto;
using DTOLayer.SliderDto;
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
            var value = _mapper.Map<GetContactDto>(_contactService.TGetById(id));
            if (value != null)
            {
                return Ok(value);
            }
            return NotFound("Kayıt Bulunamadı");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);
            return Ok("Kayıt Başarıyla Güncellendi");
        }

    }
}
