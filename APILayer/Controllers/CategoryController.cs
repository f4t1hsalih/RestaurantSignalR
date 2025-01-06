using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.CategoryDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryByID(int id)
        {
            var value = _mapper.Map<GetCategoryDto>(_categoryService.TGetById(id));
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            return Ok(value);
        }

        [HttpPost]
        public IActionResult InsertCategory(InsertCategoryDto insertCategoryDto)
        {
            var value = _mapper.Map<Category>(insertCategoryDto);
            _categoryService.TInsert(value);
            return Ok("Kayıt başarıyla eklendi.");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(value);
            return Ok("Kayıt başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            if (value == null)
            {
                return NotFound("Kategori Bulunamadı");
            }
            _categoryService.TDelete(value);
            return Ok("Kayıt Başarıyla Silindi");
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.TCategoryCount());
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(_categoryService.TActiveCategoryCount());
        }

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            return Ok(_categoryService.TPassiveCategoryCount());
        }

    }
}
