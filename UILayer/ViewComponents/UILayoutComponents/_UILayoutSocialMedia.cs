using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UILayer.DTO.SocialMediaDTO;

namespace UILayer.ViewComponents.UILayoutComponents
{
    public class _UILayoutSocialMedia : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _UILayoutSocialMedia(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/SocialMedia");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var contacts = JsonConvert.DeserializeObject<List<SocialMediaResultDTO>>(jsonData);
                return View(contacts);
            }
            return View();
        }
    }
}
