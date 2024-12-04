using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCaseController : ControllerBase
    {
        private readonly IMoneyCaseService _moneyCaseService;

        public MoneyCaseController(IMoneyCaseService moneyCaseService)
        {
            _moneyCaseService = moneyCaseService;
        }

        [HttpGet("GetMoneyCaseAmount")]
        public IActionResult GetMoneyCaseAmount()
        {
            return Ok(_moneyCaseService.TGetMoneyCaseAmount());
        }
    }
}
