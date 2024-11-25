using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.ProductDto;
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
        public IActionResult ProductDetail(int id)
        {
            var product = _mapper.Map<ResultProductDto>(_productService.TGetById(id));
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound("Kayıt Bulunamadı");
        }
    }
}
