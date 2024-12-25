using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UILayer.DTO.AboutDTO;

namespace UILayer.ViewComponents.HomePageCompanents
{
    public class _HomePageAbout : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _HomePageAbout(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/About");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var about = JsonConvert.DeserializeObject<List<AboutResultDTO>>(jsonData);
                return View(about);
            }
            return View();
        }
    }
}
