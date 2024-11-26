using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.ProductDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult ProductListByID(int id)
        {
            var product = _mapper.Map<GetProductDto>(_productService.TGetById(id));
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound("Kayıt Bulunamadı");
        }
        [HttpGet("ProductWithCategories")]
        public IActionResult ProductWithCategories()
        {
            var products = _mapper.Map<List<GetProductWithCategoryDto>>(_productService.TGetProductsWithCategories());
            return Ok(products);
        }

        [HttpPost]
        public IActionResult InsertProduct(InsertProductDto insertProductDto)
        {
            var value = _mapper.Map<Product>(insertProductDto);
            _productService.TInsert(value);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(value);
            return Ok("Kayıt Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            if (value != null)
            {
                _productService.TDelete(value);
                return Ok("Kayıt Başarıyla Silindi");
            }
            return NotFound("Kayıt Bulunamadı");
        }
    }
}
