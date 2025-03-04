﻿using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DTOLayer.BasketDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBasketByTableNumber(int tableNumber)
        {
            var values = _mapper.Map<List<ResultBasketDto>>(_basketService.TGetBasketByTableNumber(tableNumber));
            return Ok(values);
        }

        [HttpGet("GetBasketByTableNumberWithProductNames/{tableId}")]
        public IActionResult GetBasketByTableNumberWithProductNames(int tableId)
        {
            var values = _mapper.Map<List<ResultBasketWithProductNamesDto>>(_basketService.TGetBasketByTableNumberWithProductNames(tableId));
            return Ok(values);
        }

        [HttpPost]
        public IActionResult InsertBasket(InsertBasketDto insertBasketDto)
        {
            using var context = new Context();
            _basketService.TInsert(new Basket()
            {
                ProductId = insertBasketDto.ProductId,
                Count = 1,
                TableId = insertBasketDto.TableId,
                Price = context.Products.Where(x => x.ProductId == insertBasketDto.ProductId).Select(x => x.Price).FirstOrDefault(),
                TotalPrice = 1 * context.Products.Where(x => x.ProductId == insertBasketDto.ProductId).Select(x => x.Price).FirstOrDefault()
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            if (value == null)
                return NotFound("Kayıt Bulunamadı");

            _basketService.TDelete(value);
            return Ok("Kayıt Başarıyla Silindi");
        }

    }
}
