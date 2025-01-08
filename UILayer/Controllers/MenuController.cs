using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UILayer.DTO.BasketDTO;
using UILayer.DTO.ProductDTO;

namespace UILayer.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Menu/Index/{tableId:int}")]
        public async Task<IActionResult> Index(int tableId)
        {
            ViewBag.tableId = tableId;

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/Product/ProductWithCategories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var foods = JsonConvert.DeserializeObject<List<ProductResultDTO>>(jsonData);
                return View(foods);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket(int productId, int tableId)
        {
            if (tableId == 0)
            {
                return BadRequest("Lütefen Bir Masa Seçiniz");
            }
            BasketInsertDTO dto = new BasketInsertDTO
            {
                ProductId = productId,
                TableId = tableId
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7068/api/Basket", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(dto);
        }
    }
}
