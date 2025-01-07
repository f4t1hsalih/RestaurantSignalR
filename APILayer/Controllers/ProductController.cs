using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.CategoryDto;
using DTOLayer.ProductDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IValidator<InsertProductDto> _insertValidator;
        private readonly IValidator<UpdateProductDto> _updateValidator;

        public ProductController(IProductService productService, IMapper mapper, IValidator<UpdateProductDto> updateValidator, IValidator<InsertProductDto> insertValidator)
        {
            _productService = productService;
            _mapper = mapper;
            _updateValidator = updateValidator;
            _insertValidator = insertValidator;
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
            if (product == null)
                return NotFound("Kayıt Bulunamadı");

            return Ok(product);
        }

        [HttpPost]
        public IActionResult InsertProduct(InsertProductDto insertProductDto)
        {
            var result = _insertValidator.Validate(insertProductDto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var value = _mapper.Map<Product>(insertProductDto);
            _productService.TInsert(value);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var result = _updateValidator.Validate(updateProductDto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var value = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(value);
            return Ok("Kayıt Başarıyla Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            _productService.TDelete(value);
            return Ok("Kayıt Başarıyla Silindi");
        }

        [HttpGet("ProductWithCategories")]
        public IActionResult ProductWithCategories()
        {
            var products = _mapper.Map<List<GetProductWithCategoryDto>>(_productService.TGetProductsWithCategories());
            return Ok(products);
        }

        [HttpGet("ProductWithCategoriesFirstNine")]
        public IActionResult ProductWithCategoriesFirstNine()
        {
            var products = _mapper.Map<List<GetProductWithCategoryDto>>(_productService.TGetProductsWithCategoriesFirstNine());
            return Ok(products);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }

        [HttpGet("ProductCountByCategoryNameHamburger")]
        public IActionResult ProductCountByCategoryNameHamburger()
        {
            return Ok(_productService.TProductCountByCategoryNameHamburger());
        }

        [HttpGet("ProductCountByCategoryNameDrink")]
        public IActionResult ProductCountByCategoryNameDrink()
        {
            return Ok(_productService.TProductCountByCategoryNameDrink());
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());
        }

        [HttpGet("MinPriceProductName")]
        public IActionResult MinPriceProductName()
        {
            return Ok(_productService.TMinPriceProductName());
        }

        [HttpGet("MaxPriceProductName")]
        public IActionResult MaxPriceProductName()
        {
            return Ok(_productService.TMaxPriceProductName());
        }

        [HttpGet("ProductAvgPriceByHamburger")]
        public IActionResult ProductAvgPriceByHamburger()
        {
            return Ok(_productService.TProductAvgPriceByHamburger());
        }

    }
}
