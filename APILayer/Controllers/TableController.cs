using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet("TableCount")]
        public IActionResult TableCount()
        {
            return Ok(_tableService.TTableCount());
        }

    }
}
