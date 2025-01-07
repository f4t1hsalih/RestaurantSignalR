using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.TableDto;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        private readonly IMapper _mapper;
        private readonly IValidator<InsertTableDto> _insertValidator;
        private readonly IValidator<UpdateTableDto> _updateValidator;

        public TableController(ITableService tableService, IMapper mapper, IValidator<InsertTableDto> insertValidator, IValidator<UpdateTableDto> updateValidator)
        {
            _tableService = tableService;
            _mapper = mapper;
            _insertValidator = insertValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public IActionResult TableList()
        {
            var values = _mapper.Map<List<ResultTableDto>>(_tableService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetTableByID(int id)
        {
            var value = _mapper.Map<GetTableDto>(_tableService.TGetById(id));
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            return Ok(value);
        }

        [HttpPost]
        public IActionResult InsertTable(InsertTableDto insertTableDto)
        {
            var result = _insertValidator.Validate(insertTableDto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var value = _mapper.Map<Table>(insertTableDto);
            _tableService.TInsert(value);
            return Ok("Kayıt Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateTable(UpdateTableDto updateTableDto)
        {
            var result = _updateValidator.Validate(updateTableDto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var value = _mapper.Map<Table>(updateTableDto);
            _tableService.TUpdate(value);
            return Ok("Kayıt Başarıyla Güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTable(int id)
        {
            var value = _tableService.TGetById(id);
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            _tableService.TDelete(value);
            return Ok("Kayıt Başarıyla Silindi");
        }

        [HttpGet("TableCount")]
        public IActionResult TableCount()
        {
            return Ok(_tableService.TTableCount());
        }

    }
}
