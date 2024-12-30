using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.TableDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        private readonly IMapper _mapper;

        public TableController(ITableService tableService, IMapper mapper)
        {
            _tableService = tableService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TableList()
        {
            var value = _tableService.TGetListAll();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetTableByID(int id)
        {
            var table = _tableService.TGetById(id);
            if (table != null)
                return Ok(table);
            return NotFound("Kayıt bulunamadı");
        }


        [HttpPost]
        public IActionResult InsertTable(InsertTableDto insertTableDto)
        {
            var value = _mapper.Map<Table>(insertTableDto);
            _tableService.TInsert(value);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateTable(UpdateTableDto updateTableDto)
        {
            var value = _mapper.Map<Table>(updateTableDto);
            _tableService.TUpdate(value);
            return Ok("Kayıt başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTable(int id)
        {
            var table = _tableService.TGetById(id);
            if (table == null)
                return NotFound("Kayıt bulunamadı");

            _tableService.TDelete(table);
            return NoContent(); // Veri dönmeden başarılı silme işlemi
        }


        [HttpGet("TableCount")]
        public IActionResult TableCount()
        {
            return Ok(_tableService.TTableCount());
        }

    }
}
