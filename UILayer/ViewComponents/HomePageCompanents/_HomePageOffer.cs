using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UILayer.DTO.DiscountDTO;

namespace UILayer.ViewComponents.HomePageCompanents
{
    public class _HomePageOffer : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _HomePageOffer(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/Discount");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var discounts = JsonConvert.DeserializeObject<List<DiscountResultDTO>>(jsonData);
                return View(discounts);
            }
            return View();
        }
    }
}
