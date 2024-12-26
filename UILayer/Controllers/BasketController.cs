using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var response = await client.GetAsync("https://localhost:7068/api/Basket?tableNumber");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var basket = JsonConvert.DeserializeObject<List<BasketResultDTO>>(jsonData);
                return View(basket);
            }
            return View();
        }
    }
}
