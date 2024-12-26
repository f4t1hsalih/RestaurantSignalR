using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UILayer.DTO.BasketDTO;

namespace UILayer.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/Basket/GetBasketByTableNumberWithProductNames?tableNumber=4");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var basket = JsonConvert.DeserializeObject<List<BasketResultWithProductNamesDto>>(jsonData);
                return View(basket);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket()
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(about);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7068/api/Basket/", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
