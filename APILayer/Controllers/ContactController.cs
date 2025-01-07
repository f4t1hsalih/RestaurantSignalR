using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.ContactDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateContactDto> _updateValidator;

        public ContactController(IContactService contactService, IMapper mapper, IValidator<UpdateContactDto> updateValidator)
        {
            _contactService = contactService;
            _mapper = mapper;
            _updateValidator = updateValidator;
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
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var result = _updateValidator.Validate(updateContactDto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var value = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);
            return Ok("Kayıt Başarıyla Güncellendi");
        }

    }
}
