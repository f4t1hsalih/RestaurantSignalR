using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UILayer.DTO.ProductDTO;

namespace UILayer.ViewComponents.HomePageCompanents
{
    public class _HomePageFoods : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _HomePageFoods(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/Product/ProductWithCategoriesFirstNine");
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
