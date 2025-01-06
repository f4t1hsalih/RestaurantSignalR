using AutoMapper;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCaseController : ControllerBase
    {
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMapper _mapper;

        public MoneyCaseController(IMoneyCaseService moneyCaseService, IMapper mapper)
        {
            _moneyCaseService = moneyCaseService;
            _mapper = mapper;
        }

        [HttpGet("GetMoneyCaseAmount")]
        public IActionResult GetMoneyCaseAmount()
        {
            var value = _moneyCaseService.TGetMoneyCaseAmount();
            return Ok(value);
        }

    }
}
