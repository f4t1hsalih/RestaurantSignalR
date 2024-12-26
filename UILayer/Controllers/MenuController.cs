using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UILayer.DTO.ProductDTO;

namespace UILayer.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
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
    }
}
