﻿using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.TestimonialDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        private readonly IValidator<InsertTestimonialDto> _insertValidator;
        private readonly IValidator<UpdateTestimonialDto> _updateValidator;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper, IValidator<InsertTestimonialDto> insertValidator, IValidator<UpdateTestimonialDto> updateValidator)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
            _insertValidator = insertValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var testimonials = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(testimonials);
        }

        [HttpGet("{id}")]
        public IActionResult TestimonialListByID(int id)
        {
            var testimonial = _mapper.Map<GetTestimonialDto>(_testimonialService.TGetById(id));
            if (testimonial == null)
                return NotFound("Kayıt Bulunamadı");

            return Ok(testimonial);
        }

        [HttpPost]
        public IActionResult TestimonialAdd(InsertTestimonialDto testimonial)
        {
            var validationResult = _insertValidator.Validate(testimonial);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var value = _mapper.Map<Testimonial>(testimonial);
            _testimonialService.TInsert(value);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult TestimonialUpdate(UpdateTestimonialDto testimonial)
        {
            var validationResult = _updateValidator.Validate(testimonial);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var value = _mapper.Map<Testimonial>(testimonial);
            _testimonialService.TUpdate(value);
            return Ok("Kayıt Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult TestimonialDelete(int id)
        {
            var value = _testimonialService.TGetById(id);
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            _testimonialService.TDelete(value);
            return Ok("Kayıt Başarıyla Silindi");
        }

    }
}
