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
            var category = _categoryService.TGetById(id);
            if (category != null)
            {
                var result = _mapper.Map<GetCategoryDto>(category);
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult InsertCategory(InsertCategoryDto insertCategoryDto)
        {
            var category = _mapper.Map<Category>(insertCategoryDto);
            _categoryService.TInsert(category);
            return Ok("Kayıt başarıyla eklendi.");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(category);
            return Ok("Kayıt başarıyla güncellendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            if (value == null)
            {
                return NotFound("Kategori bulunamadı.");
            }
            _categoryService.TDelete(value);
            return Ok("Kayıt başarıyla silindi.");
        }

    }
}
