using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UILayer.DTO.SliderDTO;

namespace UILayer.ViewComponents.HomePageCompanents
{
    public class _HomePageSlider : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _HomePageSlider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/Slider");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var sliders = JsonConvert.DeserializeObject<List<SliderResultDTO>>(jsonData);
                return View(sliders);
            }
            return View();
        }

    }
}
